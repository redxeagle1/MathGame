namespace MathGame;

public class SetupWindow : WindowBase
{
    public override string ValidOptions { get; set; } = "abcdew";
    public override int CurrentErrorLocation { get; set; } = 16;
    private bool IsOptionsSet { get; set; } = false;
    private GameOptions _gameOptions = GameEngine.sGameOptions;

    public override WindowMap ProcessInput(string userInput)
    {
        switch (userInput)
        {
            case "w" :
                ResetOptions();
                return WindowMap.SETUP_MENU;
            case "q":
                return WindowMap.MAIN_MENU;
            case "y":
                return WindowMap.GAME_WINDOW;
            default:
                SetQuestionOptions(userInput);
                return WindowMap.SETUP_MENU;
        }
    }

    public override void Render()
    {


        if (IsOptionsSet)
        {
            InputHandler.CurrentErrorLocation = 11;
            // change the Active Options to 
            InputHandler.SetActiveOptions = "yw";
            // A final display of user input
            Console.Write($"Difficulty : {_gameOptions.Difficulty}\t\tOperation : {_gameOptions.Operation}\t\tQuestion Type : {_gameOptions.QuestionType}\r\n");

            // Confirming the input
            Console.Write("Are you sure about your inputs");
            // saves all our selection back to the Game Engine to utilize it in the game mech
            GameEngine.sGameOptions = _gameOptions;

            InputHandler.InputPrompt(
            [
            "- type [q] to go back to main menu",
            "- type [y] to Confirm",
            "- type [w] to wipe all selections",
            "- press [ctrl+c] to hard exit"
            ]
            );
            return;
        }
        InputHandler.SetActiveOptions = ValidOptions;
        InputHandler.CurrentErrorLocation = CurrentErrorLocation;
        Console.Write($"Choose From The Following Options:\r\n");
        Console.Write("\r\n");
        RenderQuestionsSetup();
        InputHandler.InputPrompt(
        [
            "- type [q] to go back to main menu",
            "- type [w] to wipe all selections",
            "- press [ctrl+c] to hard exit"
        ]
        );

    }
    private void SetQuestionOptions(string userInput)
    {
        if (_gameOptions.Difficulty == GameDifficulty.NONE)
        {
            _gameOptions.Difficulty = SetGameDifficulty(userInput);
        }
        else if (_gameOptions.Operation == GameOperation.NONE)
        {
            _gameOptions.Operation = SetGameOperation(userInput);
        }
        else if (_gameOptions.QuestionType == GameQuestionType.NONE)
        {
            _gameOptions.QuestionType = SetGameQuestionType(userInput);
            // to indicate that the all options is set
            IsOptionsSet = true;
        }
    }
    private void RenderQuestionsSetup()
    {
        string infoPanel = $"Difficulty : {_gameOptions.Difficulty}\t\tOperation : {_gameOptions.Operation}\t\tQuestion Type : {_gameOptions.QuestionType}";
        if (_gameOptions.Difficulty == GameDifficulty.NONE)
        {
            RenderDifficultyOptions();
        }
        else if (_gameOptions.Operation == GameOperation.NONE)
        {
            RenderOperationOptions();
        }
        else if (_gameOptions.QuestionType == GameQuestionType.NONE)
        {
            RenderQuestionTypeOptions();
        }
        // an info panel to display the selection summary
        Console.Write("\r\n");
        Console.WriteLine($"{infoPanel}\r\n");
    }


    private static void RenderDifficultyOptions()
    {
        Console.Write("\tchoose a difficulty}\r\n");
        Console.Write("\t\ta. easy (digits from 0 to 10)}\r\n");
        Console.Write("\t\tb. normal (digits from 0 to 100)}\r\n");
        Console.Write("\t\tc. hard (digits from 0 to 10 + TIMED 10s)}\r\n");
        Console.Write("\t\td. insane (digits from 0 to 100 + TIMED 10s and 15s if random operation)}\r\n");
        Console.Write("\t\te. impossible (digits from 0 to 100 + TIMED 5s and 10s if random operation)}\r\n");
    }
    private static void RenderOperationOptions()
    {
        Console.Write("\tchoose the operation}\r\n");
        Console.Write($"\t\ta. addition (+)\r\n");
        Console.Write($"\t\tb. subtraction (-)\r\n");
        Console.Write($"\t\tc. multiplication (x)\r\n");
        Console.Write($"\t\td. division (÷)\r\n");
        Console.Write($"\t\te. random operation\r\n");
    }
    private static void RenderQuestionTypeOptions()
    {
        Console.Write("\tchoose the question type\r\n");
        Console.Write("\t\ta. MCQ\r\n");
        Console.Write("\t\tb. true or false\r\n");
        Console.Write("\t\tc. fill the gaps\r\n");
        Console.Write("\t\td. normal\r\n");
        Console.Write("\t\te. random\r\n");
    }
    private static GameDifficulty SetGameDifficulty(string userInput) => userInput switch
        // these method return a difficulty based on the input 
        {
            "a" => GameDifficulty.EASY,
            "b" => GameDifficulty.NORMAL,
            "c" => GameDifficulty.HARD,
            "d" => GameDifficulty.INSANE,
            "e" => GameDifficulty.IMPOSSIBLE,
            _ => GameDifficulty.NONE
        };
    private static GameOperation SetGameOperation(string userInput) => userInput switch
        // these method return a Operation based on the input 
        {
            "a" => GameOperation.ADDITION,
            "b" => GameOperation.SUBTRACTION,
            "c" => GameOperation.MULTIPLICATION,
            "d" => GameOperation.DIVISION,
            "e" => GameOperation.RANDOM,
            _ => GameOperation.NONE
        };
    private static GameQuestionType SetGameQuestionType(string userInput) => userInput switch
        // these method return a QuestionType based on the input 
        {
            "a" => GameQuestionType.MCQ,
            "b" => GameQuestionType.TRUE_FALSE,
            "c" => GameQuestionType.FILL_GAPS,
            "d" => GameQuestionType.NORMAL,
            "e" => GameQuestionType.RANDOM,
            _ => GameQuestionType.NONE
        };
    private void ResetOptions()
    {
        _gameOptions.Difficulty = GameDifficulty.NONE;
        _gameOptions.Operation = GameOperation.NONE;
        _gameOptions.QuestionType = GameQuestionType.NONE;
        IsOptionsSet = false;
    } 
}