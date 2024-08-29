using System;
/*
 * 9. Palindrome Number
 */
public class Program {
    public static void Main() {
        Console.WriteLine(IsPalindrome(101));
    }
    public static bool IsPalindrome(int x) {
        string str = x.ToString();
        int left = 0;
        int right = str.Length - 1;
        long mid = left + (right - left) / 2;

        while (left <= mid) {
            if (str[left] != str[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}