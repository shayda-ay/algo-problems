using System;

public class Program {
    public static void Main() {
        Console.WriteLine(HammingWeight(2147483645));
    }

    public static int HammingWeight(int n) {
        int count = 0;
        while (n > 0) {
            if (n % 2 == 1) {
                count++;
            }
            n = n / 2;
        }
        return count;
    }
}
