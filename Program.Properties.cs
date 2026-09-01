using System.Text;

public partial class Program
{
    // a proberty that holds our game input for processing
    public static string? UserInput { get; set; }


    // had to give up using readline() since it liturally stop the execution of window update logic
    // I may use thread for that but I don't know multi-threading and concurency eaither 
    // so this is the safest route i can take 
    public static StringBuilder? InputBuffer { get ; set ; }
  
  
    // a static field to indicate the what will be drawn in the user's window
    public static string? CurrentWindow { get ; set ; }
    public static int UserWindowHeight { get ; set ; }
    public static int UserWindowWidth { get; set; }

    static void SetupGameProperties()
    {
        UserInput = "";
        CurrentWindow = WINDOW_MAP[0];
        UserWindowHeight =Console.WindowHeight;
        UserWindowWidth =Console.WindowWidth;
    }
}
