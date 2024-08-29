using System;
using System.IO;

/*Похожие логины*/
public class Program {
    public static void Main(string[] args) { 
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        ushort n = ushort.Parse(input.ReadLine());
        Dictionary<char, List<string>> Employees = new Dictionary<char, List<string>>();
        while (n > 0) {
            string employee = input.ReadLine();
            char key = employee[0];
            if (Employees.ContainsKey(key)) {
                Employees[key].Add(employee);
            } else {
                Employees.Add(key, new List<string>() { employee });
            }
            n--;
        }
        ushort m = ushort.Parse(input.ReadLine());
        while (m > 0) {
            var candidate = input.ReadLine();
            byte f = 0;
            if (Employees.ContainsKey(candidate[0])) {
                f = IsSimilar(Employees[candidate[0]], candidate);
            }
            if (f == 0 && candidate.Length > 1 && Employees.ContainsKey(candidate[1])) {
                f = IsSimilar(Employees[candidate[1]], candidate);
            }
            output.WriteLine(f);
            m--;
        } 
    } 
    private static byte IsSimilar(IList<string> employees, string candidate) {
        if (employees.Count == 0) {
            return 0;
        }
        foreach (var it in employees) {
            if (it.Length != candidate.Length) {
                continue;
            }
            if (candidate == it) {
                return 1;
            }
            ushort i = 0;
            byte change = 0;
            for (i = 0; i < candidate.Length; i++) {
                if (candidate[i] != it[i]) {
                    if (i != candidate.Length - 1 && candidate[i] == it[i + 1] && it[i] == candidate[i + 1]) {
                        if (change != 0) {
                            break;
                        }
                        i++;
                        change++;
                        continue;
                    }
                    break;
                }
            }
            if (i == candidate.Length) {
                return 1;
            }
        }
        return 0;
    }
} 