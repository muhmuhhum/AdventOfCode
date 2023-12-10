namespace Day5;

public static class Day5
{
    public static ulong PartOne(string[] lines)
    {
        ulong[] seeds = lines[0].Split(": ")[1].Split(" ").Select(x => ulong.Parse(x)).ToArray();
        ulong min = ulong.MaxValue;
        var maps = new List<List<(ulong dest, ulong source, ulong step)>>();
        var current = new List<(ulong dest, ulong source, ulong step)>();
        foreach (var line in lines[2..])
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                maps.Add(current);
                current = new List<(ulong dest, ulong source, ulong step)>();
                continue;
            }
            if(!char.IsDigit(line[0]))
                continue;
            var parts = line.Split(" ");
            (ulong dest, ulong source, ulong step) blub = (
                ulong.Parse(parts[0]), 
                ulong.Parse(parts[1]),
                ulong.Parse(parts[2]));
            current.Add(blub);
        }
        maps.Add(current);
        foreach (var seed in seeds)
        {
            var newSeed = seed;
            foreach (var map in maps)
            {
                foreach (var l in map)
                {
                    if (newSeed <= l.source + l.step && newSeed >= l.source)
                    {
                        var add = l.dest - l.source;
                        newSeed = newSeed + add;
                        break;
                    }
                }
            }
            if (newSeed < min)
            {
                min = newSeed;
            }

            Console.WriteLine("Seed Finished");
        }
        return min;
    }
    
    public static IEnumerable<ulong> CreateRange(ulong start, ulong count)
    {
        var list = new List<ulong>();
        var limit = start + count;

        while (start < limit)
        {
            list.Add(start);
            start++;
        }

        return list;
    }

    public static ulong PartTwo(string[] lines)
    {
        var numberSplit = lines[0].Split(": ")[1].Split(" ").Select(x => ulong.Parse(x)).ToList();
        var maps = new List<List<(ulong dest, ulong source, ulong step)>>();
        var current = new List<(ulong dest, ulong source, ulong step)>();
        foreach (var line in lines[2..])
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                maps.Add(current);
                current = new List<(ulong dest, ulong source, ulong step)>();
                continue;
            }
            if(!char.IsDigit(line[0]))
                continue;
            var parts = line.Split(" ");
            (ulong dest, ulong source, ulong step) blub = (
                ulong.Parse(parts[0]), 
                ulong.Parse(parts[1]),
                ulong.Parse(parts[2]));
            current.Add(blub);
        }
        maps.Add(current);
        ulong min = ulong.MaxValue;
        for (int n = 0; n < numberSplit.Count; n+=2)
        {
            Parallel.ForEach(CreateRange(numberSplit[n], numberSplit[n + 1]), (seed) =>
            {
                var newSeed = seed;
                foreach (var map in maps)
                {
                    foreach (var l in map)
                    {
                        if (newSeed <= l.source + l.step && newSeed >= l.source)
                        {
                            var add = l.dest - l.source;
                            newSeed = newSeed + add;
                            break;
                        }
                    }
                }

                if (newSeed < min)
                {
                    min = newSeed;
                }

                //Console.WriteLine("Seed Finished");
            });

            Console.WriteLine("Range finished");
                
        }
        return min;
    }
}