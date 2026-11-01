// Tries your functions on a time trial's results. Run it with: node demo.js
import { addToBoard, insertionSort, selectionSort } from "./leaderboard.js";

const results = [{ name: "PixelPilot", points: 2400 }, { name: "NovaByte", points: 3150 }, { name: "QuietStorm", points: 1980 }, { name: "LemonDash", points: 2875 }, { name: "RetroFox", points: 3400 }, { name: "ByteKnight", points: 2210 }];

function show(board) {
  return board.map((player) => `${player.name} ${player.points}`).join(", ");
}

console.log(`Results: ${show(results)}`);
console.log(`Selection sort: ${show(selectionSort(results))}`);
console.log(`Insertion sort: ${show(insertionSort(results))}`);
console.log(`EchoWave scores 2600: ${show(addToBoard(insertionSort(results), { name: "EchoWave", points: 2600 }))}`);
