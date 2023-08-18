using System.Text.Json;

var nums = new int[] { 2, 7, 11, 15 };
var target = 17;
var solution = new Solution();
var result = solution.TwoSum(nums, target);
string resultJson = JsonSerializer.Serialize(result);
Console.WriteLine(resultJson);
Console.ReadLine();

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }

        throw new Exception();
    }
}

public class Solution2
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int,int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var x = target - nums[i];

            if (dictionary.ContainsKey(x))
            {
                return new int[] { dictionary[x], i };
            }

            dictionary.TryAdd(nums[i], i);
        }

        throw new Exception();
    }
}