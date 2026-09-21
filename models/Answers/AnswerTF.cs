namespace MathGame;

public class AnswerTF : AnswerBase<char>
{
    #region Properties
    // the type of question of which the answer hold
    public override GameQuestionType QuestionType => GameQuestionType.TRUE_FALSE;
    
    // the answer
    public bool StateAnswer=> Random.Shared.Next(2) == 0; // true if = 0 else if = 1
    
    // the wrong or correct answer in which it be displayed
    public int AnswerContainer{get;}
    #endregion

    #region Constructor
    public AnswerTF(Problem problem)
    {
        int answer = problem.Answer;
        if (StateAnswer)
        {
            AnswerContainer = answer;
            return;
        }
        int temp = Random.Shared.Next(answer/2,answer*2);
        AnswerContainer = ( temp == answer ) ? Random.Shared.Next(answer/2,answer) : temp;
    }
    #endregion

    #region Methods
    public override bool ValidateAnswer(char userInput)
    {
        // map userInput to boolean
        bool checkCorrectInput = userInput switch
        {
            't'=> true,
            'f'=> false,
            _ => throw new InvalidOperationException("received unknown input")
        };
        // validate
        return StateAnswer && checkCorrectInput;
    }
    #endregion

}