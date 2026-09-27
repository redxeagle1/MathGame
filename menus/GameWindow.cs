using MathGame.models;
using MathGame.models.Answers;
using MathGame.models.Questions;
using MathGame.utils;

namespace MathGame.menus;

public class GameWindow : WindowBase
{
    public override string ValidOptions => "";
    public override int CurrentErrorLocation  => 20;
    // Knowing that this is a workaround and probably a very bad practise I couldn't think
    // of other way to store and reuse the question and it's answer
    private object? _question;
    private int _chances = 5; // give the user 5 chances before losing
    private int _score; // user score

    private GameQuestionType _currentQuestionType;

    private bool IsAnswerWrong { get; set; }= false;
    
    public override WindowMap ProcessInput(string userInput)
    {
        if (_chances == 0 || userInput[0] != 'q')
        {
            switch (_currentQuestionType)
            {
                case GameQuestionType.Mcq:
                    IsAnswerWrong = !((_question is QuestionMcq mcq) && mcq.Answer.ValidateAnswer(userInput[0]));
                    break;
                case GameQuestionType.FillGaps:
                    IsAnswerWrong = !((_question is QuestionFillGaps fg) && fg.Answer.ValidateAnswer(userInput));
                    break;          
                case GameQuestionType.TrueFalse:
                    IsAnswerWrong = !((_question is QuestionTf tf) && tf.Answer.ValidateAnswer(userInput[0]));
                    break;   
                case  GameQuestionType.Normal:
                    IsAnswerWrong = !((_question is QuestionNormal normal) && normal.Answer.ValidateAnswer(userInput));
                    break;
            }

            if (!IsAnswerWrong)
            {
                switch (GameEngine.SGameOptions.Difficulty)
                {
                    case GameDifficulty.Easy:
                    case GameDifficulty.Normal:
                        _score++;
                        break;
                    case GameDifficulty.Hard:
                    case GameDifficulty.Insane:
                    case GameDifficulty.Impossible:
                        var countdown = _score + QuestionTimer.Countdown;
                        _score = countdown;
                        break;
                }
                return WindowMap.GameWindow;
                
            }
            _chances--;
            return WindowMap.GameWindow;
        }
        // if the user lose all the chances or soft exit with Q move to the game over window  
        GameEngine.Score = _score;
        return WindowMap.GameOverWindow;
    }

    public override void Render()
    {
        // print the question to the user
        Console.Write(MakeQuestion());
        Console.Write("\r\n");
        // checks if a timer is needed or no
        CheckTimer(GameEngine.SGameOptions.Difficulty,GameEngine.SGameOptions.Operation);
        Console.Write("\r\n");
        Console.Write($"Current score: {_score}");
        // as for input
        InputHandler.InputPrompt(["[q] will end the game."]);
        if (QuestionTimer.IsTimeFinished)
        {
            InputHandler.ShowErrorMessage("you lost 1 chance");
            _chances--; // decrement chances by 1
            Thread.Sleep((1000));
        }
    }

    
    private void CheckTimer(GameDifficulty difficulty, GameOperation operation)
    {
        int counter;
        switch (difficulty)
        {
            case GameDifficulty.Easy:
            case GameDifficulty.Normal:
                break;
            case GameDifficulty.Hard:
                QuestionTimer.StartTimer(9,10);
                break;
            case GameDifficulty.Insane:
                counter = operation == GameOperation.Random ? 15 : 10;
                QuestionTimer.StartTimer(9, counter);
                break;
            case GameDifficulty.Impossible:
                counter = operation == GameOperation.Random ? 10 : 5;
                QuestionTimer.StartTimer(9, counter);
                break;
            
        }
    }
    private string DefineQuestion(GameQuestionType questionType)
    // handles the Question initialization and header extraction
    {
        switch (questionType)
        {
            case GameQuestionType.Mcq:
                InputHandler.SetActiveOptions = "abcd";
                _question = new QuestionMcq(new Problem());
                return (_question is QuestionMcq mcq) ? mcq.QuestionPrompt : "";
            case GameQuestionType.FillGaps:
                InputHandler.SetActiveOptions = "0123456789"; // Enable Question mode here
                InputHandler.QuestionMode = true;
                _question = new QuestionFillGaps(new Problem());
                return (_question is QuestionFillGaps fg) ? fg.QuestionPrompt : "";
            case GameQuestionType.TrueFalse:
                InputHandler.SetActiveOptions = "tf";
                _question = new QuestionTf(new Problem());
                return (_question is QuestionTf tf) ? tf.QuestionPrompt : "";
            case GameQuestionType.Normal:
                InputHandler.SetActiveOptions = "0123456789"; // Enable Question mode here
                InputHandler.QuestionMode = true;
                _question = new QuestionFillGaps(new Problem());
                return (_question is QuestionNormal normal) ? normal.QuestionPrompt : "";
            default:
                return "";
        }
    }
    private string MakeQuestion()
    {

        // if the main game option is random then it will choose between the 4 types
        if (GameEngine.SGameOptions.QuestionType == GameQuestionType.Random)
        {
            _currentQuestionType = (GameQuestionType)Random.Shared.Next(0, 4);
        }
        else
        // else the current type will hold the main game option
        {
            _currentQuestionType = GameEngine.SGameOptions.QuestionType;
        }
        InputHandler.QuestionMode = false; // reset input handler
        return DefineQuestion(_currentQuestionType);
    }
}