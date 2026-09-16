namespace MathGame;

public class QuitWindow :  WindowBase
{
    public override string ValidOptions { get; set; } = "";
    public override int CurrentErrorLocation { get; set; } = 0;

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
