namespace MathGame;

public class AnswerNormal(Problem problem) : AnswerBase<string>
{

    public override GameQuestionType QuestionType => GameQuestionType.NORMAL;
    public int CorrectAnswer { get; } = problem.Answer;

    public override bool ValidateAnswer(string userInput)
    {
        return int.Parse(userInput) == CorrectAnswer;
    }
}