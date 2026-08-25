public partial class Program
{
    static void ShowMainMenu()
    {
        string[] menu = [
            "A. Start the game",
            "B. Settings",
            "C. Help"
        ];
        WriteLine(string.Join("\r\n", menu));
    }
}
