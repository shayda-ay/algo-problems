using System;
using System.IO;

/*YAML to INI*/
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());
        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
            uint n = uint.Parse(input.ReadLine());
            var stack = new Stack<string>(); // стек с названиями словарей
            int prevLevel = 0; // вложенность стека который был напечатан на предыдущем шаге
            bool needLine = false; //нужно ли печатать пустую строку перед блоком
            while (n > 0) {
                var line = input.ReadLine(); // считать очередную строку
                var trimLine = line.Trim();
                int level = (line.Length - trimLine.Length) / 4; // уровень  вложенности словаря

                // обрезать стек по текущей вложенности
                int cut = stack.Count - level; 
                while (cut > 0) {
                    stack.Pop();
                    cut--;
                }

                if (line.Last() == ':') {// если словарь
                    stack.Push(trimLine.Substring(0, trimLine.Length - 1)); // добавить словарь в стек
                } else {
                    if (level != prevLevel) { // если стек изменился
                        if (needLine) {// если нужно напечатать пустую строку перед блоком
                            output.WriteLine(); // напечатать пустую строку
                        }

                        if (stack.Count > 0) { // если стек не пустой 
                            output.WriteLine("[" + string.Join(".", stack.Reverse()) + "]"); //напечатать все словари через точку
                        }
                    }
                    needLine = true; // теперь нужно печатать пустую строку перед каждым блоком
                    var split = line.Split(':'); // разбить пару «ключ значение» на ключ и значение
                    output.WriteLine(split[0].Trim() + " = " + split[1].Trim()); //напечатать пару «ключ значение»
                }
                prevLevel = level; // запомнить текущий уровень вложенности
                n--;
            }
            output.WriteLine(); // напечатать пустую строку
            t--;
        }
    }
}
