
namespace MathGame;

public class QuestionFillGaps : Question<string>
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
    }

    public override GameQuestionType QuestionType => GameQuestionType.FILL_GAPS;

    public override string QuestionPrompt => GenerateQuestionText();

    public override AnswerBase<string> Answer => _answer;
    private AnswerFillGap _answer;
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
    protected override string GenerateQuestionText()
    {
        string questionHeaderTypeHint = "Fill The Gaps";
        string questionCaption = $"\r\n{GetQuestionCaption()}= {problem.Answer}";
        string questionAnswers = $"\r\nWhat must be written to satisfy the problem?";
        return questionHeaderTypeHint + questionCaption + questionAnswers;
    }
}
