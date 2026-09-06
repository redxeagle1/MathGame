
public partial class Program
{
    static void TryHandleInputKeys(ConsoleKeyInfo key, char[] validOptions)
    {
        // since the kwy are capitalized I decided to lower them for easy processing
        char loweredKey = char.ToLower(key.KeyChar);
        // checking if our key is one of the valid options or a "q" and it length is 0
        if ((validOptions.Contains(loweredKey) || loweredKey == 'q') && InputBuffer?.Length == 0)
        {
            //check for potential error 
            if (IsInputWrong || IsHandlingFailed)
            {
                // calling clean function if there is errors 
                CleanErrors();
            }
            // if so append that key to our input buffer then write it
            InputBuffer?.Append(loweredKey);
            Console.Write(loweredKey);
        }
        else
        {
            // to check if the IsHandlingFailed is true
            if (IsHandlingFailed)
            {
                // return so the error message of wrong input doesn't override the empty input
                return;
            }
            else
            {
                // print the error message for the user
                ShowErrorMessage($"You type wrong option you can only use" + "[" + string.Join(", ", s_userValidMainOptions) + ", q]", CurrentErrorLocation);
                // make IsInputWrong true
                IsInputWrong = true;
            }
        }
    }

    static void CleanErrors()
    // to check and clear any error
    {
        // first we must check if there is any flag toggled in the wild

        // passing an empty string will clear the error as well
        ShowErrorMessage("", CurrentErrorLocation);
        // reset all the error flags as well
        IsInputWrong = false;
        IsHandlingFailed = false;

        return;
    }

    // just to show the user what is wrong
    static void ShowErrorMessage(string currentErrorType, int placement)
    {
        // saving the current user cursor position
        int oldLeftCursor = Console.CursorLeft;
        int oldTopCursor = Console.CursorTop;

        // setting the cursor into the specified location to display the message 
        Console.SetCursorPosition(0, placement);
        // print the message and over-write the rest of the line with blanks  
        Console.Write($"\e[31m{currentErrorType}\e[0m".PadRight(Console.WindowWidth, ' '));
        // reset the cursor back to the old position
        Console.SetCursorPosition(oldLeftCursor, oldTopCursor);
    }
}
