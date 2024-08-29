using System;
using System.IO;
using System.Text;

/*
 * Удалить цифру из числа
 */
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
            string s = input.ReadLine();
            output.WriteLine(DelNumber(s));
            t--;
        } 
    }
    private static string DelNumber(string s) {
        if (s.Length < 2) {
            return "0";
        }
        int right = 1;
        while (right < s.Length) { 
            if (s[right] > s[right - 1]) {
                break;
            }
            right++;
        }
        return s.Remove(right - 1, 1);
    } 
}
