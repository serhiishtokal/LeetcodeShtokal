var s = "anagram";
var t = "nagaram";

var solution = new Solution();
var result = solution.IsAnagram(s,t);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if(s == t) return true;
        if(s.Length !=  t.Length) return false;

        var symbolFrequencyDictionary = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            var symbolFromS = s[i];
            var symbolFromT = t[i];

            symbolFrequencyDictionary.TryAdd(symbolFromS, 0);
            symbolFrequencyDictionary.TryAdd(symbolFromT, 0);

            symbolFrequencyDictionary[symbolFromS]++;
            symbolFrequencyDictionary[symbolFromT]--;
        }

        return symbolFrequencyDictionary.Values.All(x => x == 0);
    }
}