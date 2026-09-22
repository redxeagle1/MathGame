namespace MathGame;

public class QuestionNormal : Question<string>
{
    public QuestionNormal(Problem problem) : base(problem)
    {
        _answer =new(problem);
        QuestionPrompt =  QuestionHeaderTypeHint + QuestionCaption + QuestionAnswers ;
    }

    public override GameQuestionType QuestionType =>GameQuestionType.NORMAL;

    public override string QuestionPrompt {get;}

    public override AnswerBase<string> Answer => _answer;

    protected override string? QuestionHeaderTypeHint => "What Is The Output Of The Following Problem ?";

    protected override string? QuestionCaption => $"\r\n{problem.FirstNum} {problem.Operation} {problem.SecondNum} = ?";

    protected override string? QuestionAnswers => "";

    private readonly AnswerNormal _answer;

}
