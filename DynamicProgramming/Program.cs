using System;

class TwinString
{
   
    public static int MinOperationsGreedy(string S)
    {
        int n = S.Length;
        int operations = 0;

        char evenChar = S[0];
        char oddChar = S[1];

        for (int i = 0; i < n; i += 2)
        {
            operations += Math.Abs(S[i] - evenChar);
        }

        for (int i = 1; i < n; i += 2)
        {
            operations += Math.Abs(S[i] - oddChar);
        }
        return operations;
    }

    public static int MinOperationsDP(string S)
    {
        int n = S.Length;
        const int ALPHABET_COUNT = 26;

        int[] prev = new int[ALPHABET_COUNT];
        int[] curr = new int[ALPHABET_COUNT];

        for (int j = 0; j < ALPHABET_COUNT; j++)
        {
            prev[j] = Math.Abs(S[0] - ('A' + j));
        }

        for (int i = 1; i < n; i++)
        {
            for (int c = 0; c < ALPHABET_COUNT; c++)
            {
                curr[c] = int.MaxValue / 2;
                int costToChange = Math.Abs(S[i] - ('A' + c));
                for (int prevC = 0; prevC < ALPHABET_COUNT; prevC++)
                {
                    if (Math.Abs(c - prevC) <= 1)
                    {
                        curr[c] = Math.Min(curr[c], prev[prevC] + costToChange);
                    }
                }
            }
            Array.Copy(curr, prev, ALPHABET_COUNT);
        }

        int minOperations = int.MaxValue;
        for (int j = 0; j < ALPHABET_COUNT; j++)
        {
            minOperations = Math.Min(minOperations, prev[j]);
        }

        return minOperations;
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Do you want to input your own strings? (yes/no):");
        string userChoice = Console.ReadLine().ToLower();

        string input1, input2, input3;

        if (userChoice == "yes")
        {
            Console.WriteLine("Enter the first input string:");
            input1 = Console.ReadLine();

            Console.WriteLine("Enter the second input string:");
            input2 = Console.ReadLine();

            Console.WriteLine("Enter the third input string:");
            input3 = Console.ReadLine();
        }
        else
        {
            input1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            input2 = "ESPRIT";
            input3 = "NOZAPHODJUSTVERYVERYIMPROBABLE";
        }

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
