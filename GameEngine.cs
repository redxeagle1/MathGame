using MathGame;

public class GameEngine
// this class handle the window control as well as orchestration the gameplay
{
    #region  Fields
    // our game option storage
    private GameOptions GameOptions = new(); 
    // our game history
    public static GameRecord[] GameHistoryArray = new GameRecord[1000];
    // Global tracker for both the record id and detection of array current size 
    public static int TotalGamesPlayed = 0;
    
    #endregion
    
    #region Properties
    
    #endregion

    #region Methods
    public static void GameSetup()
    // a setup method to set the environment before entering the loop
    {
        // Clear the Terminal
        Console.Clear();


    }
    public static void Render()
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

                    string userInput = InputHandler.HandleUserInput(keyInfo);
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        
                    }
                }
            }
        }

    }
    #endregion

}
