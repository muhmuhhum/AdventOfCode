using System.Diagnostics;

Stopwatch sw =Stopwatch.StartNew();
var result = Day5.Day5.PartTwo(File.ReadAllLines("input.txt"));
sw.Stop();
Console.WriteLine($"Time: {sw.Elapsed}");
Console.WriteLine($"Result: {result}");