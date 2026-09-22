using System;

namespace MathGame;

public class QuestionTF : Question<char>
{
    public QuestionTF(Problem problem) : base(problem)
    {
        _answer = new(problem);
        QuestionPrompt = GenerateQuestionText();
    }

    public override GameQuestionType QuestionType => GameQuestionType.TRUE_FALSE;

    public override string QuestionPrompt {get;}

    public override AnswerBase<char> Answer => _answer;


    #region fields
    private AnswerTF _answer;
    #endregion
    protected override string GenerateQuestionText()
    {
        string questionHeaderTypeHint = "Is This True or False ?";
        string questionCaption = $"\r\n{problem.FirstNum} {problem.Operation} {problem.SecondNum} = {_answer.AnswerContainer}";
        string questionAnswers =$"\r\n- True[t]\r\n- False[f]\r\n"; 
        return questionHeaderTypeHint + questionCaption + questionAnswers;
    }
}
