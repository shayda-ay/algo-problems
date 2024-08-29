using System;
/*Задача B. Рулет*/
public class Program {
    public static void Main(string[] args) {
        ulong N = ulong.Parse(Console.ReadLine());
        ulong R = 0;
        while (N > 1) {
            if (N % 2 == 1) {
                N += 2 - N % 2; //Находим ближайшее кратное 2
            }
            N = N / 2;
            R++;
        }
        Console.WriteLine(R);
    }
}
