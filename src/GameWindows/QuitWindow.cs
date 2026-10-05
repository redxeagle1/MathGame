using MathGame.AbstractBases;

namespace MathGame.GameWindows;

public class QuitWindow :  WindowBase
{
    public override string ValidOptions  => "";
    public override int CurrentErrorLocation => 0;

    public override WindowMap ProcessInput(string userInput)
    {
        return WindowMap.None;
    }

    public override void Render()
    {
        Console.WriteLine("Goodbye");
        Thread.Sleep(1000);
    }
}
