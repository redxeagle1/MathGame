using MathGame.models;

namespace MathGame;

public interface IQuestion
{
    GameQuestionType QuestionType { get; }
    string QuestionPrompt { get; }
    bool CheckAnswer(string userInput);
}