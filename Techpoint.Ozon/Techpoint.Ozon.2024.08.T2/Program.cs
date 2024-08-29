using System;
using System.Globalization;
using System.IO;

/*
 * Ошибка округления
 */
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = int.Parse(input.ReadLine());
        while (t > 0) {
            string[] s = input.ReadLine().Split();
            decimal sum = 0;
            uint n = uint.Parse(s[0]);
            decimal p = byte.Parse(s[1]) * 0.01m;
            while (n > 0) {
                uint a = uint.Parse(input.ReadLine());
                decimal k = a * p;
                sum += k - Math.Floor(k);
                n--;
            }
            t--;
            output.WriteLine(sum.ToString("F", CultureInfo.InvariantCulture));
        }
    }
}