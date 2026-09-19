namespace MathGame;

public class MainMenu : WindowBase
{
    public override string ValidOptions => "abc";
    public override int CurrentErrorLocation => 16;
    public override void Render()
    {
        InputHandler.SetActiveOptions = ValidOptions;
        // set the input handler's valid options to
        InputHandler.CurrentErrorLocation = CurrentErrorLocation;
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
        switch (userInput)
        {
            case "a":
                return WindowMap.SETUP_MENU;
            case "b":
                if (GameEngine.TotalGamesPlayed == 0)
                {
                    InputHandler.HasError = true;
                    // Push a completely custom error to the handler on demand
                    InputHandler.ShowErrorMessage("No history found. You must play a game first.");
                    
                    // Return the same state so the window doesn't switch
                    return WindowMap.MAIN_MENU; 
                }
                return WindowMap.HISTORY_WINDOW;
            case "c":
                return WindowMap.ABOUT_WINDOW;
            case "q":
                return WindowMap.QUIT_BANNER;
            default:
                return WindowMap.MAIN_MENU;
                
        }

    }    
}

