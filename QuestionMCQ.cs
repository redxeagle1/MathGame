namespace MathGame;

public class QuestionMCQ : Question<char>
{
    public QuestionMCQ(Problem problem) : base(problem)
    {
        _answer = new(problem);
        QuestionPrompt = GenerateQuestionText();
    }

    private AnswerMCQ _answer;
    public override GameQuestionType QuestionType => GameQuestionType.MCQ;

    public override string QuestionPrompt {get;}
    public override AnswerBase<char> Answer => _answer;

    protected override string GenerateQuestionText()
    {
        string questionHeader = "Choose the Correct Answer";
        string questionCaption = $"\r\n{problem.FirstNum} {problem.Operation} {problem.SecondNum} = ?";
        string questionAnswers =$"\r\na) {_answer[0]}\r\nb) {_answer[1]}\r\nc) {_answer[2]}\r\nd) {_answer[3]}\r\n"; 
        return questionHeader + questionCaption +questionAnswers ;
    }
}
