using System;
using System.Linq;

/*
 * Задача 3. Лифты и переговорки. 
 * Partial Solution — Частичное решение. Пройденные тесты — 20
*/
public class Program {
    public static void Main(string[] args) {
        var line = Console.ReadLine().Split(' ');

        byte n = byte.Parse(line[0]); // количество сотрудников
        byte t = byte.Parse(line[1]); //время, когда один из сотрудников покинет офис

        byte[] floors = Console.ReadLine().Split(' ').Select(x => byte.Parse(x)).ToArray(); //номера этажей, на которых находятся сотрудники
        int emp_i = byte.Parse(Console.ReadLine()) - 1; //номер сотрудника, который уйдет через t минут (индекс в массиве идет с 0)

        int emp_t = floors[emp_i] - 1;  //время до этажа сотрудника, который уйдет (на 1 меньше, чем этаж)
        int last = floors.Length - 1; //индекс последнего этажа

        int R = floors[last] - floors[0]; //результат если мы успеваем дойти до этажа сотрудника
        if (t < emp_t) { //если дойти не успеваем
            int Rtop = R + floors[last] - floors[emp_i]; //пытаемся идти вверх, потом вниз
            int Rbottom = R + floors[emp_i] - floors[0]; //пытаемся идти вниз, потом вверх
            R = Math.Min(Rbottom, Rtop); //выбираем минимальный путь
        }
        Console.WriteLine(R);
    }
}
