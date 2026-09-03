using MathGame;

public partial class Program
{

    static void HandleUserInput(ConsoleKeyInfo key, bool questionMode = false)
    {
        switch (key.Key)
        {
            case ConsoleKey.Enter:
                UserInput = InputBuffer?.ToString().Trim().ToLower();

                // TODO: Add user processing pipeline method
                switch (CurrentWindow)
                {
                    case WindowMap.MAIN_MENU:
                        IsHandlingFailed=TryHandleMenuOptions(userInput: UserInput ?? "");
                        break;
                }
                if (IsInputWrong || IsHandlingFailed) {
                    goto default;
                }

                Console.WriteLine($"\r\nprocessing your input note that the input is auto trimmed and lowered for consistent processing  : [{UserInput}]");
                // TODO: add a method for processing choices processing logic
                break;
            case ConsoleKey.Backspace: // to add back spacing logic since we give up ReadLine
                if (InputBuffer?.Length > 0)
                {
                    InputBuffer?.Remove(InputBuffer.Length - 1, 1);
                    IsInputWrong = IsHandlingFailed = false;
                    Console.Write("\b \b"); // Erase character visually from console screen
                }
                break;
            default:
                if (CheckOngoingInputBuffer(InputBuffer?.ToString() ?? "" ) || questionMode)
                {
                    TryHandleInputKeys(key, s_userValidMainOptions);
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
    static bool TryUpdateWindow(int currentX, int currentY, char[] validMenuOptions, out int newX, out int newY)
    {
        newX = currentX;
        newY = currentY;
        if (Console.WindowWidth != currentX || Console.WindowHeight != currentY)
        {
            newX = Console.WindowWidth;
            newY = Console.WindowHeight;
            Console.Clear();
            if (!CheckValidScreen())
            {
                return true;
            }

            Thread.Sleep(30); // Prevents high CPU usage
            ConstructMainMenu(validMenuOptions);
        }
        return false;
    }
    //TODO: ADD the window switch method
    static void SwitchWindows()
    {
        
    }
}
