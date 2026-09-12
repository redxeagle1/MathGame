using System.Text;
namespace MathGame
{
    public static class InputHandler
    {
        #region fields
        // this was preferred since I wanted to make most of my functions modular and window agnostic
        // our buffer char array which will hold our current ongoing valid options
        private static char[] s_activeOptionsBuffer = ['a', 'b', 'c'];

        #endregion
        #region Properties

        // had to give up using readline() since it literally stop the execution of window update logic
        // I may use thread for that but I don't know multi-threading and concurrency either 
        // so this is the safest route i can take 
        public static StringBuilder? InputBuffer { get; set; } = new();

        // this is for controlling s_activeOptionBuffer it reset the current options into new ones
        public static string? SetActiveOptions
        {
            set
            {
                field = value; // Saves the string text into the hidden string aka field

                // I know this isn't a best practice
                // but window updates happens one a time not in a constant loop  
                // so it's better to go with that option for easy modularity and extensibility  
                s_activeOptionsBuffer = (value ?? "").ToCharArray();
            }
        } = "abc";


        // indicators for wrong typing or invalid inputs 
        public static bool IsInputWrong { get; set; } = false;
        public static bool IsHandlingFailed { get; set; } = false;

        // the place in which will display our errors in the current active window
        public static int CurrentErrorLocation { get; set; } = 0;
        #endregion
        #region Methods
        static public string HandleUserInput(ConsoleKeyInfo key)
        // this method handles the input buffer itself
        {
            string userInput = "";
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    // IsHandlingFailed = TryHandleMenuOptions(userInput: UserInput ?? ""); // FIXME:
                    userInput = InputBuffer?.ToString() ?? "";
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
                    if (string.IsNullOrEmpty(InputBuffer?.ToString() ?? ""))
                    {
                        HandleInputKeys(key);
                    }
                    break;
            }
            return userInput;
        }
        static private void HandleInputKeys(ConsoleKeyInfo key)
        // this method handles the user keystrokes and store it in the InputBuffer
        {
            // since the keys are capitalized I decided to lower them for easy processing
            char loweredKey = char.ToLower(key.KeyChar);
            // checking if our key is one of the valid options or a "q" and it length is 0
            if ((s_activeOptionsBuffer.Contains(loweredKey) || loweredKey == 'q') && InputBuffer?.Length == 0)
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
                    ShowErrorMessage($"You type wrong option you can only use" + "[" + string.Join(", ", s_activeOptionsBuffer) + ", q]", CurrentErrorLocation);
                    // make IsInputWrong true
                    IsInputWrong = true;
                }
            }
        }
        static public void CleanErrors()
        // to check and clear any error
        {
            // passing an empty string will clear the error as well
            ShowErrorMessage("", CurrentErrorLocation);

            // reset all the error flags as well
            IsInputWrong = false;
            IsHandlingFailed = false;
        }
        static public void ShowErrorMessage(string currentErrorType, int placement)
        // just to show the user what is wrong
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
        #endregion

    }
}