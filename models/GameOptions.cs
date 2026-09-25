namespace MathGame.models;
public enum GameDifficulty : byte {None,Easy,Normal,Hard,Insane,Impossible,}

public enum GameOperation : byte {None,Addition,Subtraction,Multiplication,Division,Random}
public enum GameQuestionType : byte {None,Mcq,TrueFalse,FillGaps,Normal,Random,}
public struct GameOptions
{
    public GameOptions()
    {
        
    }

// this is for holding our selected options
    public GameDifficulty Difficulty {get;set;}= GameDifficulty.None;
    public GameOperation Operation {get;set;}= GameOperation.None;
    public GameQuestionType QuestionType {get;set;} = GameQuestionType.None;
}