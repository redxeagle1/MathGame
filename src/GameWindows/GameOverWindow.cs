using MathGame.AbstractBases;
using MathGame.CoreUtilities;

namespace MathGame.GameWindows;

public class GameOverWindow : WindowBase
{
    public override string ValidOptions => "rc";
    public override int CurrentErrorLocation => 15;
    public override void Render()
    {
        InputHandler.CurrentErrorLocation = 14;
        string label =
            """
               ▄▄                      ▗▄▖                
              █▀▀▌                     █▀█                
             ▐▌    ▟██▖▐█▙█▖ ▟█▙      ▐▌ ▐▌▐▙ ▟▌ ▟█▙  █▟█▌
             ▐▌▗▄▖ ▘▄▟▌▐▌█▐▌▐▙▄▟▌     ▐▌ ▐▌ █ █ ▐▙▄▟▌ █▘  
             ▐▌▝▜▌▗█▀▜▌▐▌█▐▌▐▛▀▀▘     ▐▌ ▐▌ ▜▄▛ ▐▛▀▀▘ █   
              █▄▟▌▐▙▄█▌▐▌█▐▌▝█▄▄▌      █▄█  ▐█▌ ▝█▄▄▌ █   
               ▀▀  ▀▀▝▘▝▘▀▝▘ ▝▀▀       ▝▀▘   ▀   ▝▀▀  ▀   
            """;                                      
        Console.Write($"{label}\r\n");
        InputHandler.SetActiveOptions = "rc";
        string[] inputTips =
        [
            "[q] will wipe all the game data and exit",
            "[r] will reset the game with the settings",
            "[c] will go back to the main menu",
            $"{(GameEngine.SFinishedGame ? "your data was save successfully\r\ncheck the game history to find out" : "Couldn't Save Your Last Game's Data\r\nplease play at least 5 games to save your game")}"
        ];
        InputHandler.InputPrompt(inputTips);
    }

    public override WindowMap ProcessInput(string userInput)
    {
        return userInput switch
        {
            "q"=>WindowMap.QuitBanner,
            "r"=>WindowMap.GameWindow,
            "c"=> WindowMap.MainMenu,
            _ => throw new ArgumentOutOfRangeException(nameof(userInput), userInput, null)
        };
    }
}