
public partial class Program
{
    static void HandleInputKeys(ConsoleKeyInfo key, char[] validOptions)
    {
        char loweredKey = char.ToLower(key.KeyChar);
        if (validOptions.Contains(loweredKey) || (loweredKey == 'q'))
        {
            InputBuffer?.Append(loweredKey);
            Console.Write(loweredKey);
        }
        else
        {
            Console.WriteLine($"\r\nyou only can enter [{string.Join(", ",validOptions)}, q]");
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
