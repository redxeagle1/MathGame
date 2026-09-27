using MathGame.models;
using MathGame.utils;

namespace MathGame.menus.SetupMenu;

public class SetupWindow : WindowBase
{
    public override string ValidOptions => "abcdew";
    public override int CurrentErrorLocation => 19;
    private bool IsOptionsSet { get; set; } = false;
    private GameOptions _gameOptions = GameEngine.SGameOptions;

    public override WindowMap ProcessInput(string userInput)
    {
        switch (userInput)
        {
            case "w" :
                SetupOptionHandler.ResetOptions(ref _gameOptions);
                IsOptionsSet = false;
                return WindowMap.SetupMenu;
            case "q":
                return WindowMap.MainMenu;
            case "y":
                // saves all our selection back to the Game Engine to utilize it in the game mech
                GameEngine.SGameOptions = _gameOptions;
                return WindowMap.GameWindow;
            default:
                if (!IsOptionsSet)
                {
                    IsOptionsSet = SetupOptionHandler.SetQuestionOptions(userInput, ref _gameOptions);
                }
                return WindowMap.SetupMenu;
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