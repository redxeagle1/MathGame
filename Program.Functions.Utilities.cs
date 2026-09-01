
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

    static bool CheckOngoingInputBuffer(string buffer)
    {
        if (string.IsNullOrEmpty(buffer) && !(buffer.Length > 1))
        {
            return true;
        }
        return false;
    }
}
