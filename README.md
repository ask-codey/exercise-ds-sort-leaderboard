# Exercise: Sort the Leaderboard

Exercise code for the lesson **Exercise: Sort the Leaderboard** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

## The ticket

> **From:** the lead developer, a racing game
>
> The time-trial board has 10,000 players, and a late score arrives every few seconds. Today the server adds it to the end and sorts the whole board again, and on a busy evening the board falls minutes behind.
>
> 1. **A late score goes straight into its place** on the board that's already sorted, most points first. A tie goes after the players already on that score: they got there first.
> 2. **1,000 late scores on a board of 10,000** are placed in under 2 seconds.
> 3. **We still sort a whole race's results** when it ends, in finishing order to start with. We want two hand-written ways to compare, without the built-in sort: the "find the best, swap it to the front" way the old board used, and the "slide each one into place" way.
> 4. **Nobody's list is changed under them:** every function gives back a new list.

Three functions are yours to finish:

- `addToBoard` (`AddToBoard` in C#, `add_to_board` in Python): a sorted board with one late player slid into their place
- `selectionSort` (`SelectionSort`, `selection_sort`): a race's results, most points first, found best-first and swapped to the front
- `insertionSort` (`InsertionSort`, `insertion_sort`): the same board, each player slid left into place

Nine tests check them, ending with the ticket's busy evening: 1,000 late scores on a board of 10,000, in under 2 seconds.

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


<details>
<summary>Stuck?</summary>

- **Where to look:** the "find the best, swap it to the front" sort is *Putting the Leaderboard in Order: Selection Sort*; the "slide each one into place" sort is *One New Score on a Sorted Leaderboard: Insertion Sort*.
- **Sort a copy.** Make a new list from the one you're given, sort that, and return it. The tests check that the results keep their own order.
- **Most points first** turns the lessons' comparisons around: selection sort looks for the **most** points left, and insertion sort slides a player left past every player with **fewer** points.
- **`addToBoard` is one insertion-sort pass.** Put the newcomer at the end of a copy of the board and slide them left. Don't sort the whole board again: the busy-evening test stops after 2 seconds.
- **A tie stays behind.** Slide only past players with fewer points, not the same number: the player who got there first keeps their place.

</details>

<details>
<summary>Why Should I Choose This?</summary>

Open this once your tests are green. The busy evening is 1,000 late scores on a board of 10,000.

- **Add the score and sort again with selection sort:** about 50 million comparisons for each score, O(n²) every time, 50 billion for the evening. Measured with this test, the 2 seconds ran out with only 1 of the 1,000 scores placed in Python, 6 in C# and about 30 in Java, JavaScript and TypeScript.
- **Sort only when someone opens the board:** the same cost, paid later, and a busy board is always open.
- **Slide the new score into place:** at most 11,000 steps a score, O(n), and usually about half that. The whole evening took 0.26 seconds in Python and less in the other languages.
- **And insertion sort?** On a sorted board with one score added at the end, insertion sort does exactly that one slide, so sorting again with *it* would pass too. The board is almost sorted, which is insertion sort's best case.
- **What it gives up:** the slide is still O(n). On a board of millions with scores pouring in every second, the moving adds up, and the trees and heaps of Module 6 keep things in order without sliding.

</details>

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
