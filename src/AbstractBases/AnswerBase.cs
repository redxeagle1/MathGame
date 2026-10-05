using MathGame.GameQuestion;

namespace MathGame.AbstractBases;

public abstract class AnswerBase<T>
{
    // Store the question Type Itself
    public abstract GameQuestionType QuestionType {get;}



    // Validate the Answer either with a string or a char
    public abstract bool ValidateAnswer(T userInput);

}