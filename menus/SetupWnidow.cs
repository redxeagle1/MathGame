using System;

namespace MathGame;

public class SetupWindow : WindowBase
{
    public override string ValidOptions => throw new NotImplementedException();

    public override int CurrentErrorLocation => throw new NotImplementedException();

    public override WindowMap ProcessInput(string userInput)
    {
        throw new NotImplementedException();
    }

    public override void Render()
    {
        throw new NotImplementedException();
    }
}

/*
 static void ConstructSetupMenu()
    {
        // to set
        CurrentWindow = WindowMap.SETUP_MENU;
        SetActiveOptions="abcdew";
        // CurrentErrorLocation = 24; // validate it
        string Choose = "Choose From The Following Options:";
        Console.Write($"{Choose}\tX:{Choose.Length}\tY:{Console.CursorTop}\r\n");
        Console.Write("\r\n");
        ConstructQuestionOptions();
        Console.Write("Type hints\r\n");
        string hintSelection = $"- type a letter from [{string.Join(", ", s_activeOptionBuffer)}]\r\n- to go back to main menu [q]\r\n- type [w] to wipe all selections\r\n- press [ctrl+c] to hard exit";
        Console.Write(hintSelection + $"\tY:{Console.CursorTop}\r\n");
        string askForInput = "\r\nType your answer : \t";
        Console.Write(askForInput + Console.CursorTop);

    }
    static void ConstructQuestionOptions()
    {
        // TODO: Separate this method into a method for each set of condition 
        // TODO: Add the handling of these questions and swapping in another method
        string infoPanel = $"Difficulty : {gameOptions.Difficulty}\t\tOperation : {gameOptions.Operation}\t\tQuestion Type : {gameOptions.QuestionType}";
        if (gameOptions.Difficulty == GameDifficulty.NONE)
        {
            Console.Write($"{"\tchoose a difficulty"}\tX:{"\tchoose a difficulty".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\ta. easy (digits from 0 to 10)"}\tX:{"\t\ta. easy (digits from 0 to 10)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\tb. normal (digits from 0 to 100)"}\tX:{"\t\tb. normal (digits from 0 to 100)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\tc. hard (digits from 0 to 10 + TIMED 10s)"}\tX:{"\t\tc. hard (digits from 0 to 10 + TIMED 10s)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\td. insane (digits from 0 to 100 + TIMED 10s and 15s if random operation)"}\tX:{"\t\td. insane (digits from 0 to 100 + TIMED 10s and 15s if random operation)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\te. impossible (digits from 0 to 100 + TIMED 5s and 10s if random operation)"}\tX:{"\t\te. impossible (digits from 0 to 100 + TIMED 5s and 10s if random operation)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write("\r\n");
            Console.Write("\r\n");
        }
        else if (gameOptions.Operation == GameOperation.NONE)
        {
            ClearQuestionOptions();
            Console.Write($"{"\tchoose the operation"}\tX:{"\tchoose the operation".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\ta. addition (+)"}\tX:{"\t\ta. addition (+)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\tb. subtraction (-)"}\tX:{"\t\tb. subtraction (-)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\tc. multiplication (x)"}\tX:{"\t\tc. multiplication (x)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\td. division (÷)"}\tX:{"\t\td. division (÷)".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\te. random operation"}\tX:{"\t\te. random operation".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write("\r\n");
            Console.Write("\r\n");
        }
        else if (gameOptions.QuestionType == GameQuestionType.NONE)
        {
            ClearQuestionOptions();
            Console.Write($"{"\tchoose the question type"}\tX:{"\tchoose the question type".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\ta. MCQ"}\tX:{"\t\ta. MCQ".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\tb. true or false"}\tX:{"\t\tb. true or false".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\tc. fill the gaps"}\tX:{"\t\tc. fill the gaps".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\td. normal"}\tX:{"\t\td. normal".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write($"{"\t\te. random"}\tX:{"\t\te. random".Length}\tY:{Console.CursorTop}\r\n");
            Console.Write("\r\n");
            Console.Write("\r\n");
        }
        Console.WriteLine($"{infoPanel}\tX:{infoPanel.Length}\tY:{Console.CursorTop}");
        Console.Write("\r\n");
        Console.Write("\r\n");
    }
    static void ClearQuestionOptions()
    {
        // Save the current cursor position to go back to it 
        int oldX = Console.CursorLeft;
        int oldY = Console.CursorTop;

        // a loop from 2 to 7 to over-write all the text in these specific locations
        for (int i = 2; i < 8; i++)
        {
            Console.SetCursorPosition(0,i);
            Console.Write(" ".PadRight(Console.WindowWidth));
        }
        // Set the cursor back to the position 
        Console.SetCursorPosition(oldX,oldY);
    }
*/