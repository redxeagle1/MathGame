
public partial class Program
{
    static void HandleInputKeys(ConsoleKeyInfo key, char[] validOptions)
    {
        char loweredKey = char.ToLower(key.KeyChar);
        if ((validOptions.Contains(loweredKey) || loweredKey == 'q') && InputBuffer?.Length == 0)    
        {
            InputBuffer?.Append(loweredKey);
            Console.Write(loweredKey);
        }
        else
        {
            Console.Write("\a");
        }
    }
    static void ShowErrorMessage(string currentErrorType,int placement)
    {
        // just to show the user what is wrong
        Console.SetCursorPosition(0,placement);
        Console.WriteLine($"\a\e[31m{currentErrorType}\e[0m");
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
