using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Задача 4. Бумажки
 */
public class Program {
    public static void Main(string[] args) {
        var line = Console.ReadLine().Split(' ');
        ushort n = ushort.Parse(line[0]); //n — количество чисел на бумажке
        int k = int.Parse(line[1]); //k﻿ — ограничение на число операций  
        line = Console.ReadLine().Split(' ');//числа на бумажке

        int nj;
        var dic = new Dictionary<ushort, int[]>();
        for (ushort i = 0; i < line.Length; i++) {
            dic.Add(i, new int[9]);

            nj = 8;
            for (int j = line[i].Length - 1; j >= 0; j--) {
                dic[i][nj] = 9 - int.Parse(line[i][j].ToString());
                nj--;
            }
        }

        long R = 0;
        nj = 0;
        while (k > 0 && nj < 9) {
            var sort_arr = dic.Values.Select(x => x[nj]).ToArray();
            Array.Sort(sort_arr, (a, b) => b.CompareTo(a));

            for (int i = 0; i < sort_arr.Length; i++) {
                if (sort_arr[i] == 0) {
                    break;
                }

                R += sort_arr[i] * (long)Math.Pow(10, 8 - nj);
                k--;
                if (k == 0) {
                    break;
                }
            }

            nj++;
        }
        Console.WriteLine(R);
    }
}