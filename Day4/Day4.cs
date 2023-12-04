namespace Day4;

public static class Day4
{
    public static long PartOne(string[] input)
    {
        var result = 0;
        foreach (var line in input)
        {
            var currentWinning = 0;
            var currentResult = 0;
            var parts = line.Split(": ")[1].Split(" | ");
            var firstNumbers = new List<int>(parts[0].Split(" ").Where(x => x != "").Select(x => int.Parse(x.Trim())));
            var secondNumbers = new List<int>(parts[1].Split(" ").Where(x => x != "").Select(x => int.Parse(x.Trim())));
            for (int i = 0; i < firstNumbers.Count; i++)
            {
                if (secondNumbers.Contains(firstNumbers[i]))
                {
                    if (currentResult == 0)
                    {
                        currentResult += 1;
                    }
                    else
                    {
                        currentResult = currentResult * 2;
                    }
                }
            }

            result += currentResult;
        }

        return result;
    }

    public static int PartTwo(string[] input)
    {
        Dictionary<int, int> amount = new Dictionary<int, int>();
        for(var i=0;i<input.Length;i++)
        {
            if (!amount.TryAdd(i, 1))
            {
                amount[i] += 1;
            }

            var currentWinning = 0;
            var currentResult = 0;
            var parts = input[i].Split(": ")[1].Split(" | ");
            var firstNumbers = new List<int>(parts[0].Split(" ").Where(x => x != "").Select(x => int.Parse(x.Trim())));
            var secondNumbers = new List<int>(parts[1].Split(" ").Where(x => x != "").Select(x => int.Parse(x.Trim())));
            var matches = 0;
            for (int j = 0; j < firstNumbers.Count; j++)
            {
                if (secondNumbers.Contains(firstNumbers[j]))
                {
                    matches++;
                }
            }

            if (i == input.Length - 1)
            {
                break;
            }
            for (var matchRun = i + 1; matchRun <= i+matches; matchRun++)
            {
                if (matchRun >= input.Length)
                {
                    continue;
                }
                if (!amount.TryAdd(matchRun, amount[i]))
                {
                    amount[matchRun] += amount[i];
                }
            }
            
            
        }

        return amount.Select(x => x.Value).Sum();
    }
}