using System.Text;
namespace MathGame
{
    public static class InputHandler
    // A unified utility class for handling user input effectively  
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
        public static bool IsInputEmpty{get; set;}

        // the place in which will display our errors in the current active window
        public static int CurrentErrorLocation { get; set; } = 0;
        #endregion
        #region Methods
        static public string HandleUserInput(ConsoleKeyInfo key)
        // this method handles the input buffer itself
        {
            string userInput = ""; // this is the return variable
            
            switch (key.Key)
            // based on the given key it will handle these cases
            {
                case ConsoleKey.Enter:
                    // store this input into the string we are returning
                    userInput = InputBuffer?.ToString() ?? "";

                    // to check for empty input before submitting the string
                    if (string.IsNullOrEmpty(userInput))
                    {
                        IsInputEmpty = true;
                        ShowErrorMessage("You didn't type anything please enter something", CurrentErrorLocation);
                    }
                    // clear the buffer to reuse it again
                    InputBuffer?.Clear();
                    // check if there has been any errors flagged or no
                    if (IsInputWrong || IsHandlingFailed || IsInputEmpty)
                    {
                        // if true goto the default case
                        goto default;
                    }
                    break;


                
                case ConsoleKey.Backspace: // to add back spacing logic since we give up ReadLine
                    
                    if (InputBuffer?.Length > 0)
                    // checking the length of the input buffer to avoid accidental invalid indexing  
                    {
                        // remove the element once from the buffer
                        InputBuffer?.Remove(InputBuffer.Length - 1, 1);
                        Console.Write("\b \b"); // Erase character visually from console screen

                        // Clean errors if spotted
                        if (IsInputWrong || IsHandlingFailed )
                        {
                            CleanErrors();
                        }
                    }
                    break;
                default:
                    // check if the input buffer's equivalent string empty or null 
                    if (string.IsNullOrEmpty(InputBuffer?.ToString() ?? ""))
                    {
                        // pass the key itself to be check in handle key method
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
                if (IsInputWrong || IsHandlingFailed || IsInputEmpty)
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
            IsInputEmpty = false;
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
        static public void InputPrompt(string[]? inputTips = null)
        // Rather than ask for input in each time the user move to a new menu this method
        // will handle this Idea as well as displaying tips to the user
        {
            // separation to avoid cluttering the input area with the menu of the current window
            Console.Write("\r\n\r\n");


            // to address the null array I used null coalescing operator
            // if it founds that the array is null assign it to an empty array 
            inputTips ??= []; 
            if (   !(inputTips.Length == 0)   )
            {
                Console.Write($"NOTES:\r\n");
                Console.Write($"\t{string.Join("\r\n\t",inputTips)}\r\n");
            }
            // this to hold the current active options
            string inputHints = $"type a letter from [{string.Join(", ", s_activeOptionsBuffer)}]\r\n";
            // a prompt to encourage the user to type here  
            string askForInput = "\r\nType your answer : \t";
            Console.Write(inputHints);
            Console.Write(askForInput);
            // the null check is for safety, but this will just show what the user has typed
            Console.Write(InputBuffer?.ToString().ToLower());
        }
        #endregion

    }
}