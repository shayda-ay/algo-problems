using System;
/*
 * 27. Remove Element
 * https://leetcode.com/problems/remove-element/description/
 */
public class Program {
    public static void Main(string[] args) {
        Console.WriteLine(RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2));
    }
    public static int RemoveElement(int[] nums, int val) {
        int left = 0, right = 0;
        while (right < nums.Length) {
            if (val != nums[right]) {
                nums[left] = nums[right];
                left++;
            }
            right++;
        }
        return left;
    }
}