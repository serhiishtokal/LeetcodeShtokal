using System.Text.Json;

var numbers = new int[] { -1, 1, 0, -3, 3 };
var solution = new Solution2();
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
                if (countOfZeros >= 2)
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

public class Solution2
{
    public int[] ProductExceptSelf(int[] numbers)
    {
        var result = Enumerable.Repeat(1, numbers.Length).ToArray();

        for (int i = 1, j = numbers.Length - 2, leftProduct = 1, rightProduct = 1; i < numbers.Length; i++, j--)
        {
            leftProduct *= numbers[i - 1];
            result[i] *= leftProduct;

            rightProduct *= numbers[j + 1];
            result[j] *= rightProduct;
        }

        return result;
    }
}