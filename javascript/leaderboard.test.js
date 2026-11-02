// The tests for your three functions. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
import assert from "node:assert/strict";
import { test } from "node:test";
import { addToBoard, insertionSort, selectionSort } from "./leaderboard.js";

const RESULTS = [{ name: "PixelPilot", points: 2400 }, { name: "NovaByte", points: 3150 }, { name: "QuietStorm", points: 1980 }, { name: "LemonDash", points: 2875 }, { name: "RetroFox", points: 3400 }, { name: "ByteKnight", points: 2210 }];
const SORTED = [{ name: "RetroFox", points: 3400 }, { name: "NovaByte", points: 3150 }, { name: "LemonDash", points: 2875 }, { name: "PixelPilot", points: 2400 }, { name: "ByteKnight", points: 2210 }, { name: "QuietStorm", points: 1980 }];

function manyPlayers() {
  const players = [];
  for (let i = 0; i < 500; i++) {
    players.push({ name: `Player ${i}`, points: i * 7919 % 500 });
  }
  return players;
}

test("selection sort puts the most points first", () => {
  assert.deepEqual(selectionSort(RESULTS), SORTED, "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
  assert.deepEqual(selectionSort([{ name: "PixelPilot", points: 2400 }, { name: "NovaByte", points: 3150 }]),
    [{ name: "NovaByte", points: 3150 }, { name: "PixelPilot", points: 2400 }], "Not yet: with two players, the one with more points comes first.");
});

test("selection sort leaves the results as they were", () => {
  const results = [...RESULTS];
  assert.deepEqual(selectionSort(results), SORTED, "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
  assert.deepEqual(results, RESULTS, "Not yet: sort a copy, so the results keep the order the players finished in.");
});

test("selection sort handles short lists", () => {
  assert.deepEqual(selectionSort([{ name: "RetroFox", points: 3400 }]), [{ name: "RetroFox", points: 3400 }], "Not yet: a one-player board is already sorted.");
  assert.deepEqual(selectionSort([]), [], "Not yet: an empty board stays empty.");
});

test("insertion sort puts the most points first", () => {
  assert.deepEqual(insertionSort(RESULTS), SORTED, "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
  assert.deepEqual(insertionSort([...SORTED].reverse()), SORTED, "Not yet: a board in backward order, fewest points first, should come out highest first.");
  assert.deepEqual(insertionSort(SORTED), SORTED, "Not yet: a board that's already sorted should stay the same.");
});

test("insertion sort leaves the results as they were", () => {
  const results = [...RESULTS];
  assert.deepEqual(insertionSort(results), SORTED, "Not yet: RetroFox (3400) comes first and QuietStorm (1980) last.");
  assert.deepEqual(results, RESULTS, "Not yet: sort a copy, so the results keep the order the players finished in.");
});

test("both sorts agree on five hundred players", () => {
  const bySelection = selectionSort(manyPlayers());
  assert.equal(bySelection.length, 500, "Not yet: all 500 players should be on the board.");
  assert.equal(bySelection[0]?.points, 499, "Not yet: the most points, 499, come first.");
  assert.equal(bySelection[499]?.points, 0, "Not yet: the fewest points, 0, come last.");
  assert.deepEqual(insertionSort(manyPlayers()), bySelection, "Not yet: both sorts should give the same board.");
});

test("add to board slides the newcomer into place", () => {
  assert.deepEqual(addToBoard(SORTED, { name: "EchoWave", points: 2600 }), [{ name: "RetroFox", points: 3400 }, { name: "NovaByte", points: 3150 }, { name: "LemonDash", points: 2875 }, { name: "EchoWave", points: 2600 }, { name: "PixelPilot", points: 2400 }, { name: "ByteKnight", points: 2210 }, { name: "QuietStorm", points: 1980 }],
    "Not yet: EchoWave (2600) goes between LemonDash (2875) and PixelPilot (2400).");
  assert.equal(addToBoard(SORTED, { name: "ZenRacer", points: 3600 })[0]?.name, "ZenRacer", "Not yet: ZenRacer (3600) beats everyone, so they go first.");
  assert.equal(addToBoard(SORTED, { name: "SlowPoke", points: 1200 })[6]?.name, "SlowPoke", "Not yet: SlowPoke (1200) has the fewest points, so they go last.");
  assert.deepEqual(addToBoard([], { name: "EchoWave", points: 2600 }), [{ name: "EchoWave", points: 2600 }], "Not yet: the first player on an empty board is the whole board.");
});

test("add to board puts a tie after the players already there", () => {
  const board = [{ name: "RetroFox", points: 3400 }, { name: "NovaByte", points: 3150 }, { name: "LemonDash", points: 2875 }];
  assert.deepEqual(addToBoard(board, { name: "MintyFresh", points: 3150 }), [{ name: "RetroFox", points: 3400 }, { name: "NovaByte", points: 3150 }, { name: "MintyFresh", points: 3150 }, { name: "LemonDash", points: 2875 }],
    "Not yet: MintyFresh ties NovaByte on 3150, so goes after NovaByte, who got there first.");
  assert.deepEqual(board, [{ name: "RetroFox", points: 3400 }, { name: "NovaByte", points: 3150 }, { name: "LemonDash", points: 2875 }], "Not yet: give back a new board, and leave the old one as it was.");
});

test("a thousand late scores on a board of ten thousand take under two seconds", () => {
  let board = [];
  for (let i = 0; i < 10000; i++) {
    board.push({ name: `Player ${i}`, points: 50000 - i * 5 });
  }
  const started = performance.now();
  for (let j = 0; j < 1000; j++) {
    board = addToBoard(board, { name: `Late ${j}`, points: j * 7919 % 50000 });
    if (performance.now() - started >= 2000) {
      assert.fail(`Not yet: the ticket allows 2 seconds for 1,000 late scores on a board of 10,000, and ${j + 1} scores took longer. One slide is at most 11,000 steps; sorting the whole board again is about 50 million comparisons.`);
    }
  }
  assert.equal(board.length, 11000, "Not yet: after 1,000 late scores, the board should hold 11,000 players.");
  for (let i = 0; i < board.length - 1; i++) {
    if (board[i].points < board[i + 1].points) {
      assert.fail(`Not yet: the board must stay sorted, most points first, but ${board[i].name} (${board[i].points}) comes just before ${board[i + 1].name} (${board[i + 1].points}).`);
    }
  }
});
