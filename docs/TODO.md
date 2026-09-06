## Short-Term Goals<!-- markdownlint-disable-line MD041 -->

### short-term goals for sunday (September 6rd)

- [x] **Handle User Menu Input** finish the `TryHandleMenuOptions()` method which will handle what the user will type which will switch the `CurrentWindow` Property to the targeted window
- [x] **URGENT** update the way of handling valid user options field to have only 1 field and it's counter so you always update the option on the fly and add extra ones
- [x] **Make A Struct That Will Store The Game History** add a new struct calling it `GameRecord` then define a constructor for easy initialization and add a `s_gameHistory` field in `Program.fields.cs` that is array of that struct
- [x] **Implement The Window Switch Mechanics** in the current empty `SwitchWindows()` to switch windows in using `CurrentWindow` Property and the `WindowMap` Enum to perform such operation

#### bonus

- [ ] **Implement The _Static_ Setup Window** define the main structure of the setup menu that will define how the game should behave in the `ConstructSetupMenu()` in `Program.Function.Menu.cs`
- [ ] **Add Small Indicator To Tell The Current Window** Just a method that will like be in the `TryUpdateWindow()` in the `Program.Functions.GameLogic.cs` this will ether be displayed in the top-right side or bottom right side of current window to indicate the current menu

------------------------------------------------------------------------------------------

### short-term goals for thursday (September 3rd)

> I asked gemini to seek what I can do next because I hit a rock implementing error handling and asked him to generate TODO list for me

- [x] **Fix Cursor Dislocation & Error Ghosting:** Update `ShowErrorMessage` to save `Console.CursorLeft` and `Console.CursorTop` before moving the cursor. Use `.PadRight(Console.WindowWidth)` on the error string and print it using `Console.Write` instead of `WriteLine` to avoid line breaks. Finally, restore the cursor to its saved coordinates so the user can continue typing seamlessly.
- [x] **Clear Errors on Valid Input:** Modify `TryHandleInputKeys` so that when a valid key is pressed, it clears any active errors by calling `ShowErrorMessage("", MENU_ERROR_PLACEMENT)` and explicitly sets `IsInputWrong` and `IsHandlingFailed` to `false`.
- [x] **Implement Enum for State Management:** Replace the `WINDOW_MAP` string array with an `enum` (e.g., `enum MenuState`) to handle application routing safely. Update the window switch mechanisms to evaluate against this enum instead of hardcoded string indices like `WINDOW_MAP[6]`.
- [x] **Simplify Buffer Check:** Rewrite `CheckOngoingInputBuffer` in `Program.Functions.Utilities.cs` to simply evaluate and return `string.IsNullOrEmpty(buffer)`.

#### bonus goal for that day

_**NONE**_

## Core Feature Implementation

- [ ] **Build the Main Menu**
  - [x] Complete the `ConstructMainMenu()` method used to build the main menu
  - [ ] finish user input processing and handling pipeline
    - [x] finish Error handling mechanism
    - [ ] finish input processing mechanism
    - [x] finish input handling mechanism
  - [ ] implement Window switching mechanism
  - [x] implement window update mechanism

- [ ] **Build the Setup Menu:** Complete the empty `ConstructSetupMenu()` method to display the exact configuration interface for difficulty, operation, and question type outlined in your planning document.
- [ ] **Develop Math Generation Logic:** Create a robust method to generate math equations based on the user's selected difficulty and operation. Ensure the division logic strictly calculates integers only and uses dividends ranging from 0 to 100.
- [ ] **Implement the Core Game Loop:** Build the `GAME_WINDOW` state to iterate through a minimum of 5 questions per game, collect user answers, evaluate correctness, and accumulate points.
- [ ] **Track Game History:** Create a generic `List` to record the results of previous game sessions. Implement the `HISTORY_WINDOW` logic to display this list to the user when they select option 'B' from the main menu.
- [ ] **Integrate the Game Timer:** Add a `Stopwatch` or similar timing mechanism to track the elapsed time for a full game session. Tie this timing system into the logic for the "hard," "insane," and "impossible" difficulty modifiers, which require strict 5, 10, or 15-second limits.
- [ ] **Add "Random Game" Logic:** Implement the logic for the random operation selection, ensuring it dynamically switches between addition, subtraction, multiplication, and division for each individual question presented to the user.
