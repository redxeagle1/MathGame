using System.Diagnostics;
public partial class Program
{

    static void HandleUserInput(ConsoleKeyInfo key, bool questionMode = false)
    {
        switch (key.Key)
        {
            case ConsoleKey.Enter:
                UserInput = InputBuffer?.ToString().Trim().ToLower();
                IsHandlingFailed = TryHandleMenuOptions(userInput: UserInput ?? "");
                InputBuffer?.Clear();
                if (IsInputWrong || IsHandlingFailed)
                {
                    goto default;
                }
                break;
            case ConsoleKey.Backspace: // to add back spacing logic since we give up ReadLine
                if (InputBuffer?.Length > 0)
                {
                    InputBuffer?.Remove(InputBuffer.Length - 1, 1);
                    IsInputWrong = IsHandlingFailed = false;
                    Console.Write("\b \b"); // Erase character visually from console screen
                    if (IsInputWrong || IsHandlingFailed)
                    {
                        CleanErrors();
                    }
                }
                break;
            default:
                if (string.IsNullOrEmpty(InputBuffer?.ToString() ?? "") || questionMode)
                {
                    TryHandleInputKeys(key, s_activeOptionBuffer);
                }
                break;
        }
    }
    static bool CheckValidScreen()
    {
        int y = Console.WindowHeight;
        int x = Console.WindowWidth;
        if (y < MIN_WINDOW_COORDINATES[0] || x < MIN_WINDOW_COORDINATES[1])
        {
            Console.Clear();
            var whatToAdjust = (y < MIN_WINDOW_COORDINATES[0] && x < MIN_WINDOW_COORDINATES[1]) ?
                                        $"both of Windows'Height and Width so (y: {y}) be >= {MIN_WINDOW_COORDINATES[0]} and (x: {x}) be >= {MIN_WINDOW_COORDINATES[1]}" :
                                        x < MIN_WINDOW_COORDINATES[1] ?
                                            $"the Window Width so (x: {x}) be >= {MIN_WINDOW_COORDINATES[1]}" :
                                            $"the Window Hight so (y: {y}) be >= {MIN_WINDOW_COORDINATES[0]}";


            Console.WriteLine($"Window must be greater than or equal to  ({MIN_WINDOW_COORDINATES[0]} x {MIN_WINDOW_COORDINATES[1]}) please adjust {whatToAdjust}");
            Thread.Sleep(100); // Prevents high CPU usage
            return false;
        }
        return true;

    }
    static bool TryUpdateWindow(int currentX, int currentY,WindowMap previousWindow, char[] validMenuOptions, out int newX, out int newY)
    {
        newX = currentX;
        newY = currentY;
        bool isMenuChanged = CurrentWindow != previousWindow;
        bool isWindowChanged = Console.WindowWidth != currentX || Console.WindowHeight != currentY;
        
        if (isWindowChanged || isMenuChanged)
        {
            newX = Console.WindowWidth;
            newY = Console.WindowHeight;
            Console.Clear();
            if (!CheckValidScreen())
            {
                return true;
            }

            Thread.Sleep(30); // Prevents high CPU usage
            SwitchWindows();
            // To indicate a successful update if not the app will rapidly redraw the window
            return true;
        }
        return false;
    }
    static void SwitchWindows()
    {
        switch (CurrentWindow)
        {
            case WindowMap.MAIN_MENU:
                ConstructMainMenu(s_activeOptionBuffer);
                break;
            case WindowMap.SETUP_MENU:
                ConstructSetupMenu();
                break;
            case WindowMap.QUIT_BANNER:
                QuitGameBanner();
                break;
        }
    }
    static void SaveGameRecord(GameRecord record)
    {
        // using the modulus operator we can assure that 1000 element is displayed at a time
        int index = TotalGamesPlayed % GameHistoryArray.Length;
        // sure that will overwrite data but I sacrificed it for lesser memory footprint  
        GameHistoryArray[index] = record;
        TotalGamesPlayed++;
    }
}
