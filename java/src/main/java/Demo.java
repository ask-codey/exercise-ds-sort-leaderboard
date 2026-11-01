import java.util.List;
import java.util.stream.Collectors;

// Tries your methods on a time trial's results. Run it with: java src/main/java/Demo.java
public class Demo {
    static String show(List<Player> board) {
        return board.stream().map(player -> player.name() + " " + player.points()).collect(Collectors.joining(", "));
    }

    public static void main(String[] args) {
        List<Player> results = List.of(new Player("PixelPilot", 2400), new Player("NovaByte", 3150), new Player("QuietStorm", 1980), new Player("LemonDash", 2875), new Player("RetroFox", 3400), new Player("ByteKnight", 2210));

        System.out.println("Results: " + show(results));
        System.out.println("Selection sort: " + show(Sorting.selectionSort(results)));
        System.out.println("Insertion sort: " + show(Sorting.insertionSort(results)));
        System.out.println("EchoWave scores 2600: " + show(Sorting.addToBoard(Sorting.insertionSort(results), new Player("EchoWave", 2600))));
    }
}
