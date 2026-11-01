# Exercise: Sort the Leaderboard

Exercise code for the lesson **Exercise: Sort the Leaderboard** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

A game's time trial has finished, and the results are in the order the players crossed the line. You'll put the leaderboard in order, most points first, with both of the chapter's sorts, then slide a late finisher into place without sorting everything again. There are three functions to finish:

- `selectionSort` (`SelectionSort` in C#, `selection_sort` in Python): the players sorted by points, highest first, with selection sort
- `insertionSort` (`InsertionSort`, `insertion_sort`): the same board, with insertion sort
- `addToBoard` (`AddToBoard`, `add_to_board`): a sorted board with one new player slid into their place

Write the sorts yourself: don't call your language's built-in sort.

## Pick your language

The same exercise is here in five languages. Work in the folder for the language you set up; you only need one.

| Folder | Your code | The tests |
|---|---|---|
| `csharp/` | `Leaderboard/Sorting.cs` (a player is `Leaderboard/Player.cs`) | `Leaderboard.Tests/SortingTests.cs` |
| `java/` | `src/main/java/Sorting.java` (a player is `src/main/java/Player.java`) | `src/test/java/SortingTest.java` |
| `python/` | `leaderboard.py` | `test_leaderboard.py` |
| `javascript/` | `leaderboard.js` | `leaderboard.test.js` |
| `typescript/` | `leaderboard.ts` | `leaderboard.test.ts` |

A player is a name and their points: a `Player` record in C# and Java, a `Player` dataclass in Python, and an object such as `{ name: "PixelPilot", points: 2400 }` in JavaScript and TypeScript.

Each function returns an empty list for now. The comment above it says what it should return, with examples. Replace the `return` line with your own code, and write the function's growth rate on its **Growth rate:** line.

Every folder also has a small demo program that tries your functions on six players' results. You don't need to change the tests or the demo.

## Run it and check your work

Open your language's folder in VS Code (**File > Open Folder**), then open its terminal (**Terminal > New Terminal**) and run these commands there.

**C#**

```bash
dotnet run --project Leaderboard
dotnet test
```

**Java** (the Maven Wrapper downloads Maven the first time, so the first run takes a minute)

```bash
java src/main/java/Demo.java
./mvnw test
```

On Windows in PowerShell, write `.\mvnw test` instead of `./mvnw test`.

**Python** (once: make a virtual environment and install pytest into it)

```bash
python -m venv .venv
```

Then turn it on: `.venv\Scripts\Activate.ps1` in PowerShell on Windows, or `source .venv/bin/activate` on macOS (where the command is `python3`, not `python`). Then:

```bash
pip install -r requirements.txt
python demo.py
python -m pytest
```

**JavaScript**

```bash
node demo.js
npm test
```

**TypeScript** (once: `npm install`, which installs TypeScript)

```bash
node demo.ts
npm test
```

At first every test fails: that is expected. Each function you finish turns its tests green. A failing test's message starts with **Not yet:** and says what it expected.

## Tips

- **Sort a copy.** Make a new list from the one you're given, sort that, and return it. The tests check that the results keep their own order.
- **Most points first** means the lessons' comparisons turn around: selection sort looks for the most points, and insertion sort slides a player left past every player with fewer points.
- **`addToBoard` is one insertion-sort pass.** Put the newcomer at the end of a copy of the board and slide them left.
- **A tie stays behind.** Slide only past players with fewer points, not the same number: the player who got there first keeps their place.

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
