using System.Text;
using MathGame;

public partial class Program
{
    // a property that holds our game input for processing
    public static string? UserInput { get; set; } = "";
    public static int UserWindowHeight { get; set; } = Console.WindowHeight;
    public static int UserWindowWidth { get; set; } = Console.WindowWidth;
    
    
    // had to give up using readline() since it literally stop the execution of window update logic
    // I may use thread for that but I don't know multi-threading and concurrency either 
    // so this is the safest route i can take 
    public static StringBuilder? InputBuffer { get; set; } = new();
    
    
    // a static property to indicate the what will be drawn in the user's window
    public static WindowMap CurrentWindow { get; set; } = WindowMap.MAIN_MENU;


    // indicators for wrong typing or invalid inputs 
    public static bool IsInputWrong {get; set;} = false;
    public static bool IsHandlingFailed {get; set;}= false;
    public static int CurrentErrorLocation {get; set;} = 0;
}
