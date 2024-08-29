using System;
using System.IO;

/*Зеркальные пары*/
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());
        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
            uint n = uint.Parse(input.ReadLine()); //длина массива 
            long[] arr = input.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray(); //массив
            var dic = new Dictionary<long, ulong>();
            uint cur = 1;
            ulong r = 0;
            while (cur < arr.Length - 1) {
                long x = arr[cur] - arr[cur + 1];
                if (dic.ContainsKey(x)) {
                    r += dic[x];
                }
                x = arr[cur - 1] - arr[cur];
                if (dic.ContainsKey(x)) {
                    dic[x]++;
                } else {
                    dic.Add(x, 1);
                }
                cur++;
            }
            output.WriteLine(r);
            t--;
        }
    }
}
