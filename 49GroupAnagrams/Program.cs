using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
var solution = new Solution();
var result = solution.GroupAnagrams(strs);
string resultJson = JsonSerializer.Serialize(result);
Console.WriteLine(resultJson);
Console.ReadLine();

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groupAnagramsDict = new Dictionary<string, List<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            var str = strs[i];

            var key = SortString(str);

            if (!groupAnagramsDict.ContainsKey(key))
            {
                groupAnagramsDict.Add(key, new List<string>() { str });
            }
            else
            {
                groupAnagramsDict[key].Add(str);
            }

        }

        return groupAnagramsDict.Values.Select(x=>(IList<string>)x).ToList();
    }


    public string SortString(string str)
    {
        var arr = str.ToCharArray();
        Array.Sort(arr);
        return string.Concat(arr);
    }
}