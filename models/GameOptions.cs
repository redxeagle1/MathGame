public enum GameDifficulty : byte {NONE,EASY,NORMAL,HARD,INSANE,IMPOSSIBLE,}

public enum GameOperation : byte {NONE,ADDITION,SUBTRACTION,MULTIPLICATION,DIVISION,RANDOM}
public enum GameQuestionType : byte {NONE,MCQ,TRUE_FALSE,FILL_GAPS,NORMAL,RANDOM,}
public struct GameOptions
{
    public GameOptions()
    {
        
    }

// this is for holding our selected options
    public GameDifficulty Difficulty {get;set;}= GameDifficulty.NONE;
    public GameOperation Operation {get;set;}= GameOperation.NONE;
    public GameQuestionType QuestionType {get;set;} = GameQuestionType.NONE;
}