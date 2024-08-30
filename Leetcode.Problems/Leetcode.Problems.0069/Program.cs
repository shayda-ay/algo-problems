using System;
/*
 * 69. Sqrt(x)
 * https://leetcode.com/problems/sqrtx/description/
 */
public class Program {
    public static void Main(string[] args) {
        Console.WriteLine(MySqrt(11));
    } 
    public static int MySqrt(int x) {
        long left = 0;
        long right = x;
        while (left <= right) {
            long mid = (left + right) / 2;
            if (mid * mid == x) {
                return (int)mid;
            }
            if (mid * mid < x) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return (int)right;
    }
}