using System;

/*
 * Задача 2. Рулет
 */
public class Program {
    public static void Main(string[] args) {
        ulong N = ulong.Parse(Console.ReadLine()); // Количество людей на кофе-брйке
        ulong R = 0; //Минимальное число разрезов рулета
        while (N > 1) {
            if (N % 2 == 1) { //Если текущее число нечетное
                N += 2 - N % 2; //Находим ближайшее кратное 2
            }
            N = N / 2;
            R++;
        }
        Console.WriteLine(R);
    }
}
