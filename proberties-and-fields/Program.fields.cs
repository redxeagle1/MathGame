using MathGame;

public partial class Program
{

    // a constant array to define our minimum valid screen
    static readonly byte[] MIN_WINDOW_COORDINATES = [25, 85]; // (height,width) (y,x)

    // this was preferred since I wanted to make most of my functions modular and window agnostic
    // our buffer char array which will hold our current ongoing valid options
    private static char[] s_activeOptionBuffer = ['a', 'b', 'c'];

    
    
    // our game history
    public static GameRecord[] GameHistoryArray = new GameRecord[1000];
    // Global tracker for both the record id and detection of array current size 
    public static int TotalGamesPlayed = 0;
}
