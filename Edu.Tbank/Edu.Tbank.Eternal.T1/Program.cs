using System;
/*Задача A. Мобайл*/
public class Program {
    public static void Main(string[] args) {
        var line = Console.ReadLine().Split(' ');

        byte A = byte.Parse(line[0]);
        byte B = byte.Parse(line[1]);
        byte C = byte.Parse(line[2]);
        byte D = byte.Parse(line[3]);

        int R = A;
        if (D > B) {
            R = (D - B) * C + A;
        }
        Console.WriteLine(R);
    }
}