
Console.Clear();
ConstructMainMenu(s_userValidMainOptions);
while (true)
{
    if (TryUpdateWindow(UserWindowWidth, UserWindowHeight, s_userValidMainOptions, out int nextX, out int nextY))
    {
        // Only update properties if the window actually resized
        UserWindowWidth = nextX;
        UserWindowHeight = nextY;
    }
    // to make sure that our next logic is executed correctly we need to excecute the following if the screen is valid
    if (CheckValidScreen())
    {
        if (Console.KeyAvailable) //  true if a key press is available;
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true hide the automatic key echoing
            Console.TreatControlCAsInput = false; // so to prevent accidental catch of the control 

            HandleUserInput(keyInfo);
        }
        // TODO: add the window switch mechanism 
        if (CurrentWindow == WINDOW_MAP[6])
        {
            return;
        }

    }
    Thread.Sleep(30);
}