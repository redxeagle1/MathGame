using MathGame;
Console.Clear();
// ConstructMainMenu(s_activeOptionBuffer); //TODO: uncomment that 
CurrentWindow = WindowMap.SETUP_MENU;
SwitchWindows();
// Track the state so we know when to trigger a redraw
WindowMap prevWindow = CurrentWindow;
while (true)
{
    if (TryUpdateWindow(UserWindowWidth, UserWindowHeight, prevWindow, s_activeOptionBuffer, out int nextX, out int nextY))
    {
        // Only update properties if the window actually resized
        UserWindowWidth = nextX;
        UserWindowHeight = nextY;
        prevWindow = CurrentWindow;
    }
    if (CurrentWindow == WindowMap.QUIT_BANNER)
    {
        return;
    }
    // to make sure that our next logic is executed correctly we need to execute the following if the screen is valid
    // if (CheckValidScreen())
    // {
    //     if (Console.KeyAvailable) //  true if a key press is available;
    //     {
    //         ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true hide the automatic key echoing
    //         Console.TreatControlCAsInput = false; // so to prevent accidental catch of the control 

    //         HandleUserInput(keyInfo);
    //     }
    // }
}
