# Tries your functions on a time trial's results. Run it with: python demo.py
from leaderboard import Player, add_to_board, insertion_sort, selection_sort

results = [Player("PixelPilot", 2400), Player("NovaByte", 3150), Player("QuietStorm", 1980), Player("LemonDash", 2875), Player("RetroFox", 3400), Player("ByteKnight", 2210)]


def show(board):
    return ", ".join(f"{player.name} {player.points}" for player in board)


print("Results: " + show(results))
print("Selection sort: " + show(selection_sort(results)))
print("Insertion sort: " + show(insertion_sort(results)))
print("EchoWave scores 2600: " + show(add_to_board(insertion_sort(results), Player("EchoWave", 2600))))
