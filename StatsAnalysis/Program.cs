public class StatsCalculator
{
    public void CalculateStats(int[] numbers)
    {
        int lowest = numbers[0]; // Initialize lowest to the first element
        int highest = numbers[0]; // Initialize highest to the first element

        for (int i = 1; i < numbers.Length; i++) // going through each of the numbers in the list
        {
            if (numbers[i] < lowest)
                lowest = numbers[i];
            if (numbers[i] > highest)
                highest = numbers[i];
        }

        // median cheif
        int[] sortedNumbers = new int[numbers.Length]; // creates an array to hold a copy of the original numbers
        for (int i = 0; i < numbers.Length; i++)
            sortedNumbers[i] = numbers[i]; // code to copy the current umber into the new array
        Array.Sort(sortedNumbers); // sorts the new array
        double median = (sortedNumbers[4] + sortedNumbers[5]) / 2.0; // uses the middle two numbers to calculate the median

        // the mode
        List<int> seenNumbers = new List<int>(); // creates a list of seen numbers
        List<int> counts = new List<int>(); // creates a list of counts for each number

        for (int i = 0; i < numbers.Length; i++)
        {
            int num = numbers[i]; // current number in the array
            if (!seenNumbers.Contains(num)) // checks if the number has already been seen
            {
                seenNumbers.Add(num); // Adds number to seen numbers
                int count = 0;
                for (int j = 0; j < numbers.Length; j++) // this counts how many times the numbers appear in the array
                {
                    if (numbers[j] == num) // compares the current number in the array position to the number being counted 
                        count++; // increments the count if it matches
                }
                counts.Add(count); // adds the count to the counts list
            }
        }
        //the highest count
        int maxCount = 0;
        for (int i = 0; i < counts.Count; i++)
        {
            if (counts[i] > maxCount)
                maxCount = counts[i];
        }
        // all numbers with the highest count
        List<int> modes = new List<int>();
        for (int i = 0; i < seenNumbers.Count; i++)
        {
            if (counts[i] == maxCount)
                modes.Add(seenNumbers[i]);
        }

        Console.WriteLine("Lowest number: " + lowest);
        Console.WriteLine("Highest number: " + highest);
        Console.WriteLine("Median: " + median);
        Console.Write("Mode: ");
        for (int i = 0; i < modes.Count; i++)
        {
            Console.Write(modes[i]);
            if (i < modes.Count - 1)
                Console.Write(", ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        int[] statsNumberList = { 1, 4, 3, 4, 5, 7, 7, 8, 9, 10 };
        StatsCalculator calculator = new StatsCalculator();
        calculator.CalculateStats(statsNumberList);
    }
}
