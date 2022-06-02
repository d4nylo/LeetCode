using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode.Tests;

public class AlgosTests
{
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
}