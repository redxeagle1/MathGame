namespace MathGame;

public readonly struct Problem
{
    public int FirstNum { get; }
    public int SecondNum { get;}
    public char Operation { get; }
    public int Answer { get; }
    private readonly GameDifficulty _difficulty;
    private byte Range
    {
        get => _difficulty switch 
        {
            GameDifficulty.EASY or GameDifficulty.HARD => 11,
            GameDifficulty.NORMAL or GameDifficulty.INSANE or GameDifficulty.IMPOSSIBLE => 101,    
            _ =>    throw new Exception()
        };
    }
    private readonly char[] _operation = ['+', '-', '*', '/'];
    public Problem(GameOperation operation,GameDifficulty difficulty)
    {
        _difficulty = difficulty;
        FirstNum = GenerateNumber();
        SecondNum = GenerateNumber();
        while (FirstNum % (double)SecondNum != 0 )
        {
            SecondNum = GenerateNumber();
        }
        Operation = GenerateOperation(operation);
        Answer = GetAnswer();
    }

    private readonly char GenerateOperation(GameOperation operation) => operation switch
    {
        GameOperation.ADDITION => _operation[0],
        GameOperation.SUBTRACTION => _operation[1],
        GameOperation.MULTIPLICATION => _operation[2],
        GameOperation.DIVISION => _operation[3],
        GameOperation.RANDOM => Random.Shared.GetItems(_operation, 1)[0],
        _ => throw new Exception()
    };

    private int GenerateNumber()
    {

        int sampleNum = Random.Shared.Next(0, Range);
        if (Operation == '/')
        {
            sampleNum = Random.Shared.Next(1, Range);
        }
        return sampleNum;
    }
    private readonly int GetAnswer() => Operation switch
    {
        '+'=> FirstNum + SecondNum,
        '-' => FirstNum - SecondNum,
        '*'=> FirstNum * SecondNum,
        '/' => FirstNum / SecondNum,    
        _ =>throw new Exception()
    };

}