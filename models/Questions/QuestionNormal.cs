using MathGame.models.Answers;

namespace MathGame.models.Questions;

public class QuestionNormal : QuestionBase<string>
{
    public QuestionNormal(Problem problem) : base(problem)
    {
        _answer =new(problem);
        QuestionPrompt =  QuestionHeaderTypeHint + QuestionCaption + QuestionAnswers ;
    }

    public override GameQuestionType QuestionType =>GameQuestionType.Normal;

    public override string QuestionPrompt {get;}

    public override AnswerBase<string> Answer => _answer;

    protected override string? QuestionHeaderTypeHint => "What Is The Output Of The Following Problem ?";

    protected override string? QuestionCaption => $"\r\n{Problem.FirstNum} {Problem.Operation} {Problem.SecondNum} = ?";

    protected override string? QuestionAnswers => "";

    private readonly AnswerNormal _answer;

}
