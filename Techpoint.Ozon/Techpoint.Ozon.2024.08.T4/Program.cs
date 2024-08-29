using System; 
using System.IO;

/*
 * Сломанный сервер
 */
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput()); 
        using var output = new StreamWriter(Console.OpenStandardOutput());

        byte t = byte.Parse(input.ReadLine());
        while (t > 0) { 
            byte n = byte.Parse(input.ReadLine());
            uint[] arr = input.ReadLine().Split().Select(s => uint.Parse(s)).ToArray();
            if (n < 3) {
                output.WriteLine(n);
            } else { 
                byte total = 0;
                byte left = 0;
                byte prev = 0;
                while (left < n - 1) { 
                    int rigth = left + 1;
                    if (arr[rigth] == arr[left]) {
                        prev++;
                        left++; 
                        if (left == n - 1 && prev == left) {
                            total = n;
                        }
                        continue;
                    }
                    byte count = prev;
                    for (int i = rigth + 1; i < n; i++) {
                        if (arr[i] != arr[left] && arr[i] != arr[rigth]) {
                            break;
                        }
                        count++;
                    }
                    prev = 0;
                    count += 2;
                    total = Math.Max(total, count);
                    left++;
                }
                output.WriteLine(total);
            }
            t--;
        }
    }
}