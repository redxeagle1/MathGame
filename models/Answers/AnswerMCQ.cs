namespace MathGame;
using System.Collections;
using System.Runtime.InteropServices;

public class AnswerMCQ : AnswerBase<char>, IEnumerable
{

    #region Fields
    // A list that contains our answers
    private readonly List<int> _answerList = new(4);

    // Important for using string.Join
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    #endregion

    #region Properties
    public override GameQuestionType QuestionType => GameQuestionType.MCQ;

    // Important for using string.Join
    public IEnumerator GetEnumerator() => _answerList.GetEnumerator();

        #region Indexer
            // indexer to iterate through the answers
            public int this[int index] => _answerList[index];
            public int AnswerIndex {get;set;}
        #endregion
    #endregion

    #region Constructor
    public AnswerMCQ(Problem problem)
    {
        int answer = problem.Answer;
        // add the main answer
        _answerList.Add(answer);

        // add the rest of the answers
        GenerateAnswerCandidates(answer);

        // shuffle the elements in place
        Random.Shared.Shuffle(CollectionsMarshal.AsSpan(_answerList));        
        AnswerIndex = _answerList.IndexOf(answer);
    }
    #endregion

    #region Methods
    private void GenerateAnswerCandidates(int a)
    // this method generate the keys and there values in the dictionary
    {
        // iterating through the given counter
        for (int i = 1; i < 4; i++)
        {
            // getting a temp value from a the non-negative range of possibilities 
            int temp = Random.Shared.Next(a/2,a*2);
            
            // if the generated integer happens to be already exist enter a loop of generation
            // till getting a value
            while (_answerList.Contains(temp))
            {
                temp = Random.Shared.Next(a/2,a*2);
            }    

            // after loop
            _answerList.Add(temp);
        }
    }

    
    // check if the answer is correct without mapping overhead 
    public override bool ValidateAnswer(char userInput) => (char)(AnswerIndex + 97) == userInput;
    #endregion

}