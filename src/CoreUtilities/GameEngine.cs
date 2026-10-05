using MathGame.GameQuestion;
using MathGame.GameWindows;

namespace MathGame.CoreUtilities;

public static class GameEngine
// this class handle the window control as well as orchestration the gameplay
{
    #region  Fields
    // our game option storage
    public static GameOptions SGameOptions = new(); 
    public static int STotalNumberOfQuestions;

    public static bool SFinishedGame;
    // our game history
    public static readonly List<GameRecord> GameHistoryTable = new List<GameRecord>(1000);
    // Global tracker for both the record id and detection of array current size 
    public static int TotalGamesPlayed = 0;
    
    #endregion
    
    #region Properties
    public static DateTime StartTime{get;set;}
    public static int Score{get;set;} // the game score
    #endregion

    #region Records

    public record GameRecord(int Id,DateTime PlayedDate, int TotalScore, GameDifficulty Difficulty,GameOperation Operation,GameQuestionType QuestionType,int TotalNumberOfQuestions);
    #endregion
    #region Methods
    public static void GameSetup()
        // a setup method to set the environment before entering the loop
    {
        // Clear the Terminal
        Console.Clear();
        WindowManager.SwitchState(WindowMap.MainMenu);
        WindowManager.ActiveWindow.Render();
    }
    public static void Render()
    {
        GameSetup();   
        while (true)
        {
            WindowManager.UpdateWindow();
            if (WindowManager.SNeedRefresh)
            {
                WindowManager.ForceUpdate();
            }
            if (WindowManager.CurrentWindow == WindowMap.QuitBanner)
            {
                return;
            }
            // to make sure that our next logic is executed correctly
            // we need to execute the following if the screen is valid
            if (WindowManager.CurrentWindow == WindowMap.GameWindow )
            {
                QuestionTimer.UpdateTimer();        
            }    
            if (WindowManager.CheckValidScreen())
            {
                if (Console.KeyAvailable) //  true if a key press is available;
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true hide the automatic key echoing
                    Console.TreatControlCAsInput = false; // so to prevent accidental catch of the control 

                    string userInput = InputHandler.HandleUserInput(keyInfo);
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        WindowMap nextState = WindowManager.ActiveWindow.ProcessInput(userInput : userInput);
                        if (WindowManager.CurrentWindow != nextState)
                        {
                            WindowManager.SwitchState(nextState);
                        }
                        else if (!InputHandler.HasError)
                        {
                            Console.Clear();
                            WindowManager.ActiveWindow.Render();
                        }
                    }
                }
                else if (WindowManager.CurrentWindow == WindowMap.GameWindow && QuestionTimer.IsTimeFinished)
                {
                    // Force penalty on timeout
                    WindowManager.ActiveWindow.ProcessInput("TIMEOUT");
                    QuestionTimer.IsTimeFinished = false; 
                    Console.Clear();
                    WindowManager.ActiveWindow.Render();
                }

                if (SFinishedGame)
                {
                    CommitHistory();
                }
                else
                {
                    {
                        Thread.Sleep(10); // not to burn our cpu processing power
                    }
                }
            }
        }

    }

    public static void CommitHistory()
    {
        if (SFinishedGame)
        {
            GameRecord record = new GameRecord(TotalGamesPlayed, StartTime, Score, SGameOptions.Difficulty,
                SGameOptions.Operation, SGameOptions.QuestionType, STotalNumberOfQuestions);
            GameHistoryTable.Add(record);
            SFinishedGame = false;
        }
    }

    // test method
/*     private static void GeneratedRandomRecords()
    {
        // making a random variable to use
        Random rnd = new();

        // getting all the possible Enum outcomes
        var difficulties = Enum.GetValues<GameDifficulty>();
        var operations = Enum.GetValues<GameOperation>(); 
        var questionType = Enum.GetValues<GameQuestionType>();



        for (int i = 1; i <= 100; i++) // to get 100 test sample
        {
            GameHistoryTable.Add(new GameRecord(
                Id: i,
                PlayedDate: DateTime.Now.AddDays(rnd.NextDouble()*60).AddHours(rnd.NextDouble()*24),
                TotalScore:rnd.Next(1,30000),
                Difficulty:difficulties[rnd.Next(difficulties.Length)],
                Operation:operations[rnd.Next(operations.Length)],
                QuestionType:questionType[rnd.Next(questionType.Length)],
                TotalNumberOfQuestions:rnd.Next(1,300000)
            ));
        }
        TotalGamesPlayed = 100;
    } */
    #endregion

}