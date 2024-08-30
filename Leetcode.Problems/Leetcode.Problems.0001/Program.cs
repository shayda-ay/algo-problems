using System;
using System.Collections.Generic;
/*
 * 1. Two Sum
 * https://leetcode.com/problems/two-sum/description/
 */
public class Program {
    public static void Main(string[] args) {
        int[] res = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
        Console.WriteLine(res[0] + " " + res[1]);
    }
    /// <summary>
    /// Решение со сложностью O(n), достигается за счет применения мемоизации промежуточных результатов
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int[] TwoSum(int[] nums, int target) {
        //Переменная для мемоизации
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
    /// <summary>
    /// Решение со сложностью O(n2), исключительно ради учебных целей
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum_On2(int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[j] == target - nums[i]) {
                    return new int[] { i, j };
                }
            }
        }
        return null;
    }
}
