

using System.Reflection.Metadata;

public partial class Program
{

    // a constant array to define our minimum valid screen
    static readonly byte[] MIN_WINDOW_COORDINATES = [25, 85]; // (height,width) (y,x)
    
    static private char[] s_userValidMainOptions = ['a', 'b', 'c',];
    static readonly char[] USERVALIDSETUPOPTIONS = ['a', 'b', 'c', 'd', 'e', 'w',];
    static readonly char[] USERVALIDMCQOPTIONS = ['a', 'b', 'c', 'd'];

    // a full map for our game
    static string[] WINDOW_MAP = ["MAIN_MENU", "SETUP_MENU", "GAME_WINDOW", "GAME_OVER_WINDOW", "HISTORY_WINDOW", "ABOUT_WINDOW", "QUIT_BANNER"];

    // static readonly int CurrentErrorLocation = 15;

}
