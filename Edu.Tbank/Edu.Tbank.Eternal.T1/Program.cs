using System;

/*
 * Задача 1. Мобайл
 */
public class Program {
    public static void Main(string[] args) {
        var line = Console.ReadLine().Split(' ');

        byte A = byte.Parse(line[0]); //Абонентская плата
        byte B = byte.Parse(line[1]); //Количество мегабайт интернет-трафика, включенное в абонентскую плату
        byte C = byte.Parse(line[2]); //Стоимость мегабайта при выходе за лимит трафика 
        byte D = byte.Parse(line[3]); //Планирует потратить ﻿мегабайт интернет-трафика в следующий месяц

        int R = A;//В любом случае платим абонентскую плату
        if (D > B) { //Если план превышает количество мегабайт, включенное в абонентскую плату 
            R+= (D - B) * C; //Доплачиваем за потребление интернет-трафика сверх тарифа
        }
        Console.WriteLine(R);
    }
}