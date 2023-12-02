using Xunit;

namespace Day2;


public class Day2Test
{
    [Fact]
    public void TestDay2_1()
    {
        var result = Day2.Day2_1(File.ReadAllLines("testInput.txt"));
        Assert.Equal(8, result);
    }

    [Fact]
    public void TestDay2_2()
    {
        var result = Day2.Day2_2(File.ReadAllLines("testInput.txt"));
        Assert.Equal(2286, result);
    }
}