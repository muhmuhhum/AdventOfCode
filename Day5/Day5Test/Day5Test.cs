namespace Day5Test;

public class Day5Test
{
    [Fact]
    public void PartOne()
    {
        Assert.Equal((ulong)35, Day5.Day5.PartOne(File.ReadAllLines("testInput.txt")));
    }

    [Fact]
    public void PartTwo()
    {
        Assert.Equal((ulong) 46, Day5.Day5.PartTwo(File.ReadAllLines("testInput.txt")));
    }
}