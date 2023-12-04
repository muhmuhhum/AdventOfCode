namespace Day3Test;

public class Day3Test
{
    [Fact]
    public void TestPartOne()
    {
        var result = Day3.Day3.PartOne(File.ReadAllLines("testInput.txt"));
        Assert.Equal(4361, result);
    }

    [Fact]
    public void TestPartTwo()
    {
        var result = Day3.Day3.PartTwo(File.ReadAllLines("testInput.txt"));
        Assert.Equal(467835, result);
    }
}