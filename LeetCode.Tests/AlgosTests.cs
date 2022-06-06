using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode.Tests;

public class AlgosTests
{
    #region Arrays & Hashing

    [Fact]
    public void Contains_Duplicate()
    {
        #region Example 1

        // Arrange
        var nums1 = new int[] {1, 2, 3, 1};

        // Act
        var output1 = Algos.ContainsDuplicate(nums1);

        // Assert
        Assert.True(output1);

        #endregion

        #region Example 2

        // Arrange
        var nums2 = new int[] {1, 2, 3, 4};

        // Act
        var output2 = Algos.ContainsDuplicate(nums2);

        // Assert
        Assert.False(output2);

        #endregion

        #region Example 3

        // Arrange
        var nums3 = new int[] {1, 1, 1, 3, 3, 4, 3, 2, 4, 2};

        // Act
        var output3 = Algos.ContainsDuplicate(nums3);

        // Assert
        Assert.True(output3);

        #endregion
    }

    [Fact]
    public void Is_Anagram()
    {
        #region Example 1

        // Arrange
        const string s1 = "anagram";
        const string t1 = "nagaram";

        // Act
        var output1 = Algos.IsAnagram(s1, t1);

        // Assert
        Assert.True(output1);

        #endregion

        #region Example 2

        // Arrange
        const string s2 = "rat";
        const string t2 = "car";

        // Act
        var output2 = Algos.IsAnagram(s2, t2);

        // Assert
        Assert.False(output2);

        #endregion
    }

    [Fact]
    public void Two_Sum()
    {
        #region Example 1

        // Arrange
        var nums1 = new int[] {2, 7, 11, 15};
        const int target1 = 9;

        // Act
        var output1 = Algos.TwoSum(nums1, target1);

        // Assert
        Assert.Equal(new int[] {0, 1}, output1);

        #endregion

        #region Example 2

        // Arrange
        var nums2 = new int[] {3, 2, 4};
        const int target2 = 6;

        // Act
        var output2 = Algos.TwoSum(nums2, target2);

        // Assert
        Assert.Equal(new int[] {1, 2}, output2);

        #endregion

        #region Example 3

        // Arrange
        var nums3 = new int[] {3, 3};
        const int target3 = 6;

        // Act
        var output3 = Algos.TwoSum(nums3, target3);

        // Assert
        Assert.Equal(new int[] {0, 1}, output3);

        #endregion
    }

    [Fact]
    public void Group_Anagrams()
    {
        #region Example 1

        // Arrange
        string[] strs1 = {"eat", "tea", "tan", "ate", "nat", "bat"};

        // Act
        var output1 = Algos.GroupAnagrams(strs1);

        // Assert
        IList<IList<string>> expected1 = new List<IList<string>>();
        expected1.Add(new string[] {"bat"});
        expected1.Add(new string[] {"nat", "tan"});
        expected1.Add(new string[] {"ate", "eat", "tea"});
        output1.Should().BeEquivalentTo(expected1);

        #endregion

        #region Example 2

        // Arrange
        string[] strs2 = {""};

        // Act
        var output2 = Algos.GroupAnagrams(strs2);

        // Assert
        IList<IList<string>> expected2 = new List<IList<string>>();
        expected2.Add(new string[] {""});
        output2.Should().BeEquivalentTo(expected2);

        #endregion

        #region Example 3

        // Arrange
        string[] strs3 = {"a"};

        // Act
        var output3 = Algos.GroupAnagrams(strs3);

        // Assert
        IList<IList<string>> expected3 = new List<IList<string>>();
        expected3.Add(new string[] {"a"});
        output3.Should().BeEquivalentTo(expected3);

        #endregion
    }

    [Fact]
    public void Top_K_Frequent()
    {
        #region Example 1

        // Arrange
        var nums1 = new int[] {1, 1, 1, 2, 2, 3};
        const int k1 = 2;

        // Act
        var output1 = Algos.TopKFrequent(nums1, k1);

        // Assert
        Assert.Equal(new int[] {1, 2}, output1);

        #endregion

        #region Example 2

        // Arrange
        var nums2 = new int[] {1};
        const int k2 = 1;

        // Act
        var output2 = Algos.TopKFrequent(nums2, k2);

        // Assert
        Assert.Equal(new int[] {1}, output2);

        #endregion
    }

    [Fact]
    public void Product_Except_Self()
    {
        #region Example 1

        // Arrange
        var nums1 = new int[] {1, 2, 3, 4};

        // Act
        var output1 = Algos.ProductExceptSelf(nums1);

        // Assert
        Assert.Equal(new int[] {24, 12, 8, 6}, output1);

        #endregion

        #region Example 2

        // Arrange
        var nums2 = new int[] {-1, 1, 0, -3, 3};

        // Act
        var output2 = Algos.ProductExceptSelf(nums2);

        // Assert
        Assert.Equal(new int[] {0, 0, 9, 0, 0}, output2);

        #endregion
    }

    [Fact]
    public void Is_Valid_Sudoku()
    {
        #region Example 1

        // Arrange
        char[][] board1 =
        {
            new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
            new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
        };

        // Act
        var output1 = Algos.IsValidSudoku(board1);

        // Assert
        Assert.True(output1);

        #endregion

        #region Example 2

        // Arrange
        char[][] board2 =
        {
            new char[] {'8', '3', '.', '.', '7', '.', '.', '.', '.'},
            new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
        };

        // Act
        var output2 = Algos.IsValidSudoku(board2);

        // Assert
        Assert.False(output2);

        #endregion
    }

    [Fact]
    public void Longest_Consecutive()
    {
        #region Example 1

        // Arrange
        var nums1 = new int[] {100, 4, 200, 1, 3, 2};

        // Act
        var output1 = Algos.LongestConsecutive(nums1);

        // Assert
        Assert.Equal(4, output1);

        #endregion

        #region Example 2

        // Arrange
        var nums2 = new int[] {0, 3, 7, 2, 5, 8, 4, 6, 0, 1};

        // Act
        var output2 = Algos.LongestConsecutive(nums2);

        // Assert
        Assert.Equal(9, output2);

        #endregion
    }

    #endregion

    #region Two Pointers

    [Fact]
    public void Is_Palindrome()
    {
        #region Example 1

        // Arrange
        const string s1 = "A man, a plan, a canal: Panama";

        // Act
        var output1 = Algos.IsPalindrome(s1);

        // Assert
        Assert.True(output1);

        #endregion

        #region Example 2

        // Arrange
        const string s2 = "race a car";

        // Act
        var output2 = Algos.IsPalindrome(s2);

        // Assert
        Assert.False(output2);

        #endregion

        #region Example 3

        // Arrange
        const string s3 = " ";

        // Act
        var output3 = Algos.IsPalindrome(s3);

        // Assert
        Assert.True(output3);

        #endregion
    }

    [Fact]
    public void Two_Sum_2()
    {
        #region Example 1

        // Arrange
        var numbers1 = new int[] {2, 7, 11, 15};
        const int target1 = 9;

        // Act
        var output1 = Algos.TwoSum2(numbers1, target1);

        // Assert
        Assert.Equal(new int[] {1, 2}, output1);

        #endregion

        #region Example 2

        // Arrange
        var numbers2 = new int[] {2, 3, 4};
        const int target2 = 6;

        // Act
        var output2 = Algos.TwoSum2(numbers2, target2);

        // Assert
        Assert.Equal(new int[] {1, 3}, output2);

        #endregion

        #region Example 3

        // Arrange
        var numbers3 = new int[] {-1, 0};
        const int target3 = -1;

        // Act
        var output3 = Algos.TwoSum2(numbers3, target3);

        // Assert
        Assert.Equal(new int[] {1, 2}, output3);

        #endregion
    }

    [Fact]
    public void Three_Sum()
    {
        #region Example 1

        // Arrange
        int[] nums1 = {-1, 0, 1, 2, -1, -4};

        // Act
        var output1 = Algos.ThreeSum(nums1);

        // Assert
        IList<IList<int>> expected1 = new List<IList<int>>();
        expected1.Add(new int[] {-1, -1, 2});
        expected1.Add(new int[] {-1, 0, 1});
        output1.Should().BeEquivalentTo(expected1);

        #endregion

        #region Example 2

        // Arrange
        int[] nums2 = { };

        // Act
        var output2 = Algos.ThreeSum(nums2);

        // Assert
        output2.Should().BeEquivalentTo(new List<IList<int>>());

        #endregion

        #region Example 3

        // Arrange
        int[] nums3 = {0};

        // Act
        var output3 = Algos.ThreeSum(nums3);

        // Assert
        output3.Should().BeEquivalentTo(new List<IList<int>>());

        #endregion
    }

    [Fact]
    public void Max_Area()
    {
        #region Example 1

        // Arrange
        var height1 = new int[] {1, 8, 6, 2, 5, 4, 8, 3, 7};

        // Act
        var output1 = Algos.MaxArea(height1);

        // Assert
        Assert.Equal(49, output1);

        #endregion

        #region Example 2

        // Arrange
        var height2 = new int[] {1, 1};

        // Act
        var output2 = Algos.MaxArea(height2);

        // Assert
        Assert.Equal(1, output2);

        #endregion
    }

    [Fact]
    public void Trap()
    {
        #region Example 1

        // Arrange
        var height1 = new int[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};

        // Act
        var output1 = Algos.Trap(height1);

        // Assert
        Assert.Equal(6, output1);

        #endregion

        #region Example 2

        // Arrange
        var height2 = new int[] {4, 2, 0, 3, 2, 5};

        // Act
        var output2 = Algos.Trap(height2);

        // Assert
        Assert.Equal(9, output2);

        #endregion
    }

    #endregion

    #region Sliding Window

    [Fact]
    public void Max_Profit()
    {
        #region Example 1

        // Arrange
        var prices1 = new int[] {7, 1, 5, 3, 6, 4};

        // Act
        var output1 = Algos.MaxProfit(prices1);

        // Assert
        Assert.Equal(5, output1);

        #endregion

        #region Example 2

        // Arrange
        var prices2 = new int[] {7, 6, 4, 3, 1};

        // Act
        var output2 = Algos.MaxProfit(prices2);

        // Assert
        Assert.Equal(0, output2);

        #endregion
    }

    [Fact]
    public void Length_Of_Longest_Substring()
    {
        #region Example 1

        // Arrange
        const string s1 = "abcabcbb";

        // Act
        var output1 = Algos.LengthOfLongestSubstring(s1);

        // Assert
        Assert.Equal(3, output1);

        #endregion

        #region Example 2

        // Arrange
        const string s2 = "bbbbb";

        // Act
        var output2 = Algos.LengthOfLongestSubstring(s2);

        // Assert
        Assert.Equal(1, output2);

        #endregion

        #region Example 3

        // Arrange
        const string s3 = "pwwkew";

        // Act
        var output3 = Algos.LengthOfLongestSubstring(s3);

        // Assert
        Assert.Equal(3, output3);

        #endregion
    }

    [Fact]
    public void Character_Replacement()
    {
        #region Example 1

        // Arrange
        const string s1 = "ABAB";
        const int k1 = 2;

        // Act
        var output1 = Algos.CharacterReplacement(s1, k1);

        // Assert
        Assert.Equal(4, output1);

        #endregion

        #region Example 2

        // Arrange
        const string s2 = "AABABBA";
        const int k2 = 1;

        // Act
        var output2 = Algos.CharacterReplacement(s2, k2);

        // Assert
        Assert.Equal(4, output2);

        #endregion
    }

    #endregion

    #region Stack

    [Fact]
    public void Is_Valid()
    {
        #region Example 1

        // Arrange
        const string s1 = "()";

        // Act
        var output1 = Algos.IsValid(s1);

        // Assert
        Assert.True(output1);

        #endregion

        #region Example 2

        // Arrange
        const string s2 = "()[]{}";

        // Act
        var output2 = Algos.IsValid(s2);

        // Assert
        Assert.True(output2);

        #endregion

        #region Example 3

        // Arrange
        const string s3 = "(]";

        // Act
        var output3 = Algos.IsValid(s3);

        // Assert
        Assert.False(output3);

        #endregion
    }

    #endregion
}