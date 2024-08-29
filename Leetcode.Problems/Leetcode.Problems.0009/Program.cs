using System;
/*
 * 9. Palindrome Number
 */
public class Program {
    public static void Main() {
        Console.WriteLine(IsPalindrome(101));
        Console.WriteLine(IsPalindrome2(101));
    }
    public static bool IsPalindrome(int x) {
        if (x < 0)
            return false;
        if (x < 10)
            return true;

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
    public static bool IsPalindrome2(int x) {
        if (x < 0)
            return false;
        if (x < 10)
            return true;

        int y = 0;
        int tmp = x;
        while (tmp != 0) {
            int p = tmp % 10;
            y = y * 10 + p;
            tmp /= 10;
        }
        return (x == y);
    }
}