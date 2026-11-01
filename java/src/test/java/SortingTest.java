import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import org.junit.jupiter.api.Test;

// The tests for your three methods. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
class SortingTest {
    private static final List<Player> RESULTS = List.of(new Player("PixelPilot", 2400), new Player("NovaByte", 3150), new Player("QuietStorm", 1980), new Player("LemonDash", 2875), new Player("RetroFox", 3400), new Player("ByteKnight", 2210));
    private static final List<Player> SORTED = List.of(new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("LemonDash", 2875), new Player("PixelPilot", 2400), new Player("ByteKnight", 2210), new Player("QuietStorm", 1980));

    private static List<Player> manyPlayers() {
        List<Player> players = new ArrayList<>();
        for (int i = 0; i < 500; i++) {
            players.add(new Player("Player " + i, i * 7919 % 500));
        }
        return players;
    }

    @Test
    void selectionSortPutsTheMostPointsFirst() {
        assertEquals(SORTED, Sorting.selectionSort(RESULTS), "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
        assertEquals(List.of(new Player("NovaByte", 3150), new Player("PixelPilot", 2400)),
            Sorting.selectionSort(List.of(new Player("PixelPilot", 2400), new Player("NovaByte", 3150))), "Not yet: with two players, the one with more points comes first.");
    }

    @Test
    void selectionSortLeavesTheResultsAsTheyWere() {
        List<Player> results = new ArrayList<>(RESULTS);
        assertEquals(SORTED, Sorting.selectionSort(results), "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
        assertEquals(RESULTS, results, "Not yet: sort a copy, so the results keep the order the players finished in.");
    }

    @Test
    void selectionSortHandlesShortLists() {
        assertEquals(List.of(new Player("RetroFox", 3400)), Sorting.selectionSort(List.of(new Player("RetroFox", 3400))), "Not yet: a one-player board is already sorted.");
        assertEquals(List.of(), Sorting.selectionSort(List.of()), "Not yet: an empty board stays empty.");
    }

    @Test
    void insertionSortPutsTheMostPointsFirst() {
        assertEquals(SORTED, Sorting.insertionSort(RESULTS), "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
        List<Player> backward = new ArrayList<>(SORTED);
        Collections.reverse(backward);
        assertEquals(SORTED, Sorting.insertionSort(backward), "Not yet: a board in backward order, fewest points first, should come out highest first.");
        assertEquals(SORTED, Sorting.insertionSort(SORTED), "Not yet: a board that's already sorted should stay the same.");
    }

    @Test
    void insertionSortLeavesTheResultsAsTheyWere() {
        List<Player> results = new ArrayList<>(RESULTS);
        assertEquals(SORTED, Sorting.insertionSort(results), "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
        assertEquals(RESULTS, results, "Not yet: sort a copy, so the results keep the order the players finished in.");
    }

    @Test
    void bothSortsAgreeOnFiveHundredPlayers() {
        List<Player> bySelection = Sorting.selectionSort(manyPlayers());
        assertEquals(500, bySelection.size(), "Not yet: all 500 players should be on the board.");
        assertEquals(499, bySelection.get(0).points(), "Not yet: the most points, 499, come first.");
        assertEquals(0, bySelection.get(499).points(), "Not yet: the fewest points, 0, come last.");
        assertEquals(bySelection, Sorting.insertionSort(manyPlayers()), "Not yet: both sorts should give the same board.");
    }

    @Test
    void addToBoardSlidesTheNewcomerIntoPlace() {
        assertEquals(List.of(new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("LemonDash", 2875), new Player("EchoWave", 2600), new Player("PixelPilot", 2400), new Player("ByteKnight", 2210), new Player("QuietStorm", 1980)), Sorting.addToBoard(SORTED, new Player("EchoWave", 2600)),
            "Not yet: EchoWave (2600) goes between LemonDash (2875) and PixelPilot (2400).");
        assertEquals("ZenRacer", Sorting.addToBoard(SORTED, new Player("ZenRacer", 3600)).get(0).name(), "Not yet: ZenRacer (3600) beats everyone, so they go first.");
        assertEquals("SlowPoke", Sorting.addToBoard(SORTED, new Player("SlowPoke", 1200)).get(6).name(), "Not yet: SlowPoke (1200) has the fewest points, so they go last.");
        assertEquals(List.of(new Player("EchoWave", 2600)), Sorting.addToBoard(List.of(), new Player("EchoWave", 2600)), "Not yet: the first player on an empty board is the whole board.");
    }

    @Test
    void addToBoardPutsATieAfterThePlayersAlreadyThere() {
        List<Player> board = new ArrayList<>(List.of(new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("LemonDash", 2875)));
        assertEquals(List.of(new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("MintyFresh", 3150), new Player("LemonDash", 2875)), Sorting.addToBoard(board, new Player("MintyFresh", 3150)),
            "Not yet: MintyFresh ties NovaByte on 3150, so goes after NovaByte, who got there first.");
        assertEquals(List.of(new Player("RetroFox", 3400), new Player("NovaByte", 3150), new Player("LemonDash", 2875)), board, "Not yet: give back a new board, and leave the old one as it was.");
    }
}
