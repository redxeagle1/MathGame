using MathGame.models;
using MathGame.utils;

namespace MathGame.menus;

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
            "[c] will go back to the main menu"
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