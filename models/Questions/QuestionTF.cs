using MathGame.models.Answers;

namespace MathGame.models.Questions;

public class QuestionTf : QuestionBase<char>
{
    public QuestionTf(Problem problem) : base(problem)
    {
        _answer = new(problem);
        QuestionPrompt =  QuestionHeaderTypeHint + QuestionCaption + QuestionAnswers ;
    }

    public override GameQuestionType QuestionType => GameQuestionType.TrueFalse;

    public override string QuestionPrompt {get;}

    public override AnswerBase<char> Answer => _answer;

    protected override string? QuestionHeaderTypeHint => "Is This True or False ?";

    protected override string? QuestionCaption => $"\r\n{Problem.FirstNum} {Problem.Operation} {Problem.SecondNum} = {_answer.AnswerContainer}";

    protected override string? QuestionAnswers => $"\r\n- True[t]\r\n- False[f]\r\n";


    #region fields
    private readonly AnswerTf _answer;
    #endregion

}
