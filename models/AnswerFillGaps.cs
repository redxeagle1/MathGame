namespace MathGame;

public class AnswerFillGaps
// this will pick one of the the operands, the operator to be the answer
{
    // this will store our current problem
    private int[] _operationList = new int[3];

    #region Fields
    #endregion
    #region Properties
    public int TargetGabAnswer{get;} // this will store the target gap's answer
    public int TargetGabIndex{get;} // this will store the gap's index
    #endregion
    
    
    #region Constructor
    public AnswerFillGaps(Problem problem)
    {
        _operationList = [problem.FirstNum,problem.Operation,problem.SecondNum];
        TargetGabAnswer = GetTheTargetGapValue();
        TargetGabIndex = GetTheTargetGapIndex();
    }

    #endregion
    
    
    
    #region Methods
    private int GetTheTargetGapValue()
    // get the target's Value
    {
        int gap = Random.Shared.GetItems(_operationList,1)[0];
        return gap;
    }
    private int GetTheTargetGapIndex()
    {
        int gapIndex = _operationList.IndexOf(TargetGabAnswer);
        return gapIndex;
    }

    #endregion

}
