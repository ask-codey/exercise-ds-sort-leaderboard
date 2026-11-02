using System.Diagnostics;
using Leaderboard;

namespace Leaderboard.Tests;

// The tests for your three methods. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.

[TestClass]
public class SortingTests
{
    private static List<Player> Results() => new List<Player> { new Player("PixelPilot", 2400), new Player("NovaByte", 3150), new Player("QuietStorm", 1980), new Player("LemonDash", 2875), new Player("RetroFox", 3400), new Player("ByteKnight", 2210) };
    private static List<Player> Sorted() => new List<Player> { new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("LemonDash", 2875), new Player("PixelPilot", 2400), new Player("ByteKnight", 2210), new Player("QuietStorm", 1980) };

    private static List<Player> ManyPlayers()
    {
        List<Player> players = new List<Player>();
        for (int i = 0; i < 500; i++)
        {
            players.Add(new Player("Player " + i, i * 7919 % 500));
        }
        return players;
    }

    [TestMethod]
    public void SelectionSortPutsTheMostPointsFirst()
    {
        CollectionAssert.AreEqual(Sorted(), Sorting.SelectionSort(Results()), "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
        CollectionAssert.AreEqual(new List<Player> { new Player("NovaByte", 3150), new Player("PixelPilot", 2400) },
            Sorting.SelectionSort(new List<Player> { new Player("PixelPilot", 2400), new Player("NovaByte", 3150) }), "Not yet: with two players, the one with more points comes first.");
    }

    [TestMethod]
    public void SelectionSortLeavesTheResultsAsTheyWere()
    {
        List<Player> results = Results();
        CollectionAssert.AreEqual(Sorted(), Sorting.SelectionSort(results), "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
        CollectionAssert.AreEqual(Results(), results, "Not yet: sort a copy, so the results keep the order the players finished in.");
    }

    [TestMethod]
    public void SelectionSortHandlesShortLists()
    {
        CollectionAssert.AreEqual(new List<Player> { new Player("RetroFox", 3400) }, Sorting.SelectionSort(new List<Player> { new Player("RetroFox", 3400) }),
            "Not yet: a one-player board is already sorted.");
        CollectionAssert.AreEqual(new List<Player>(), Sorting.SelectionSort(new List<Player>()), "Not yet: an empty board stays empty.");
    }

    [TestMethod]
    public void InsertionSortPutsTheMostPointsFirst()
    {
        CollectionAssert.AreEqual(Sorted(), Sorting.InsertionSort(Results()), "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
        List<Player> backward = Sorted();
        backward.Reverse();
        CollectionAssert.AreEqual(Sorted(), Sorting.InsertionSort(backward), "Not yet: a board in backward order, fewest points first, should come out highest first.");
        CollectionAssert.AreEqual(Sorted(), Sorting.InsertionSort(Sorted()), "Not yet: a board that's already sorted should stay the same.");
    }

    [TestMethod]
    public void InsertionSortLeavesTheResultsAsTheyWere()
    {
        List<Player> results = Results();
        CollectionAssert.AreEqual(Sorted(), Sorting.InsertionSort(results), "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
        CollectionAssert.AreEqual(Results(), results, "Not yet: sort a copy, so the results keep the order the players finished in.");
    }

    [TestMethod]
    public void BothSortsAgreeOnFiveHundredPlayers()
    {
        List<Player> bySelection = Sorting.SelectionSort(ManyPlayers());
        Assert.AreEqual(500, bySelection.Count, "Not yet: all 500 players should be on the board.");
        Assert.AreEqual(499, bySelection[0].Points, "Not yet: the most points, 499, come first.");
        Assert.AreEqual(0, bySelection[499].Points, "Not yet: the fewest points, 0, come last.");
        CollectionAssert.AreEqual(bySelection, Sorting.InsertionSort(ManyPlayers()), "Not yet: both sorts should give the same board.");
    }

    [TestMethod]
    public void AddToBoardSlidesTheNewcomerIntoPlace()
    {
        CollectionAssert.AreEqual(new List<Player> { new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("LemonDash", 2875), new Player("EchoWave", 2600), new Player("PixelPilot", 2400), new Player("ByteKnight", 2210), new Player("QuietStorm", 1980) }, Sorting.AddToBoard(Sorted(), new Player("EchoWave", 2600)),
            "Not yet: EchoWave (2600) goes between LemonDash (2875) and PixelPilot (2400).");
        Assert.AreEqual("ZenRacer", Sorting.AddToBoard(Sorted(), new Player("ZenRacer", 3600))[0].Name, "Not yet: ZenRacer (3600) beats everyone, so they go first.");
        Assert.AreEqual("SlowPoke", Sorting.AddToBoard(Sorted(), new Player("SlowPoke", 1200))[6].Name, "Not yet: SlowPoke (1200) has the fewest points, so they go last.");
        CollectionAssert.AreEqual(new List<Player> { new Player("EchoWave", 2600) }, Sorting.AddToBoard(new List<Player>(), new Player("EchoWave", 2600)),
            "Not yet: the first player on an empty board is the whole board.");
    }

    [TestMethod]
    public void AddToBoardPutsATieAfterThePlayersAlreadyThere()
    {
        List<Player> board = new List<Player> { new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("LemonDash", 2875) };
        CollectionAssert.AreEqual(new List<Player> { new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("MintyFresh", 3150), new Player("LemonDash", 2875) }, Sorting.AddToBoard(board, new Player("MintyFresh", 3150)),
            "Not yet: MintyFresh ties NovaByte on 3150, so goes after NovaByte, who got there first.");
        CollectionAssert.AreEqual(new List<Player> { new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("LemonDash", 2875) }, board, "Not yet: give back a new board, and leave the old one as it was.");
    }

    [TestMethod]
    public void AThousandLateScoresOnABoardOfTenThousandTakeUnderTwoSeconds()
    {
        List<Player> board = new List<Player>();
        for (int i = 0; i < 10000; i++)
        {
            board.Add(new Player("Player " + i, 50000 - i * 5));
        }
        Stopwatch watch = Stopwatch.StartNew();
        for (int j = 0; j < 1000; j++)
        {
            board = Sorting.AddToBoard(board, new Player("Late " + j, j * 7919 % 50000));
            if (watch.Elapsed.TotalSeconds >= 2)
            {
                Assert.Fail("Not yet: the ticket allows 2 seconds for 1,000 late scores on a board of 10,000, and " + (j + 1) + " scores took longer. One slide is at most 11,000 steps; sorting the whole board again is about 50 million comparisons.");
            }
        }
        Assert.AreEqual(11000, board.Count, "Not yet: after 1,000 late scores, the board should hold 11,000 players.");
        for (int i = 0; i < board.Count - 1; i++)
        {
            if (board[i].Points < board[i + 1].Points)
            {
                Assert.Fail("Not yet: the board must stay sorted, most points first, but " + board[i].Name + " (" + board[i].Points + ") comes just before " + board[i + 1].Name + " (" + board[i + 1].Points + ").");
            }
        }
    }
}
