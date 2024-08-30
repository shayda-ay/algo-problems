using System;
/*
 * 58. Length of Last Word
 * https://leetcode.com/problems/length-of-last-word/description/
 */
public class Program {
    public static void Main(string[] args) {
        Console.WriteLine(LengthOfLastWord("Try programiz. pro"));
    } 
    public static int LengthOfLastWord(string s) {
        int size = 0;
        int last = s.Length;
        while (last > 0) {
            last--;
            if (s[last] == ' ') {
                if (size == 0) {
                    continue;
                }
                break;
            }
            size++;
        }
        return size;
    }
}
