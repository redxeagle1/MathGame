using MathGame.models;

namespace MathGame.Interfaces;

public interface IQuestion
{
    GameQuestionType QuestionType { get; }
    string QuestionPrompt { get; }
    bool CheckAnswer(string userInput);
}