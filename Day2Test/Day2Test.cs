using Xunit;

namespace Day2;


public class Day2Test
{
    [Fact]
    public void TestDay1()
    {
        var result = Day2.Day2_1(File.ReadAllLines("testInput.txt"));
        Assert.Equal(8, result);
    }
}