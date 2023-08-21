using System.Text.Json;

var nums = new int[] { 1, 1, 1, 2, 2, 3 };
var k = 2;
var solution = new Solution();
var result = solution.TopKFrequent(nums, k);
string resultJson = JsonSerializer.Serialize(result);
Console.WriteLine(resultJson);
Console.ReadLine();

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var dictionary = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!dictionary.TryAdd(nums[i], 1))
            {
                dictionary[nums[i]]++;
            }
        }

        return dictionary
            .OrderByDescending(x => x.Value)
            .Take(k)
            .Select(x => x.Key)
            .ToArray();
    }
}