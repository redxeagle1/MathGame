using System;

namespace MathGame;

public enum GameDifficulty : byte {EASY,NORMAL,HARD,INSANE,IMPOSSIBLE,}

public enum GameOperation : byte {ADDITION,SUBTRACTION,MULTIPLICATION,DIVISION,RANDOM}
public enum GameQuestionType : byte {MCQ,TRUE_FALSE,FILL_GAPS,NORMAL,RANDOM,}
public struct GameRecord(int id,
                  DateTime startTime,
                  short questions,
                  short score,
                  GameDifficulty diff,
                  GameQuestionType qType,
                  GameOperation op,
                  TimeSpan time)
{
    public int Id = id;
    public DateTime StartTime = startTime;
    public TimeSpan TotalTime = time;
    public short TotalNumberOfQuestions = questions;
    public short TotalScore = score;
    public GameDifficulty Difficulty = diff;
    public GameOperation OperationType = op;
    public GameQuestionType QuestionType = qType;
}

// this is for holding our selected options
public struct GameOptions
{
    public GameOptions()
    {
        
    }

    public GameDifficulty Difficulty {get;set;}= GameDifficulty.EASY;
    public GameOperation Operation {get;set;}= GameOperation.ADDITION;
    public GameQuestionType QuestionType {get;set;} = GameQuestionType.MCQ;
}