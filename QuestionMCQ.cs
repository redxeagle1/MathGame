namespace MathGame;

public class QuestionMCQ : QuestionBase<char>
{
    public QuestionMCQ(Problem problem) : base(problem)
    {
        _answer = new(problem);
        QuestionPrompt = QuestionHeaderTypeHint + QuestionCaption + QuestionAnswers ;
    }

    private readonly AnswerMCQ _answer;
    public override GameQuestionType QuestionType => GameQuestionType.MCQ;

    public override string QuestionPrompt {get;}
    public override AnswerBase<char> Answer => _answer;

    protected override string? QuestionHeaderTypeHint => "Choose the Correct Answer";

    protected override string? QuestionCaption => $"\r\n{problem.FirstNum} {problem.Operation} {problem.SecondNum} = ?";

    protected override string? QuestionAnswers => $"\r\na) {_answer[0]}\r\nb) {_answer[1]}\r\nc) {_answer[2]}\r\nd) {_answer[3]}\r\n";

}
