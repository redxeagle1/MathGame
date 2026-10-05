namespace MathGame.GameQuestion;

public static class QuestionTimer 
/* this will be responsible for the following
    1. counting the specified timer per question
    2. printing the timer out to the user provide by a public static utility
    3. return a signal denoting that the timer is finished
    4. have a public prop to access that return the remaining time on demand
*/
{
    #region Fields
    private static DateTime _targetTime;
    private static int _lastPrintedTime;
    #endregion 
    
    ////////////////////
    
    #region Proberties

    public static int CountDown => _lastPrintedTime;
    private static int TimerLocationX { get; set; } 
    public static bool IsTimeFinished { get; set; }
    public static bool IsActive { get; private set; }

    #endregion
    
    ///////////////////
    
    #region Methods

    public static void StartTimer(int timerLocationX,int countdown)
    // set up the timer countdown
    {
        TimerLocationX = timerLocationX;
        // calculate the exact end time
        _targetTime = DateTime.Now.AddSeconds(countdown);
        _lastPrintedTime = countdown;
        
        IsTimeFinished = false;
        IsActive = true;
        
        
        PrintTimer(countdown);

    }

    public static void UpdateTimer()
    // update the timer countdown till the end
    {
        if (!IsActive)
        {
            return;
        }
        TimeSpan remainingTime =  _targetTime -DateTime.Now ;
        int currentPrintedTime = Convert.ToInt32(remainingTime.TotalSeconds);

        if (currentPrintedTime <= 0)
        {
            IsActive = false;
            IsTimeFinished = true;
            PrintTimer(currentPrintedTime);
            return;
        }
        
        
        if (currentPrintedTime < _lastPrintedTime)
            // update the timer
        {
            _lastPrintedTime = currentPrintedTime;
            PrintTimer(currentPrintedTime);
        }
        
    }
    private static void PrintTimer(int countdown)
    // print the timer to the user
    {
        int tempX = Console.CursorLeft;
        int tempY = Console.CursorTop;

        
        // move to the timer's location
        Console.SetCursorPosition(TimerLocationX,0);
        
        // update the countdown
        Console.Write($"Remaining Time: {countdown}".PadRight(25, ' '));
        Console.SetCursorPosition(tempX,tempY);
        
    }
    #endregion
}