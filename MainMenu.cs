using System;

namespace MathGame;

public class MainMenu : WindowBase
{
    public override string ValidOptions => "abc";
    public override int CurrentErrorLocation => 15;
    public override void Render()
    {
        // game components
        string[] gameLabel = [
    @"███╗   ███╗ █████╗ ████████╗██╗  ██╗     ██████╗  █████╗ ███╗   ███╗███████╗",
    @"████╗ ████║██╔══██╗╚══██╔══╝██║  ██║    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝",
    @"██╔████╔██║███████║   ██║   ███████║    ██║  ███╗███████║██╔████╔██║█████╗"  ,
    @"██║╚██╔╝██║██╔══██║   ██║   ██╔══██║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ",
    @"██║ ╚═╝ ██║██║  ██║   ██║   ██║  ██║    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗",
    @"╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝     ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝"
        ];

        string[] menu = 
        [
        "\t\t\tA. Start the game",
        "\t\t\tB. History records",
        "\t\t\tC. About the game",
        ];

        // printing the game components
        Console.Write(string.Join("\r\n", gameLabel));

        // separation to avoid cluttering the window
        Console.Write("\r\n\r\n");
        Console.Write(string.Join("\r\n", menu));

        
        // input argument
        string[] notes = ["to end the program type [q] soft exit or [ctrl+c] hard exit"]; 
        // input prompt
        InputHandler.InputPrompt(notes);
    }
    public override WindowMap ProcessInput(string userInput)
    {
        return userInput switch
        {
          "a" => WindowMap.SETUP_MENU,
          "b" => WindowMap.HISTORY_WINDOW,
          "c" => WindowMap.ABOUT_WINDOW,
          _ => WindowMap.MAIN_MENU // wrong input stay in the window  
        };
    }    
}

