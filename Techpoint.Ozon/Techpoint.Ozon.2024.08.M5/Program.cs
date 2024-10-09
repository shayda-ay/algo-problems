using System;
using System.IO; 

/*YAML to INI*/
public class Program {
    public static void Main(string[] args) {
        //using var input = new StreamReader(Console.OpenStandardInput());
        using var input = new StreamReader("c:\\Users\\shayda\\Downloads\\ini-to-yaml\\1");
        using var output = new StreamWriter(Console.OpenStandardOutput());
        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
            uint n = uint.Parse(input.ReadLine());
            var stack = new Stack<string>(); // стек с названиями словарей
            while (n > 0) {
                var line = input.ReadLine(); // считать очередную строку
                var trimLine = line.Trim();
                int level = (line.Length - trimLine.Length) / 4; // уровень  вложенности словаря
                if (line.Last() == ':') {// если словарь
                    stack.Push(trimLine); // добавить словарь в стек
                } else {
                    if (stack.Count > 0) { // если стек не пустой
                        output.WriteLine("[" + string.Join(".", stack) + "]"); //напечатать все словари через точку
                    }
                    var split = line.Split(':'); // разбить пару «ключ значение» на ключ и значение
                    output.WriteLine(split[0].Trim()+ " = "+ split[1].Trim()); //напечатать пару «ключ значение»
                    output.WriteLine(); // напечатать пустую строку
                } 
                n--;
            }
            t--;
        }
    }
}
