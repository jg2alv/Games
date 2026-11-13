# Games: C# console-game prototypes

Games is a collection of classic game prototypes written in C#. Each game is a separate console application targeting .NET Core 3.1.

## 1. Projects

| Directory | Focus |
| --- | --- |
| `TicTacToe/` | Numbered board input and alternating X/O turns |
| `Hangman/` | Letter guessing, hidden sentences, and a seven-failure limit |
| `Snake/` | WASD movement, body segments, food, growth, and collision logic |
| `SpaceInvaders/` | A/D movement, space-bar shooting, enemy spawning, and score code |
| `Chess/` | Colored board rendering, coordinate input, piece movement, and captures |

## 2. Requirements

The project files target `netcoreapp3.1`. Use an appropriate .NET environment and an interactive terminal that supports cursor positioning and console colors. No game engine or external package references are included in the project files.

## 3. Usage

Choose a project and launch its console application, for example:

```sh
dotnet run --project TicTacToe/TicTacToe.csproj
```

Snake uses W/A/S/D. Space Invaders uses A/D and the space bar. Tic-Tac-Toe, Hangman, and Chess prompt for text input.

## 4. License

MIT. See `LICENSE`.
