using System;
using System.IO;
using System.Reflection;

/*Валидация ответа*/
public class Program {
    public static void Main(string[] args) {
        var result = new List<string>();
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
            uint n = uint.Parse(input.ReadLine());
            long[] arr = input.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
            string[] line = input.ReadLine().Split(' ');
            output.WriteLine(Valid(arr, line));
            t--;
        }
    }
    public static string Valid(long[] arr, string[] line) {
        if (arr.Length != line.Length) {
            return "no";
        }
        long tmp;
        if (arr.Length == 1 && (!long.TryParse(line[0], out tmp) || tmp != arr[0])) {
            return "no";
        }
        try {
            Array.Sort(arr);
            long[] check = line.Select(x => long.Parse(x)).ToArray();
            for (int i = 0; i < arr.Length; i++) {
                if (check[i] != arr[i] || line[i] != arr[i].ToString()) {
                    return "no";
                }
            }
            return "yes";
        } catch { return "no"; }
    }
}