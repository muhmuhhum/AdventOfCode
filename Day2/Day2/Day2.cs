namespace Day2;

public class Day2
{
    private static Dictionary<string, int> limits = new Dictionary<string, int>
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };
    public static int Day2_1(string[] input)
    {
        var result = 0;
        foreach (var line in input)
        {
            bool valid = true;
            var splitId = line.Split(": ");
            var id = splitId[0].Remove(0, 5);
            var rounds = splitId[1].Split("; ");
            foreach (var round in rounds)
            {
                var colors = round.Split(", ");
                foreach (var color in colors)
                {
                    var numberAndColor = color.Split(" ");
                    if (limits[numberAndColor[1]] < int.Parse(numberAndColor[0]))
                    {
                        valid = false;
                    }
                }
                if (!valid)
                    break;
            }

            if (valid)
            {
                result += int.Parse(id);
            }
        
        }
        return result;
    }

    public static int Day2_2(string[] input)
    {
       
        var result = 0;
        foreach (var line in input)
        {
            var max = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };
            var splitId = line.Split(": ");
            var id = splitId[0].Remove(0, 5);
            var rounds = splitId[1].Split("; ");
            foreach (var round in rounds)
            {
                var colors = round.Split(", ");
                foreach (var color in colors)
                {
                    var numberAndColor = color.Split(" ");
                    if (max[numberAndColor[1]] < int.Parse(numberAndColor[0]))
                    {
                        max[numberAndColor[1]] = int.Parse(numberAndColor[0]);
                    }
                }
            }

            
            var multipiedResult = 1;
            foreach (var maxColor in max)
            {
                multipiedResult = multipiedResult * maxColor.Value;
            }

            result += multipiedResult;
            
        
        }
        return result;
    }
}