using Leaderboard;

// Tries your methods on a time trial's results. Run it with: dotnet run --project Leaderboard
List<Player> results = new List<Player> { new Player("PixelPilot", 2400), new Player("NovaByte", 3150), new Player("QuietStorm", 1980), new Player("LemonDash", 2875), new Player("RetroFox", 3400), new Player("ByteKnight", 2210) };

string Show(List<Player> board) => string.Join(", ", board.Select(player => player.Name + " " + player.Points));

Console.WriteLine("Results: " + Show(results));
Console.WriteLine("Selection sort: " + Show(Sorting.SelectionSort(results)));
Console.WriteLine("Insertion sort: " + Show(Sorting.InsertionSort(results)));
Console.WriteLine("EchoWave scores 2600: " + Show(Sorting.AddToBoard(Sorting.InsertionSort(results), new Player("EchoWave", 2600))));
