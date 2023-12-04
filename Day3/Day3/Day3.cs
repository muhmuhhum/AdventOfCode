namespace Day3;

public static class Day3
{
    public static long PartOne(string[] input)
    {
        int result = 0;
        for (int i = 0; i < input.Length; i++)
        {
            string currentNumber = "";
            bool isValid = false;
            for (int j = 0; j < input[i].Length; j++)
            {
                bool wasDigit = false;
                if (char.IsDigit(input[i][j]))
                {
                    wasDigit = true;
                    currentNumber += input[i][j];
                    if (!isValid)
                    {
                        for (var addI = -1; addI <= 1; addI++)
                        {
                            for (var addJ = -1; addJ <= 1; addJ++)
                            {
                                if (i + addI > 0 && j + addJ > 0 && i + addI < input.Length && j + addJ < input[i].Length)
                                {
                                    var checkChar = input[i + addI][j + addJ];
                                    if (!char.IsAsciiLetterOrDigit(checkChar) && checkChar != '.')
                                    {
                                        isValid = true;
                                        break;
                                    }
                                }
                            }

                            if (isValid)
                                break;
                        }
                    }
                }
                else
                {
                    wasDigit = false;
                }

                if ((!wasDigit || j == input[i].Length - 1) && currentNumber != "" && isValid)
                {
                    result += int.Parse(currentNumber);
                }

                if (!wasDigit)
                {
                    currentNumber = "";
                    isValid = false;
                }
            }
        }

        return result;
    }

    public static int PartTwo(string[] input)
    {
        Dictionary<(int i, int j), List<int>> valid = new Dictionary<(int i, int j), List<int>>();
        for (int i = 0; i < input.Length; i++)
        {
            string currentNumber = "";
            bool isValid = false;
            (int i, int j)? currentStar = null;
            for (int j = 0; j < input[i].Length; j++)
            {
                bool wasDigit = false;
                
                if (char.IsDigit(input[i][j]))
                {
                    wasDigit = true;
                    currentNumber += input[i][j];
                    if (!isValid)
                    {
                        for (var addI = -1; addI <= 1; addI++)
                        {
                            for (var addJ = -1; addJ <= 1; addJ++)
                            {
                                if (i + addI > 0 && j + addJ > 0 && i + addI < input.Length && j + addJ < input[i].Length)
                                {
                                    var checkChar = input[i + addI][j + addJ];
                                    if (checkChar == '*')
                                    {
                                        currentStar = (i + addI, j + addJ);
                                        isValid = true;
                                        break;
                                    }
                                }
                            }

                            if (isValid)
                                break;
                        }
                    }
                }
                else
                {
                    wasDigit = false;
                }

                if ((!wasDigit || j == input[i].Length - 1) && currentNumber != "" && isValid)
                {
                    if (valid.ContainsKey(currentStar.Value))
                    {
                        valid[currentStar.Value].Add(int.Parse(currentNumber));
                    }
                    else
                    {
                        valid.Add(currentStar.Value,new List<int> { int.Parse(currentNumber)});
                    }
                }

                if (!wasDigit)
                {
                    currentNumber = "";
                    isValid = false;
                }
            }
        }

        var result = 0;
        foreach (var star in valid.Where(x => x.Value.Count == 2))
        {
            result += star.Value[0] * star.Value[1];
        }

        return result;
    }
}