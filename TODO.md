> I asked gemini to seek what I can do next because I hit a rock implementing error handling and asked him to generate TODO list for me<!-- markdownlint-disable-line MD041 -->

## Code Refactoring & Immediate Fixes <!-- markdownlint-disable-line MD041 -->

- [ ] **Fix Cursor Dislocation & Error Ghosting:** Update `ShowErrorMessage` to save `Console.CursorLeft` and `Console.CursorTop` before moving the cursor. Use `.PadRight(Console.WindowWidth)` on the error string and print it using `Console.Write` instead of `WriteLine` to avoid line breaks. Finally, restore the cursor to its saved coordinates so the user can continue typing seamlessly.
- [ ] **Clear Errors on Valid Input:** Modify `TryHandleInputKeys` so that when a valid key is pressed, it clears any active errors by calling `ShowErrorMessage("", MENU_ERROR_PLACEMENT)` and explicitly sets `IsInputWrong` and `IsHandlingFailed` to `false`.
- [ ] **Clear Errors on Backspace:** Update the `ConsoleKey.Backspace` case in `HandleUserInput` to also call `ShowErrorMessage("", MENU_ERROR_PLACEMENT)` and reset both error booleans to `false` when the user deletes their mistake.
- [ ] **Implement Enum for State Management:** Replace the `WINDOW_MAP` string array with an `enum` (e.g., `enum MenuState`) to handle application routing safely. Update the window switch mechanisms to evaluate against this enum instead of hardcoded string indices like `WINDOW_MAP[6]`.
- [ ] **Simplify Buffer Check:** Rewrite `CheckOngoingInputBuffer` in `Program.Functions.Utilities.cs` to simply evaluate and return `string.IsNullOrEmpty(buffer)`.

## Core Feature Implementation

- [ ] **Build the Setup Menu:** Complete the empty `ConstructSetupMenu()` method to display the exact configuration interface for difficulty, operation, and question type outlined in your planning document.
- [ ] **Develop Math Generation Logic:** Create a robust method to generate math equations based on the user's selected difficulty and operation. Ensure the division logic strictly calculates integers only and uses dividends ranging from 0 to 100.
- [ ] **Implement the Core Game Loop:** Build the `GAME_WINDOW` state to iterate through a minimum of 5 questions per game, collect user answers, evaluate correctness, and accumulate points.
- [ ] **Track Game History:** Create a generic `List` to record the results of previous game sessions. Implement the `HISTORY_WINDOW` logic to display this list to the user when they select option 'B' from the main menu.
- [ ] **Integrate the Game Timer:** Add a `Stopwatch` or similar timing mechanism to track the elapsed time for a full game session. Tie this timing system into the logic for the "hard," "insane," and "impossible" difficulty modifiers, which require strict 5, 10, or 15-second limits.
- [ ] **Add "Random Game" Logic:** Implement the logic for the random operation selection, ensuring it dynamically switches between addition, subtraction, multiplication, and division for each individual question presented to the user.
