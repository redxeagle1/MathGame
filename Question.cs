namespace MathGame;

public abstract class Question<T>(Problem problem)
{
    // the will hold our problem itself
    public Problem problem = problem;
    
    // to define the type Effectively
    public abstract GameQuestionType QuestionType{get;}
    // question prompt
    public abstract string QuestionPrompt{get;}

    // Answer Holder
    public abstract AnswerBase<T> Answer{get;} // note the T must be of the same type 
    



    // this method will use the Problem Object in Order to prepare the question text
    protected abstract string GenerateQuestionText();
}
