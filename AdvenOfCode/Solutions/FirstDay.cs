namespace AdvenOfCode.Solutions;

public static class FirstDay
{
    /// <summary>
    /// Calculates the total distance between two lists by pairing their smallest numbers.
    /// </summary>
    /// <param name="leftSide">The first list of integers.</param>
    /// <param name="rightSide">The second list of integers.</param>
    /// <returns>The total distance between the two lists.</returns>

    public static int SolutionFirst(int[] leftSide, int[] rightSide)
    {
        Array.Sort(leftSide);
        Array.Sort(rightSide);
        var result = 0;
        for (var i = 0; i <= leftSide.Length-1; i++)
        {
            var leftNum = leftSide[i];
            var rightNum = rightSide[i];
            result += Math.Abs(leftNum - rightNum);
        }

        return result;
    }

    /// <summary>
    /// Calculates the similarity score by counting occurrences of each number in the right list.
    /// </summary>
    /// <param name="leftSide">The first list of integers.</param>
    /// <param name="rightSide">The second list of integers.</param>
    /// <returns>The similarity score between the two lists.</returns>

    public static long SolutionSecond(int[] leftSide, int[] rightSide)
    {
        Array.Sort(leftSide);
        Array.Sort(rightSide);
        long result = 0;
        foreach (var item in leftSide)
        {
            result += (SearchItemsCountInArray(rightSide, item) * item);
        }

        return result;
    }

    private static int SearchItemsCountInArray(int[] array, int number)
    {
        var result = 0;
        for (var i = 0; i < array.Length-1; i++)
        {
            if (array[i] == number)
            {
                result++;
            }

            if (array[i] > number)
            {
                return result;
            }
        }

        return result;
    }

    #region external code
    public static (int[] leftColumn, int[] rightColumn) ParseInputToArrays(string input)
    {
        // Split input into lines
        var lines = input.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        // Create lists to store numbers
        var leftColumn = new List<int>();
        var rightColumn = new List<int>();

        // Process each line
        foreach (var line in lines)
        {
            var parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) continue;
            leftColumn.Add(int.Parse(parts[0]));
            rightColumn.Add(int.Parse(parts[1]));
        }

        // Convert lists to arrays
        return (leftColumn.ToArray(), rightColumn.ToArray());
    }
    #endregion

}