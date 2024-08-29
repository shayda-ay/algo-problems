using System;
using System.IO;

/*
 * Деление массивов
 */
public class Program {
    public static void Main(string[] args) { 
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        uint t = uint.Parse(input.ReadLine());
        uint mod = 1000000007;
        while (t > 0) {
            uint n = uint.Parse(input.ReadLine());
            uint[] l = input.ReadLine().Split(' ').Select(x => uint.Parse(x)).ToArray();
            uint[] r = input.ReadLine().Split(' ').Select(x => uint.Parse(x)).ToArray();
            output.WriteLine(getNumOfPossibleArrays(n, l, r, mod));
            t--;
        } 
    }

    /// <summary>
    /// Количество возможных массивов 
    /// </summary>
    /// <param name="n">Количество элементов</param>
    /// <param name="l">Ограничительный массив Мин</param>
    /// <param name="r">Ограничительный массив Макс</param>
    /// <param name="mod">Остаток от деления ответа</param>
    /// <returns></returns>
    private static long getNumOfPossibleArrays(uint n, uint[] l, uint[] r, uint mod) {
        int i = 1;
        long res = 1;
        while (i <= n) {
            uint li = l[i - 1];
            uint ri = r[i - 1];

            long min = (li + i - 1) / i;
            long max = ri / i;
            if (min > max) {
                return 0;
            }
            res = (res * (max - min + 1)) % mod;
            i++;
        }
        return res;
    }
}