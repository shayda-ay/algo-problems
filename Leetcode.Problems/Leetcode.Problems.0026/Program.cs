using System;
/*
 * 26. Remove Duplicates from Sorted Array
 * https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
 */
public class Program {
    public static void Main(string[] args) {
        Console.WriteLine(RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
    }
    public static int RemoveDuplicates(int[] nums) {
        int left = 0;
        int right = 1;
        while (right < nums.Length) {
            if (nums[right] != nums[left]) {
                nums[++left] = nums[right];
            }
            right++;
        }
        return left + 1;
    }
}