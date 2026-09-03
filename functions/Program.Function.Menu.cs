public partial class Program
{
    // responsible for the menu interface
    static void ConstructMainMenu(char[] validOptions)
    {
        // setting up the Error display location 
        CurrentErrorLocation = 15;
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

        string hintSelection = $"type a letter from [{string.Join(", ", validOptions)}]\r\nNOTE: to end the program type [q] soft exit or [ctrl+c] hard exit";
        string askForInput = "\r\nType your answer : \t";

        // printing the game components
        Console.Write(string.Join("\r\n", gameLabel));

        // separation to avoid cluttering the window
        Console.Write("\r\n\r\n");
        Console.Write(string.Join("\r\n", menu));
        // separation to avoid cluttering the window
        Console.Write("\r\n\r\n");
        Console.Write(hintSelection);
        Console.Write("\r\n");
        Console.Write(askForInput);
        // the null check is for safety, but this will just show what the user has typed
        Console.Write(InputBuffer?.ToString().ToLower());
    }
    // TODO: add menu handling logic
    static bool TryHandleMenuOptions(string userInput)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            ShowErrorMessage("You didn't type anything please enter something", CurrentErrorLocation);
            return true;
        }
        return false;
    }
    // TODO: add the static setup menu
    static void ConstructSetupMenu()
    {
        
    }
    static void QuitGameBanner()
    {
        Console.Clear();
        Console.WriteLine("Goodbye");
        Thread.Sleep(1000);
        CurrentWindow = WINDOW_MAP[6];
    }
}
