namespace LeetCode;

public static class Algos
{
    // https://leetcode.com/problems/contains-duplicate/
    // Time Complexity: O(n) & Space Complexity: O(n)
    public static bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        for (var idx = 0; idx < nums.Length; idx++)
        {
            if (set.Contains(nums[idx]))
            {
                return true;
            }

            set.Add(nums[idx]);
        }

        return false;
    }

    // https://leetcode.com/problems/valid-anagram/
    // Time Complexity: O(s+t) & Space Complexity: O(s+t)
    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var mapS = new Dictionary<char, int>();
        var mapT = new Dictionary<char, int>();

        for (var idx = 0; idx < s.Length; idx++)
        {
            if (!mapS.ContainsKey(s[idx]))
            {
                mapS.Add(s[idx], 0);
            }

            mapS[s[idx]]++;

            if (!mapT.ContainsKey(t[idx]))
            {
                mapT.Add(t[idx], 0);
            }

            mapT[t[idx]]++;
        }

        foreach (var key in mapS.Keys)
        {
            mapT.TryGetValue(key, out var val);

            if (mapS[key] != val)
            {
                return false;
            }
        }

        return true;
    }

    // https://leetcode.com/problems/two-sum/
    // Time Complexity: O(n) & Space Complexity: O(n)
    public static int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();

        for (var idx = 0; idx < nums.Length; idx++)
        {
            var diff = target - nums[idx];

            if (map.ContainsKey(diff))
            {
                return new int[] {map[diff], idx};
            }

            map.TryAdd(nums[idx], idx);
        }

        return new int[] {-1, -1};
    }
}