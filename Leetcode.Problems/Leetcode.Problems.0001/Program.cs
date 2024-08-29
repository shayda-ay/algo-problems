using System;
using System.Collections.Generic;
/*
 * 1. Two Sum
 */
public class Program {
    public static void Main(string[] args) {
        int[] res = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
        Console.WriteLine(res[0] + " " + res[1]);
    }

    public static int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            int cur = nums[i];
            int x = target - cur;
            if (map.ContainsKey(x)) {
                return new int[] { map[x], i };
            }
            if (!map.ContainsKey(cur)) {
                map.Add(cur, i);
            }
        }
        return null;
    }
}
