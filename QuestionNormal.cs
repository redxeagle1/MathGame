namespace MathGame;

public class QuestionNormal : Question<string>
{
    public QuestionNormal(Problem problem) : base(problem)
    {
        _answer =new(problem);
        QuestionPrompt = GenerateQuestionText();
    }

    public override GameQuestionType QuestionType =>GameQuestionType.NORMAL;

    public override string QuestionPrompt {get;}

    public override AnswerBase<string> Answer => _answer;

    private AnswerNormal _answer;
    protected override string GenerateQuestionText()
    {
        string questionHeaderTypeHint = "What Is The Output Of The Following Problem ?";
        string questionCaption = $"\r\n{problem.FirstNum} {problem.Operation} {problem.SecondNum} = ?";
        string questionAnswers = ""; 
        return questionHeaderTypeHint + questionCaption + questionAnswers;
    }
}
