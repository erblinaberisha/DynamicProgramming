using System;

class TwinString
{
    public static int MinOperationsGreedy(string S)
    {
        int n = S.Length;
        int operations = 0;
        char[] arr = S.ToCharArray();

        for (int i = 1; i < n; i++)
        {
            if (arr[i] != arr[i - 1])
            {
                operations += Math.Abs(arr[i] - arr[i - 1]);
                arr[i] = arr[i - 1];
            }
        }

        return operations;
    }

    public static int MinOperationsDP(string S)
    {
        int n = S.Length;
        const int ALPHABET_COUNT = 26;

        int[,] dp = new int[n, ALPHABET_COUNT];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < ALPHABET_COUNT; j++)
            {
                dp[i, j] = int.MaxValue / 2;
            }
        }

        for (int j = 0; j < ALPHABET_COUNT; j++)
        {
            dp[0, j] = Math.Abs(S[0] - ('A' + j));
        }

        for (int i = 1; i < n; i++)
        {
            for (int c = 0; c < ALPHABET_COUNT; c++)
            {
                int costToChange = Math.Abs(S[i] - ('A' + c));
                for (int prevC = 0; prevC < ALPHABET_COUNT; prevC++)
                {
                    if (Math.Abs(c - prevC) <= 1)
                    {
                        dp[i, c] = Math.Min(dp[i, c], dp[i - 1, prevC] + costToChange);
                    }
                }
            }
        }

        int minOperations = int.MaxValue;
        for (int j = 0; j < ALPHABET_COUNT; j++)
        {
            minOperations = Math.Min(minOperations, dp[n - 1, j]);
        }

        return minOperations;
    }

    static void Main(string[] args)
    {
        string input1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string input2 = "ESPRIT";
        string input3 = "NOZAPHODJUSTVERYVERYIMPROBABLE";

        Console.WriteLine("Greedy Approach:");
        Console.WriteLine($"Input: {input1}, Operations: {MinOperationsGreedy(input1)}");
        Console.WriteLine($"Input: {input2}, Operations: {MinOperationsGreedy(input2)}");
        Console.WriteLine($"Input: {input3}, Operations: {MinOperationsGreedy(input3)}");

        Console.WriteLine("\nDynamic Programming Approach:");
        Console.WriteLine($"Input: {input1}, Operations: {MinOperationsDP(input1)}");
        Console.WriteLine($"Input: {input2}, Operations: {MinOperationsDP(input2)}");
        Console.WriteLine($"Input: {input3}, Operations: {MinOperationsDP(input3)}");
    }
}
