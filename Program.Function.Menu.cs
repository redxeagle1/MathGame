public partial class Program
{
    // responsible for the menu interface
    static void ConstructMainMenu(char[] validOptions)
    {
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

        string hintSelection = $"type a letter from [{string.Join(", ", validOptions)}]\r\nNOTE: to end the program type [q] soft exit or [crtl+c] hard exit";
        string askForInput = "\r\nType your answer : \t";

        Console.Write(string.Join("\r\n", gameLabel));

        // seperation to avoid cluttering the window
        Console.Write("\r\n\r\n");
        Console.Write(string.Join("\r\n", menu));
        // seperation to avoid cluttering the window
        Console.Write("\r\n\r\n");
        Console.Write(hintSelection);
        Console.Write("\r\n");
        Console.Write(askForInput);
        // the null check is for safety, but this will just show what the user has typed
        Console.Write(InputBuffer?.ToString().ToLower());
    }
    // TODO: add warning signal after the input to indicate user errors i.e wrong input or empty input  
    static void ShowErrorMessage(string currentErrorType)
    {
        
    }
    // TODO: add menu handling logic
    static bool TryHandleMenuOption(string userInput)
    {
        return true;
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
