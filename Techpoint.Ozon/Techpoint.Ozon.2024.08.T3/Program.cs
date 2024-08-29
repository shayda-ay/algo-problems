using System; 
using System.IO;

/*Корень дерева*/
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        byte t = byte.Parse(input.ReadLine());
        while (t > 0) {
            byte m = byte.Parse(input.ReadLine());
            byte[] arr = input.ReadLine().Split().Select(s => byte.Parse(s)).ToArray();
            Dictionary<byte, bool> vrtx = new Dictionary<byte, bool>();
            int left = 0;
            while (left < m - 1) {
                if (!vrtx.ContainsKey(arr[left])) {
                    vrtx.Add(arr[left], false);
                }
                int rigth = left + 2;
                left += arr[left + 1] + 2;
                while (rigth < left) {
                    if (vrtx.ContainsKey(arr[rigth])) {
                        vrtx[arr[rigth]] = true;
                    } else {
                        vrtx.Add(arr[rigth], true);
                    }
                    rigth++;
                }
            }
            output.WriteLine(vrtx.Where(x => x.Value == false).Select(x => x.Key).FirstOrDefault());
            t--;
        }
    }
}