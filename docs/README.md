# about

## commit philosophy

I followed when committing Conventional Commits.Standard Commit Structure

```text
<type>[optional scope]: <description>
```

- Common Commit Types
  - feat: A new feature for the user.
  - fix: A bug fix for the user.
  - docs: Changes to the documentation.
  - style: Formatting, missing semi-colons, etc. (no production code changes).
  - refactor: Refactoring production code (neither fixing a bug nor adding a feature).
  - perf: Code changes that improve performance.
  - test: Adding missing tests or correcting existing tests.
  - build: Changes that affect the build system or external dependencies.
  - ci: Changes to CI configuration files and scripts.
  - chore: Other changes that don't modify src or test files.
  - revert: Reverts a previous commit.

## What I discovered and learned on top of my current knowledge

- `StringBuilder` and `ConsoleKeyInfo` input combination : at least now I know a new way of processing user input alongside with `Readline()` that would not pause the user execution but sure it super hard and easy to mess things up
- How to get the user's console size and utilize it for dictating some conditions like what I did
- How to set the default value of your Properties and I learned the hard way that properties cannot be passed by reference
- `"\a"` is the `Console.Beep()` cross-platform alt

## changelog

- refactor: added the boilerplate for the upcoming must to do tasks (September 1, 2026 at 8:25 PM)
- feat: constructed the main game logic and the user input processing and handling (September 1, 2026 at 8:20 PM)
- feat: added static main menu  (September 1, 2026 at 8:19 PM)
- refactor: added the needed fields and properties require to setup the main menu  (September 1, 2026 at 5:11 PM)
- docs[menu planning] : design the main menu and the 1st step of the project  (August 25, 2026 at 4:39 AM)
