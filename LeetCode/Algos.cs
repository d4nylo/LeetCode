using Microsoft.VisualBasic;

namespace LeetCode;

public static class Algos
{
    #region Arrays & Hashing

    // https://leetcode.com/problems/contains-duplicate/
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

    // https://leetcode.com/problems/group-anagrams/
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var res = new List<IList<string>>();

        if (strs.Length == 0)
        {
            return res;
        }

        var map = new Dictionary<string, List<string>>();

        foreach (var s in strs)
        {
            var hash = new char[26];

            foreach (var c in s.ToCharArray())
            {
                hash[c - 'a']++;
            }

            var str = new string(hash);

            if (!map.ContainsKey(str))
            {
                map.Add(str, new List<string>());
            }

            map[str].Add(s);
        }

        foreach (var val in map.Values)
        {
            res.Add(val);
        }

        return res;
    }

    // https://leetcode.com/problems/top-k-frequent-elements/
    public static int[] TopKFrequent(int[] nums, int k)
    {
        var occurrences = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!occurrences.ContainsKey(num))
            {
                occurrences.Add(num, 0);
            }

            occurrences[num]++;
        }

        return occurrences.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();
    }

    // https://leetcode.com/problems/product-of-array-except-self/
    public static int[] ProductExceptSelf(int[] nums)
    {
        var res = new int[nums.Length];

        res[0] = 1;

        var prefix = 1;

        for (var idx = 0; idx < nums.Length; idx++)
        {
            res[idx] = prefix;
            prefix *= nums[idx];
        }

        var postfix = 1;

        for (var idx = nums.Length - 1; idx >= 0; idx--)
        {
            res[idx] *= postfix;
            postfix *= nums[idx];
        }

        return res;
    }

    // https://leetcode.com/problems/valid-sudoku/
    public static bool IsValidSudoku(char[][] board)
    {
        var seen = new HashSet<string>();

        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                var currentValue = board[i][j];

                if (currentValue != '.')
                {
                    if (!seen.Add($"{currentValue} found in row {i}") ||
                        !seen.Add($"{currentValue} found in column {j}") ||
                        !seen.Add($"{currentValue} found in sub box {i / 3} - {j / 3}"))
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    // https://leetcode.com/problems/longest-consecutive-sequence/
    public static int LongestConsecutive(int[] nums)
    {
        var numsSet = new HashSet<int>(nums);

        var maxSequenceLength = 0;

        for (var idx = 0; idx < nums.Length; idx++)
        {
            var currentNum = nums[idx];
            var currentSequenceLength = 1;

            if (!numsSet.Contains(currentNum - 1))
            {
                while (numsSet.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentSequenceLength++;
                }

                if (currentSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                }
            }
        }

        return maxSequenceLength;
    }

    #endregion

    #region Two Pointers

    // https://leetcode.com/problems/valid-palindrome/
    public static bool IsPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
            }
            else if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
            }
            else
            {
                if (char.ToUpper(s[left]) != char.ToUpper(s[right]))
                {
                    return false;
                }

                left++;
                right--;
            }
        }

        return true;
    }

    // https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    public static int[] TwoSum2(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;

        while (left < right)
        {
            var currSum = numbers[left] + numbers[right];

            if (currSum > target)
            {
                right--;
            }
            else if (currSum < target)
            {
                left++;
            }
            else
            {
                break;
            }
        }

        return new int[] {left + 1, right + 1};
    }

    // https://leetcode.com/problems/3sum/
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        var res = new List<IList<int>>();

        Array.Sort(nums);

        for (var idx = 0; idx < nums.Length; idx++)
        {
            if (idx > 0 && nums[idx] == nums[idx - 1])
            {
                continue;
            }

            var left = idx + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var threeSum = nums[idx] + nums[left] + nums[right];

                if (threeSum > 0)
                {
                    right--;
                }
                else if (threeSum < 0)
                {
                    left++;
                }
                else
                {
                    res.Add(new List<int>() {nums[idx], nums[left], nums[right]});
                    left++;

                    while (nums[left] == nums[left - 1] && left < right)
                    {
                        left++;
                    }
                }
            }
        }

        return res;
    }

    // https://leetcode.com/problems/container-with-most-water/
    public static int MaxArea(int[] height)
    {
        var maxArea = 0;
        var left = 0;
        var right = height.Length - 1;

        while (left < right)
        {
            var currArea = (right - left) * Math.Min(height[left], height[right]);

            if (currArea > maxArea)
            {
                maxArea = currArea;
            }

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }

    // https://leetcode.com/problems/trapping-rain-water/
    public static int Trap(int[] height)
    {
        if (height.Length == 0)
            return 0;

        int left = 0, right = height.Length - 1;
        int leftMax = height[left], rightMax = height[right];
        var res = 0;

        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;

                if (height[left] > leftMax)
                    leftMax = height[left];

                res += leftMax - height[left];
            }
            else
            {
                right--;

                if (height[right] > rightMax)
                    rightMax = height[right];

                res += rightMax - height[right];
            }
        }

        return res;
    }

    #endregion

    #region Sliding Window

    // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    public static int MaxProfit(int[] prices)
    {
        var left = 0; // buy
        var right = 1; // sell
        var maxProfit = 0;

        while (right < prices.Length)
        {
            if (prices[left] < prices[right])
            {
                var profit = prices[right] - prices[left];

                if (profit > maxProfit)
                    maxProfit = profit;
            }
            else
            {
                left = right;
            }

            right++;
        }

        return maxProfit;
    }

    // https://leetcode.com/problems/longest-substring-without-repeating-characters/
    public static int LengthOfLongestSubstring(string s)
    {
        if (s.Length <= 1)
            return s.Length;

        int left = 0, right = 0;
        var longest = 0;
        var window = new HashSet<char>();

        while (right < s.Length)
        {
            if (!window.Contains(s[right]))
            {
                window.Add(s[right]);
                right++;
            }
            else
            {
                window.Remove(s[left]);
                left++;
            }

            var currLongest = right - left;

            if (currLongest > longest)
                longest = currLongest;
        }

        return longest;
    }

    // https://leetcode.com/problems/longest-repeating-character-replacement/
    public static int CharacterReplacement(string s, int k)
    {
        var charCounts = new int[26];
        int start = 0, maxCount = 0, maxLength = 0;

        for (var end = 0; end < s.Length; end++)
        {
            charCounts[s[end] - 'A']++;

            if (charCounts[s[end] - 'A'] > maxCount)
                maxCount = charCounts[s[end] - 'A'];

            while (end - start + 1 - maxCount > k)
            {
                charCounts[s[start] - 'A']--;
                start++;
            }

            if (end - start + 1 > maxLength)
                maxLength = end - start + 1;
        }

        return maxLength;
    }

    #endregion

    #region Stack

    // https://leetcode.com/problems/valid-parentheses/
    public static bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var closeToOpen = new Dictionary<char, char>()
        {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };

        foreach (var ch in s)
        {
            if (closeToOpen.ContainsKey(ch))
            {
                if (stack.Count > 0 && stack.Peek() == closeToOpen[ch])
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                stack.Push(ch);
            }
        }

        return stack.Count == 0;
    }

    // https://leetcode.com/problems/evaluate-reverse-polish-notation/
    public static int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();

        foreach (var token in tokens)
        {
            if (token == "+" || token == "-" || token == "/" || token == "*")
            {
                var num1 = stack.Pop();
                var num2 = stack.Pop();

                switch (token)
                {
                    case "+":
                        stack.Push(num1 + num2);
                        break;
                    case "-":
                        stack.Push(num2 - num1);
                        break;
                    case "/":
                        stack.Push(num2 / num1);
                        break;
                    case "*":
                        stack.Push(num1 * num2);
                        break;
                }
            }
            else
            {
                stack.Push(Convert.ToInt32(token));
            }
        }

        return stack.Peek();
    }

    // https://leetcode.com/problems/generate-parentheses/
    public static IList<string> GenerateParenthesis(int n)
    {
        var res = new List<string>();

        void Backtrack(List<string> arr, string currentString, int opened, int closed, int max)
        {
            if (currentString.Length == max * 2)
            {
                arr.Add(currentString);
                return;
            }

            if (opened < max)
                Backtrack(arr, currentString + "(", opened + 1, closed, max);

            if (closed < opened)
                Backtrack(arr, currentString + ")", opened, closed + 1, max);
        }

        Backtrack(res, "", 0, 0, n);

        return res;
    }

    #endregion

    #region Binary Search

    // https://leetcode.com/problems/binary-search/
    public static int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var middle = (right + left) / 2; // Or... left + ((right-left) / 2)

            if (target > nums[middle])
            {
                left = middle + 1;
            }
            else if (target < nums[middle])
            {
                right = middle - 1;
            }
            else
            {
                return middle;
            }
        }

        return -1;
    }

    // https://leetcode.com/problems/search-a-2d-matrix/
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        var totalRows = matrix.Length;
        var totalCols = matrix[0].Length;
        var top = 0;
        var bottom = totalRows - 1;

        while (top <= bottom)
        {
            var middle = (top + bottom) / 2;

            if (target > matrix[middle][totalCols - 1])
            {
                top = middle + 1;
            }
            else if (target < matrix[middle][0])
            {
                bottom = middle - 1;
            }
            else
            {
                break;
            }
        }

        // None of the rows contains the target value.
        if (!(top <= bottom))
            return false;

        var row = (top + bottom) / 2;
        var left = 0;
        var right = totalCols - 1;

        while (left <= right)
        {
            var middle = (left + right) / 2;

            if (target > matrix[row][middle])
            {
                left = middle + 1;
            }
            else if (target < matrix[row][middle])
            {
                right = middle - 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    // https://leetcode.com/problems/koko-eating-bananas/
    public static int MinEatingSpeed(int[] piles, int h)
    {
        var left = 1;
        var right = int.MaxValue;

        while (left <= right)
        {
            var middle = left + ((right - left) / 2);
            var hourSum = 0;

            foreach (var p in piles)
            {
                hourSum += (p + middle - 1) / middle;
            }

            if (hourSum > h)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return left;
    }

    #endregion
}