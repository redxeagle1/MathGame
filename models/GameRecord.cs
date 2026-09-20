namespace MathGame;
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

