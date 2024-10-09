using System;
using System.IO;

/*Галерея искусств*/
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());
        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
             
            output.WriteLine();
            t--;
        }
    }
}
