using System.Timers;
using Timer = System.Threading.Timer;

namespace MathGame.utils;

public static class QuestionTimer 
/* this will be responsible for the following
    1. counting the specified timer per question
    2. printing the timer out to the user provide by a public static utility
    3. return a signal denoting that the timer is finished
    4. have a public prop to access that return the remaining time on demand
*/
{
    #region Fields
    private static readonly System.Timers.Timer Timer = new(1000);
    private static int _countDown; 
    #endregion 
    
    ////////////////////
    
    #region Proberties
    public static int Countdown { get =>_countDown; set=>_countDown=value; }
    private static int TimerLocationX { get; set; } 
    public static bool IsTimeFinished { get; set; } = false;
    #endregion
    
    ///////////////////
    
    #region Methods

    // resets time
    public static void ResetTime(int countdown)=>Countdown = countdown;
    
    
    public static void StartTimer(int timerLocationX,int countdown)
    // set up the timer countdown
    {
        Countdown = countdown; 
        Timer.Elapsed += OnTimedEvent;

        ////// timer configuration //////
        // automatically reset the interval
        Timer.AutoReset = true;
        // Choose if the timer repeats by setting AutoReset to true
        Timer.Enabled = true;
        
        // put the location of x 
        TimerLocationX = timerLocationX;
        
        // start the timer
        PrintTimer();
        
    }
    private static void PrintTimer()
    // print the timer to the user
    {
        // save the older cursor's place
        int oldXLocation = Console.CursorLeft;
        int oldYLocation = Console.CursorTop;
        
        // move to the timer's location
        Console.SetCursorPosition(TimerLocationX,0);
        
        // update the countdown
        Console.Write(" ".PadRight(Console.WindowWidth));
        Console.Write(Countdown);
        Console.SetCursorPosition(oldXLocation,oldYLocation);
    }
    private static void OnTimedEvent(object? source, ElapsedEventArgs? e)
    {
        // Decrease the counter by 1 safety across all the threads and prevent 
        // race condition by taking a snapshot of the current variable 
        int currentCount = Interlocked.Decrement(ref _countDown);
        
        // evaluate if the timer is <= 0 or >= 
        if (currentCount > 0)
        {
            IsTimeFinished = false;
            PrintTimer();
        }
        if (currentCount <= 0)
        {
            Timer.Stop();
            IsTimeFinished = true;
            // Set a flag to True to move to the next question
        }
    }
    #endregion
}