namespace MathGame;

public readonly struct Problem
{

    #region fields
    private readonly GameDifficulty _difficulty;
    private readonly int _range ;
    private readonly char[] _operation = ['+', '-', '*', '/'];
    #endregion
    #region Properties
    public int FirstNum { get; }
    public char Operation { get; }
    public int SecondNum { get;}
    public int Answer { get; }
    #endregion

    public Problem(GameOptions options)
    {
        // set the difficulty
        _difficulty = options.Difficulty;
        
        // get the range
        _range = _difficulty switch
        {
            GameDifficulty.EASY or GameDifficulty.HARD => 11,
            GameDifficulty.NORMAL or GameDifficulty.INSANE or GameDifficulty.IMPOSSIBLE => 101,
            _ => throw new Exception()
        };


        Operation = GenerateOperation(options.Operation);
        
        // using tuples to assign multiple values at once [Didn't know that at first]
        (FirstNum,SecondNum,Answer ) = Operation switch
        {
            '+'=>GenerateAdditionProblem(),
            '-' => GenerateSubtractionProblem(),
            '*'=> GenerateMultiplicationProblem(),
            '/' => GenerateDivisionProblem(),    
            _ =>throw new InvalidOperationException("Unsupported operation")
        };
    }

    // get current operation
    private readonly char GenerateOperation(GameOperation operation) => operation switch
    {
        GameOperation.ADDITION => _operation[0],
        GameOperation.SUBTRACTION => _operation[1],
        GameOperation.MULTIPLICATION => _operation[2],
        GameOperation.DIVISION => _operation[3],
        // get a random index for the operation array ranged from 0 to Length
        GameOperation.RANDOM => _operation[Random.Shared.Next(_operation.Length)],
        _ => throw new ArgumentOutOfRangeException($"unknown {nameof(operation)} : {operation} type")
    };
   
    #region Problem Operands Generators
    private (int first,int second,int answer) GenerateAdditionProblem()
    {
        int first = Random.Shared.Next(0, _range);
        int second = Random.Shared.Next(0, _range);
        
        // return a tuple containing all the problem parts
        return (first,second,first+second);
    }
    private (int first,int second,int answer) GenerateSubtractionProblem()
    {
        int first = Random.Shared.Next(0, _range);
        int second = Random.Shared.Next(0, first-1); // to make sure it's alway positive
        
        
        // return a tuple containing all the problem parts
        return (first,second,first-second);
    }
    private (int first,int second,int answer) GenerateMultiplicationProblem()
    {
        int first = Random.Shared.Next(0, _range);
        int second = Random.Shared.Next(0, _range);


        // return a tuple containing all the problem parts
        return (first,second,first*second);
    }
    private (int first,int second,int answer) GenerateDivisionProblem()
    {
        // get the second operand
        int second = Random.Shared.Next(1, _range);

        // it's the maximum possible number to be generated 
        int maxMultiplayer = (_range-1)/ second;
        
        // using the multiplayer to a valid possible random answer
        int answer = Random.Shared.Next(0, maxMultiplayer + 1);
        
        // get the first operand from the second and the answer
        int first = second * answer;

        // return a tuple containing all the problem parts
        return (first,second,answer);
    }
    #endregion


}