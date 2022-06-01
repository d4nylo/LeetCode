namespace LeetCode;

public static class Algos
{
    // https://leetcode.com/problems/contains-duplicate/
    // Time Complexity: O(n) & Space Complexity: O(n)
    public static bool ContainsDuplicate(int[] nums)
    {
        var hash = new HashSet<int>();

        for (var idx = 0; idx < nums.Length; idx++)
        {
            if (hash.Contains(nums[idx]))
            {
                return true;
            }

            hash.Add(nums[idx]);
        }

        return false;
    }
}