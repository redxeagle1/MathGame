namespace MathGame;

public class AnswerTF 

{
    #region Fields
    #endregion
    #region Properties
    public int WrongAnswer{get;}
    public int CorrectAnswer{get;}
    #endregion
    #region Constructor
    public AnswerTF(int answer)
    {
        CorrectAnswer = answer;
        int temp = Random.Shared.Next(answer/2,answer*2);
        WrongAnswer = ( temp == answer ) ? Random.Shared.Next(answer/2,answer) : temp;
    }
    #endregion
    #region Methods

    #endregion

}
// an struct for The MCQ question type
