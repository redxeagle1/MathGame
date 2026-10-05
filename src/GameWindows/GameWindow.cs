using MathGame.AbstractBases;
using MathGame.CoreUtilities;
using MathGame.GameQuestion;
using MathGame.GameQuestion.Questions;

namespace MathGame.GameWindows;

public class GameWindow : WindowBase
{
    public override string ValidOptions => "";
    public override int CurrentErrorLocation => 20;
    
    private IQuestion? _question;// an interface for all the Questions
    private Options _options;
    private int _chances = 5;
    private int _score;
    private int _totalQuestionNumbers=1;
    private int _totalQuestionNumbersSnapshot;
    
    public override WindowMap ProcessInput(string userInput)
    {
        if (_chances != 0 && userInput[0] != 'q')
        {
            bool isAnswerWrong = userInput == "TIMEOUT" || !(_question != null && _question.CheckAnswer(userInput));
            if (!isAnswerWrong)
            {
                _totalQuestionNumbers++;
                switch (_options.Difficulty)
                {
                    case GameDifficulty.Easy:
                    case GameDifficulty.Normal:
                        _score++;
                        break;
                    default:
                        _score += (QuestionTimer.CountDown + 1);
                        break;
                }
            }
            else
            {
                _totalQuestionNumbers++;
                _chances--;
            }
            if (_chances > 0)
            {
                // reload another question
                return WindowMap.GameWindow;
            }
            
        }
        // reset the Game Window
        _chances = 5;
        if (_totalQuestionNumbers >= 5)
        {
            GameEngine.TotalGamesPlayed++;
            GameEngine.Score = _score;
            GameEngine.STotalNumberOfQuestions =  _totalQuestionNumbers;
            GameEngine.SFinishedGame = true;
            _score = 0;
            _totalQuestionNumbers = 0;
            _totalQuestionNumbersSnapshot = 0;
            return WindowMap.GameOverWindow;
        }
        _score = 0;
        _totalQuestionNumbers = 0;
        _totalQuestionNumbersSnapshot = 0;
        GameEngine.SFinishedGame = false;
        return WindowMap.GameOverWindow;
    }

    // copy the main option into a temp variable

    private void CheckTimer()
    {
        switch (_options.Difficulty)
        {
            case GameDifficulty.Easy:
            case GameDifficulty.Normal:
                break;
            case GameDifficulty.Hard:
                QuestionTimer.StartTimer(60, 10);
                break;
            case GameDifficulty.Insane:
                QuestionTimer.StartTimer(60,
                    _options.Operation== GameOperation.Random ? 15:10);
                break;
            case GameDifficulty.Impossible:
                QuestionTimer.StartTimer(60,
                    _options.Operation== GameOperation.Random ? 10:5);
                break;
            default:
                throw new Exception();
        }
    }

    public override void Render()
    {
        GameEngine.StartTime = DateTime.Now;
        InputHandler.CurrentErrorLocation = 17;
        _options = GameEngine.SGameOptionsRecord;
        if (_totalQuestionNumbers - _totalQuestionNumbersSnapshot == 1)
        {
            _totalQuestionNumbersSnapshot = _totalQuestionNumbers;
            _question = GetQuestion();
            
            CheckTimer();

        }
        ConfigureInputOptions(_question?.QuestionType);
        Console.Write($"Question numbers: {_totalQuestionNumbers}\r\n");
        Console.Write(_question?.QuestionPrompt);
        Console.Write("\r\n");
        Console.Write($"\r\nChances Left: {_chances}");
        Console.Write($"\r\nCurrent Score: {_score}");
        InputHandler.InputPrompt(["type [q] to end the game"]);
    }

    private IQuestion GetQuestion()
    {
        // using a ternery operator we check if the question type is random or no 
        // if it's select a random num from 1 to 5 then turn it into a question
        // else set it the presented type
        var type = _options.QuestionType == GameQuestionType.Random
            ? (GameQuestionType)Random.Shared.Next(1, 5)
            : _options.QuestionType;
        var problem = new Problem(_options);
        switch (type)
        {
            case GameQuestionType.Mcq:
                return new QuestionMcq(problem);
            case GameQuestionType.Normal:
                return new QuestionNormal(problem);
            case GameQuestionType.FillGaps:
                return new QuestionFillGaps(problem);
            case GameQuestionType.TrueFalse:
                return new QuestionTf(problem);
            default:
                throw new Exception();
        }
    }

    private void ConfigureInputOptions(GameQuestionType? questionType)
    // set the input dynamically
    {
        InputHandler.QuestionMode = false;
        switch (questionType)
        {
            case GameQuestionType.Mcq:
                InputHandler.SetActiveOptions = "abcd";
                break;
            case GameQuestionType.TrueFalse:
                InputHandler.SetActiveOptions = "tf";
                break;
            case GameQuestionType.Normal:
                InputHandler.QuestionMode = true;
                InputHandler.SetActiveOptions = "0123456789";
                break;
            case GameQuestionType.FillGaps:
                InputHandler.QuestionMode = true;
                InputHandler.SetActiveOptions = "0123456789+-*/";
                break;
            default:
                throw new Exception("unknown question type");
        }
    }
}