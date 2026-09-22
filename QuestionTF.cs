using System;

namespace MathGame;

public class QuestionTF : QuestionBase<char>
{
    public QuestionTF(Problem problem) : base(problem)
    {
        _answer = new(problem);
        QuestionPrompt =  QuestionHeaderTypeHint + QuestionCaption + QuestionAnswers ;
    }

    public override GameQuestionType QuestionType => GameQuestionType.TRUE_FALSE;

    public override string QuestionPrompt {get;}

    public override AnswerBase<char> Answer => _answer;

    protected override string? QuestionHeaderTypeHint => "Is This True or False ?";

    protected override string? QuestionCaption => $"\r\n{problem.FirstNum} {problem.Operation} {problem.SecondNum} = {_answer.AnswerContainer}";

    protected override string? QuestionAnswers => $"\r\n- True[t]\r\n- False[f]\r\n";


    #region fields
    private readonly AnswerTF _answer;
    #endregion

}
