using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    // Problem 1: Sum of squares
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return (n * n) + SumSquaresRecursive(n - 1);
    }

    // Problem 2: Permutations
    public static void PermutationsChoose(
        List<string> results,
        string letters,
        int size,
        string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char letter = letters[i];
            string remainingLetters = letters.Remove(i, 1);

            PermutationsChoose(
                results,
                remainingLetters,
                size,
                word + letter);
        }
    }

    // Problem 3: Climbing stairs with memoization
    public static decimal CountWaysToClimb(
        int s,
        Dictionary<int, decimal>? remember = null)
    {
        if (s < 0)
            return 0;

        if (s == 0)
            return 1;

        if (s == 1)
            return 1;

        if (s == 2)
            return 2;

        if (s == 3)
            return 4;

        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;

        return ways;
    }

    // Problem 4: Wildcard binary patterns
    public static void WildcardBinary(
        string pattern,
        List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string firstPart = pattern[..index];
        string lastPart = pattern[(index + 1)..];

        WildcardBinary(firstPart + "0" + lastPart, results);
        WildcardBinary(firstPart + "1" + lastPart, results);
    }

    // Problem 5: Maze solving with recursion and backtracking
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Move right
        if (maze.IsValidMove(currPath, x + 1, y))
            SolveMaze(results, maze, x + 1, y, currPath);

        // Move down
        if (maze.IsValidMove(currPath, x, y + 1))
            SolveMaze(results, maze, x, y + 1, currPath);

        // Move left
        if (maze.IsValidMove(currPath, x - 1, y))
            SolveMaze(results, maze, x - 1, y, currPath);

        // Move up
        if (maze.IsValidMove(currPath, x, y - 1))
            SolveMaze(results, maze, x, y - 1, currPath);

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}