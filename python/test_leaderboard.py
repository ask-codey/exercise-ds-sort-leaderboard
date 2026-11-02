# The tests for your three functions. You don't need to change this file.
# Each message says what was expected, so a failing test tells you what to look at.
import time

from leaderboard import Player, add_to_board, insertion_sort, selection_sort

RESULTS = [Player("PixelPilot", 2400), Player("NovaByte", 3150), Player("QuietStorm", 1980), Player("LemonDash", 2875), Player("RetroFox", 3400), Player("ByteKnight", 2210)]
SORTED = [Player("RetroFox", 3400), Player("NovaByte", 3150), Player("LemonDash", 2875), Player("PixelPilot", 2400), Player("ByteKnight", 2210), Player("QuietStorm", 1980)]


def many_players():
    return [Player(f"Player {i}", i * 7919 % 500) for i in range(500)]


def test_selection_sort_puts_the_most_points_first():
    assert selection_sort(RESULTS) == SORTED, "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last."
    assert selection_sort([Player("PixelPilot", 2400), Player("NovaByte", 3150)]) == [Player("NovaByte", 3150), Player("PixelPilot", 2400)], \
        "Not yet: with two players, the one with more points comes first."


def test_selection_sort_leaves_the_results_as_they_were():
    results = list(RESULTS)
    assert selection_sort(results) == SORTED, "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last."
    assert results == RESULTS, "Not yet: sort a copy, so the results keep the order the players finished in."


def test_selection_sort_handles_short_lists():
    assert selection_sort([Player("RetroFox", 3400)]) == [Player("RetroFox", 3400)], "Not yet: a one-player board is already sorted."
    assert selection_sort([]) == [], "Not yet: an empty board stays empty."


def test_insertion_sort_puts_the_most_points_first():
    assert insertion_sort(RESULTS) == SORTED, "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last."
    assert insertion_sort(list(reversed(SORTED))) == SORTED, \
        "Not yet: a board in backward order, fewest points first, should come out highest first."
    assert insertion_sort(SORTED) == SORTED, "Not yet: a board that's already sorted should stay the same."


def test_insertion_sort_leaves_the_results_as_they_were():
    results = list(RESULTS)
    assert insertion_sort(results) == SORTED, "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last."
    assert results == RESULTS, "Not yet: sort a copy, so the results keep the order the players finished in."


def test_both_sorts_agree_on_five_hundred_players():
    by_selection = selection_sort(many_players())
    assert len(by_selection) == 500, "Not yet: all 500 players should be on the board."
    assert by_selection[0].points == 499, "Not yet: the most points, 499, come first."
    assert by_selection[499].points == 0, "Not yet: the fewest points, 0, come last."
    assert insertion_sort(many_players()) == by_selection, "Not yet: both sorts should give the same board."


def test_add_to_board_slides_the_newcomer_into_place():
    assert add_to_board(SORTED, Player("EchoWave", 2600)) == [Player("RetroFox", 3400), Player("NovaByte", 3150), Player("LemonDash", 2875), Player("EchoWave", 2600), Player("PixelPilot", 2400), Player("ByteKnight", 2210), Player("QuietStorm", 1980)], \
        "Not yet: EchoWave (2600) goes between LemonDash (2875) and PixelPilot (2400)."
    assert add_to_board(SORTED, Player("ZenRacer", 3600))[0].name == "ZenRacer", "Not yet: ZenRacer (3600) beats everyone, so they go first."
    assert add_to_board(SORTED, Player("SlowPoke", 1200))[6].name == "SlowPoke", "Not yet: SlowPoke (1200) has the fewest points, so they go last."
    assert add_to_board([], Player("EchoWave", 2600)) == [Player("EchoWave", 2600)], "Not yet: the first player on an empty board is the whole board."


def test_add_to_board_puts_a_tie_after_the_players_already_there():
    board = [Player("RetroFox", 3400), Player("NovaByte", 3150), Player("LemonDash", 2875)]
    assert add_to_board(board, Player("MintyFresh", 3150)) == [Player("RetroFox", 3400), Player("NovaByte", 3150), Player("MintyFresh", 3150), Player("LemonDash", 2875)], \
        "Not yet: MintyFresh ties NovaByte on 3150, so goes after NovaByte, who got there first."
    assert board == [Player("RetroFox", 3400), Player("NovaByte", 3150), Player("LemonDash", 2875)], "Not yet: give back a new board, and leave the old one as it was."


def test_a_thousand_late_scores_on_a_board_of_ten_thousand_take_under_two_seconds():
    board = [Player(f"Player {i}", 50000 - i * 5) for i in range(10000)]
    started = time.perf_counter()
    for j in range(1000):
        board = add_to_board(board, Player(f"Late {j}", j * 7919 % 50000))
        assert time.perf_counter() - started < 2, \
            f"Not yet: the ticket allows 2 seconds for 1,000 late scores on a board of 10,000, and {j + 1} scores took longer. One slide is at most 11,000 steps; sorting the whole board again is about 50 million comparisons."
    assert len(board) == 11000, "Not yet: after 1,000 late scores, the board should hold 11,000 players."
    for i in range(len(board) - 1):
        assert board[i].points >= board[i + 1].points, \
            f"Not yet: the board must stay sorted, most points first, but {board[i].name} ({board[i].points}) comes just before {board[i + 1].name} ({board[i + 1].points})."
