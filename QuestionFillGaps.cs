
namespace MathGame;

public class QuestionFillGaps : QuestionBase<string>
{
    public QuestionFillGaps(Problem problem) : base(problem)
    {
        _answer = new(problem);
        _problemList =
        [
            problem.FirstNum.ToString(),
            problem.Operation.ToString(),
            problem.SecondNum.ToString(),
        ];
        QuestionPrompt = QuestionHeaderTypeHint +QuestionCaption + QuestionAnswers;
    }

    public override GameQuestionType QuestionType => GameQuestionType.FILL_GAPS;

    public override string QuestionPrompt{get;}

    public override AnswerBase<string> Answer => _answer;

    protected override string? QuestionHeaderTypeHint => "Fill The Gaps";

    protected override string? QuestionCaption => $"\r\n{GetQuestionCaption()}= {problem.Answer}";

    protected override string? QuestionAnswers => $"\r\nWhat must be written to satisfy the problem?";

    private readonly AnswerFillGap _answer;
    private string[] _problemList = new string[3];


    private string GetQuestionCaption()
    {
        string temp = "";
        for (int i = 0; i < 3; i++)
        {
            temp += _answer.TargetGabIndex == i ? "?" : $"{_problemList[i]}";
            temp += " ";
        }

        return temp;
    }
}
