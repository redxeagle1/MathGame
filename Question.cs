namespace MathGame;

public abstract class Question
{
    public abstract string QuestionText{get;}
    // public ProblemSetup problem = new();
    // public abstract string GenerateQuestion()
    
    // this method will use the Problem Object in Order to prepare the question text
    
    public abstract string GenerateQuestionText();
    // public abstract 

}
