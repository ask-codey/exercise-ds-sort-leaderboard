# Your three functions. The comment inside each one says what it should
# return, with examples. Replace each return line with your own code,
# and write each function's growth rate in its comment. Don't call a
# built-in sort: the point is to write the sorts yourself.
from dataclasses import dataclass


@dataclass(frozen=True)
class Player:
    """One player on the leaderboard: a name and the points they scored."""
    name: str
    points: int


def selection_sort(players):
    """
    Sort the players by points, highest first, with selection sort:
    find the player with the most points in the unsorted part, swap
    them to the front of that part, and repeat. Work on a COPY, so the
    list you were given keeps its own order.

    selection_sort([PixelPilot 2400, NovaByte 3150, QuietStorm 1980])
      -> [NovaByte 3150, PixelPilot 2400, QuietStorm 1980]

    Growth rate: (write it here)
    """
    return []


def insertion_sort(players):
    """
    The same answer as selection_sort, with insertion sort: take each
    player in turn and slide them left, past every player with fewer
    points, into their place. Work on a COPY, so the list you were
    given keeps its own order.

    insertion_sort([PixelPilot 2400, NovaByte 3150, QuietStorm 1980])
      -> [NovaByte 3150, PixelPilot 2400, QuietStorm 1980]

    Growth rate: (write it here)
    """
    return []


def add_to_board(board, newcomer):
    """
    The board is already sorted, highest points first. A new player
    finishes: give back a NEW board with them slid into their place,
    one insertion-sort step. A tie goes after the players already on
    the board with the same points: they got there first.

    add_to_board([NovaByte 3150, PixelPilot 2400], EchoWave 2600)
      -> [NovaByte 3150, EchoWave 2600, PixelPilot 2400]

    Growth rate: (write it here)
    """
    return []
