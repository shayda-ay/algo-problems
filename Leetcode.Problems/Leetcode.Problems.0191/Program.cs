﻿using System;
/*
 * 191. Number of 1 Bits
 * https://leetcode.com/problems/number-of-1-bits/description/
 */
public class Program {
    public static void Main() {
        Console.WriteLine(HammingWeight(2147483645));
    } 
    public static int HammingWeight(int n) {
        int count = 0;
        while (n > 0) {
            if (n % 2 == 1) {
                count++;
            }
            n = n / 2;
        }
        return count;
    }
}
