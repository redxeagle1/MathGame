using MathGame.models.Answers;

namespace MathGame.models.Questions;

public class QuestionMcq : QuestionBase<char>
{
    public QuestionMcq(Problem problem) : base(problem)
    {
        _answer = new(problem);
        QuestionPrompt = QuestionHeaderTypeHint + QuestionCaption + QuestionAnswers ;
    }

    private readonly AnswerMcq _answer;
    public override GameQuestionType QuestionType => GameQuestionType.Mcq;

    public override string QuestionPrompt {get;}
    public override AnswerBase<char> Answer => _answer;

    protected override string? QuestionHeaderTypeHint => "Choose the Correct Answer";

    protected override string? QuestionCaption => $"\r\n{Problem.FirstNum} {Problem.Operation} {Problem.SecondNum} = ?";

    protected override string? QuestionAnswers => $"\r\na) {_answer[0]}\r\nb) {_answer[1]}\r\nc) {_answer[2]}\r\nd) {_answer[3]}\r\n";

}
