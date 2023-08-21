using System.Text.Json;

var numbers = new int[] { -1, 1, 0, -3, 3 };
var solution = new Solution();
var result = solution.ProductExceptSelf(numbers);
string resultJson = JsonSerializer.Serialize(result);
Console.WriteLine(resultJson);
Console.ReadLine();

public class Solution
{
    public int[] ProductExceptSelf(int[] numbers)
    {
        var product = 1;

        var countOfZeros = 0;
        int zeroPosition = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == 0)
            {
                countOfZeros++;
                if(countOfZeros >= 2)
                {
                    return Enumerable.Repeat(0, numbers.Length).ToArray();
                }
                zeroPosition = i;
            }
            else
            {
                product *= numbers[i];
            }
        }

        int[] result;

        if (countOfZeros > 0)
        {
            result = Enumerable.Repeat(0, numbers.Length).ToArray();
            result[zeroPosition] = product;
            return result;
        }

        result = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            result[i] = product / numbers[i];
        }

        return result;
    }
}