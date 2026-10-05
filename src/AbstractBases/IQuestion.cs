using MathGame.GameQuestion;

namespace MathGame.AbstractBases;

public interface IQuestion
{
    GameQuestionType QuestionType { get; }
    string QuestionPrompt { get; }
    bool CheckAnswer(string userInput);
}