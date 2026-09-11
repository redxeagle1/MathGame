using MathGame;

public class GameEngine
// this class handle the window control as well as orchestration
{


    
    // our game option storage
    private GameOptions GameOptions = new(); 

    
    // our game history
    public static GameRecord[] GameHistoryArray = new GameRecord[1000];
    // Global tracker for both the record id and detection of array current size 
    public static int TotalGamesPlayed = 0;
    // Track the current window and change it on demand
    // Track the state Change so we know when to trigger a redraw
    public void GameSetup()
    // a setup method to set the environment before entering the loop
    {
        // Clear the Terminal
        Console.Clear();
        // Call the menu Constructor for the first time
        // ConstructMainMenu(s_activeOptionBuffer); //TODO: uncomment that 

    }
    public void Render()
    {
        
        while (true)
        {
            WindowManager.UpdateWindow();
            if (WindowManager.CurrentWindow == WindowMap.QUIT_BANNER)
            {
                return;
            }
            // to make sure that our next logic is executed correctly
            // we need to execute the following if the screen is valid
            if (WindowManager.CheckValidScreen())
            {
                if (Console.KeyAvailable) //  true if a key press is available;
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true hide the automatic key echoing
                    Console.TreatControlCAsInput = false; // so to prevent accidental catch of the control 

                    // HandleUserInput(keyInfo);
                }
            }
        }

    }

}
