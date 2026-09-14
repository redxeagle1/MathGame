namespace MathGame;

public abstract class WindowBase
// A generic class to hold all the windows and unifying the handling for modularity and simplicity
{
    // a string to set the active valid option buffer
    public abstract string ValidOptions {get;}

    // an int to specify the current error location for InputHandler error utility
    public abstract int CurrentErrorLocation {get;}


    // the method to draw and construct the current window
    public abstract void Render();

    // method to process the user's option if they enters [a,b,c] based on the active valid options
    public abstract WindowMap ProcessInput(string userInput);
}
