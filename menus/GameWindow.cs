using MathGame.models;
using MathGame.models.Answers;
using MathGame.models.Questions;
using MathGame.utils;

namespace MathGame.menus;

public class GameWindow : WindowBase
{
    public override string ValidOptions => "";
    public override int CurrentErrorLocation  => 20;
    // Knowing that this is a workaround and probably a very bad practise I couldn't think
    // of other way to store and reuse the question and it's answer
    
    public override WindowMap ProcessInput(string userInput)
    {
        throw new NotImplementedException();
    }

    public override void Render()
    {
        throw new NotImplementedException();
    }
}