
public partial class Program
{
    static void TryHandleInputKeys(ConsoleKeyInfo key, char[] validOptions)
    {
        char loweredKey = char.ToLower(key.KeyChar);
        if ((validOptions.Contains(loweredKey) || loweredKey == 'q') && InputBuffer?.Length == 0)    
        {
            InputBuffer?.Append(loweredKey);
            Console.Write(loweredKey);
            IsInputWrong = false;
        }
        else
        {
            ShowErrorMessage($"You type wrong option you can only use" + "[" +string.Join(", ",s_userValidMainOptions) + ", q]",MENU_ERROR_PLACEMENT);
            IsInputWrong = true;
        }
    }
    // just to show the user what is wrong
    static void ShowErrorMessage(string currentErrorType,int placement)
    {
        // saving the current user cursor position
        int currentLeftCursor = Console.CursorLeft;
        int currentTopCursor = Console.CursorTop;

        // setting the cursor into the specified location to display the message 
        Console.SetCursorPosition(0,placement);
        // print the message and over-write the rest of the line with blanks  
        Console.Write($"\a\e[31m{currentErrorType}\e[0m".PadRight(Console.WindowWidth,' '));
        // reset the cursor back to the old position
        Console.SetCursorPosition(currentLeftCursor,currentTopCursor);
    }
    static bool CheckOngoingInputBuffer(string buffer)
    {
        if (string.IsNullOrEmpty(buffer) && !(buffer.Length > 1))
        {
            return true;
        }
        return false;
    }
}
