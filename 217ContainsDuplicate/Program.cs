var nums = new int[] { 1, 2, 3, 1 };
var solution = new Solution();
var result = solution.ContainsDuplicate(nums);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var hash = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (hash.Contains(nums[i]))
            {
                return true;
            }

            hash.Add(nums[i]);
        }

        return false;
    }
}