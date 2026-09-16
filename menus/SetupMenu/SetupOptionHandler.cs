namespace MathGame.menus.SetupMenu
{
    internal static class SetupOptionHandler
    {
        public static bool SetQuestionOptions(string userInput,ref GameOptions options)
        {
            if (options.Difficulty == GameDifficulty.NONE)
            {
                options.Difficulty = SetGameDifficulty(userInput);
            }
            else if (options.Operation == GameOperation.NONE)
            {
                options.Operation = SetGameOperation(userInput);
            }
            else if (options.QuestionType == GameQuestionType.NONE)
            {
                options.QuestionType = SetGameQuestionType(userInput);
                // to indicate that the all options is set
                if (options.QuestionType != GameQuestionType.NONE)
                {
                    return true;
                }
            }
            return false;
        }
        public static void RenderQuestionsSetup(ref GameOptions options)
        {
            string infoPanel = $"Difficulty : {options.Difficulty}\t\tOperation : {options.Operation}\t\tQuestion Type : {options.QuestionType}";
            if (options.Difficulty == GameDifficulty.NONE)
            {
                RenderDifficultyOptions();
            }
            else if (options.Operation == GameOperation.NONE)
            {
                RenderOperationOptions();
            }
            else if (options.QuestionType == GameQuestionType.NONE)
            {
                RenderQuestionTypeOptions();
            }
            // an info panel to display the selection summary
            Console.Write("\r\n");
            Console.WriteLine($"{infoPanel}\r\n");
        }


        private static void RenderDifficultyOptions()
        {
            Console.Write("\tchoose a difficulty}\r\n");
            Console.Write("\t\ta. easy (digits from 0 to 10)}\r\n");
            Console.Write("\t\tb. normal (digits from 0 to 100)}\r\n");
            Console.Write("\t\tc. hard (digits from 0 to 10 + TIMED 10s)}\r\n");
            Console.Write("\t\td. insane (digits from 0 to 100 + TIMED 10s and 15s if random operation)}\r\n");
            Console.Write("\t\te. impossible (digits from 0 to 100 + TIMED 5s and 10s if random operation)}\r\n");
        }
        private static void RenderOperationOptions()
        {
            Console.Write("\tchoose the operation}\r\n");
            Console.Write($"\t\ta. addition (+)\r\n");
            Console.Write($"\t\tb. subtraction (-)\r\n");
            Console.Write($"\t\tc. multiplication (x)\r\n");
            Console.Write($"\t\td. division (÷)\r\n");
            Console.Write($"\t\te. random operation\r\n");
        }
        private static void RenderQuestionTypeOptions()
        {
            Console.Write("\tchoose the question type\r\n");
            Console.Write("\t\ta. MCQ\r\n");
            Console.Write("\t\tb. true or false\r\n");
            Console.Write("\t\tc. fill the gaps\r\n");
            Console.Write("\t\td. normal\r\n");
            Console.Write("\t\te. random\r\n");
        }
        private static GameDifficulty SetGameDifficulty(string userInput) => userInput switch
        // these method return a difficulty based on the input 
        {
            "a" => GameDifficulty.EASY,
            "b" => GameDifficulty.NORMAL,
            "c" => GameDifficulty.HARD,
            "d" => GameDifficulty.INSANE,
            "e" => GameDifficulty.IMPOSSIBLE,
            _ => GameDifficulty.NONE
        };
        private static GameOperation SetGameOperation(string userInput) => userInput switch
        // these method return a Operation based on the input 
        {
            "a" => GameOperation.ADDITION,
            "b" => GameOperation.SUBTRACTION,
            "c" => GameOperation.MULTIPLICATION,
            "d" => GameOperation.DIVISION,
            "e" => GameOperation.RANDOM,
            _ => GameOperation.NONE
        };
        private static GameQuestionType SetGameQuestionType(string userInput) => userInput switch
        // these method return a QuestionType based on the input 
        {
            "a" => GameQuestionType.MCQ,
            "b" => GameQuestionType.TRUE_FALSE,
            "c" => GameQuestionType.FILL_GAPS,
            "d" => GameQuestionType.NORMAL,
            "e" => GameQuestionType.RANDOM,
            _ => GameQuestionType.NONE
        };
        public static void ResetOptions(ref GameOptions options)
        {
            options.Difficulty = GameDifficulty.NONE;
            options.Operation = GameOperation.NONE;
            options.QuestionType = GameQuestionType.NONE;
        }
    }
}
