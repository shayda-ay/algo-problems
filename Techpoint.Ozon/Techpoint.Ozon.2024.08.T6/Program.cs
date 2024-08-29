using System;
using System.IO;

/*
 * Упаковка коробок
 * Частичное решение!!!!
 */
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        byte t = byte.Parse(input.ReadLine());
        while (t > 0) {
            var line = input.ReadLine().Split();
            ushort n = ushort.Parse(line[0]); //количество машин
            uint k = uint.Parse(line[1]); //грузоподъемность машин
            ushort m = ushort.Parse(input.ReadLine()); //количество коробок
            uint[] w = input.ReadLine().Split().Select(x => (uint)Math.Pow(2, byte.Parse(x))).ToArray(); // вес i-й коробки

            Array.Sort(w, (a, b) => b.CompareTo(a));
            int r1 = minTransport(w, k, n);

            output.WriteLine(r1);
            t--;
        }
    }
    private static int minTransport(uint[] arr, uint k, ushort n) {
        int left = 0;
        int right = 0;
        int count = 0;
        uint sum = 0;
        while (left < arr.Length) {
            if (arr[left] == 0) {
                left++;
                continue;
            }
            sum = arr[left];
            right = left + 1;
            while (right < arr.Length) {
                if (sum + arr[right] > k) {
                    right++;
                    continue;
                }
                sum += arr[right];
                arr[right] = 0;
                right++;
            }
            left++;
            count++;
        }
        return (count + n - 1) / n;
    }
}