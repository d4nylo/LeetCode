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
}