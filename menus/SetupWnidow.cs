using MathGame.menus;

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
                SetupOptionHandler.ResetOptions(ref _gameOptions);
                IsOptionsSet = false;
                return WindowMap.SETUP_MENU;
            case "q":
                return WindowMap.MAIN_MENU;
            case "y":
                // saves all our selection back to the Game Engine to utilize it in the game mech
                GameEngine.sGameOptions = _gameOptions;
                return WindowMap.GAME_WINDOW;
            default:
                if (!IsOptionsSet)
                {
                    IsOptionsSet = SetupOptionHandler.SetQuestionOptions(userInput, ref _gameOptions);
                }
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
        SetupOptionHandler.RenderQuestionsSetup(ref _gameOptions);
        InputHandler.InputPrompt(
        [
            "- type [q] to go back to main menu",
            "- type [w] to wipe all selections",
            "- press [ctrl+c] to hard exit"
        ]
        );

    }
   
}