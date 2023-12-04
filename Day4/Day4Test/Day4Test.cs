namespace Day3Test;

public class Day4Test
{
    [Fact]
    public void TestPartOne()
    {
        var result = Day4.Day4.PartOne(File.ReadAllLines("testInput.txt"));
        Assert.Equal(13, result);
    }

    [Fact]
    public void TestPartTwo()
    {
        var result = Day4.Day4.PartTwo(File.ReadAllLines("testInput.txt"));
        Assert.Equal(30, result);
    }
}