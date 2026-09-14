using System;

namespace MathGame;

public class QuitWindow :  WindowBase
{
    public override int CurrentErrorLocation => 0;

    public override string ValidOptions => "";

    public override WindowMap ProcessInput(string userInput)
    {
        return WindowMap.NONE;
    }

    public override void Render()
    {
        Console.WriteLine("Goodbye");
        Thread.Sleep(1000);
    }
}
