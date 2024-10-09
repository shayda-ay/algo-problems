using System;
using System.IO;

/*Крестики-нолики*/
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());
        ushort t = ushort.Parse(input.ReadLine());
        while (t > 0) {
            int k = int.Parse(input.ReadLine()); //необходимая для победы длина строки, столбца или диагонали
            string[] line = input.ReadLine().Split(' ');
            int n = int.Parse(line[0]); //количество строк на доске
            int m = int.Parse(line[1]); //количество столбцов на доске

            int[,] board = new int[n, m];
            for (int i = 0; i < n; i++) {
                string s = input.ReadLine();
                for (int j = 0; j < s.Length; j++) {
                    switch (s[j]) {
                        case '.': {
                            board[i, j] = 2;
                            break;
                        }
                        case 'O': {
                            board[i, j] = 0;
                            break;
                        }
                        case 'X': {
                            board[i, j] = 1;
                            break;
                        }
                    }
                }
            }

            string msg = Start(board, n, m, k, "NO", Win);
            if (string.IsNullOrEmpty(msg)) {
                msg = Start(board, n, m, k, "YES", PreWin);
            }
            if (!string.IsNullOrEmpty(msg)) {
                output.WriteLine(msg);
            } else {
                output.WriteLine("NO");
            }
            t--;
        }
    }

    static bool Ok(int n, int m, int x, int y) {
        return 0 <= x && x < n && 0 <= y && y < m;
    } 
    static bool Win(int[,] board, int n, int m, int x, int y, int dx, int dy, int k) {
        int[] sum = new int[3];
        while (Ok(n, m, x, y)) {
            sum[board[x, y]]++;
            x += dx;
            y += dy;
            if (Ok(n, m, x - k * dx, y - k * dy)) {
                if (sum[0] == k || sum[1] == k) {
                    return true;
                }
                sum[board[x - k * dx, y - k * dy]]--;
            }
        }
        return false;
    }
    static bool PreWin(int[,] board, int n, int m, int x, int y, int dx, int dy, int k) {
        int[] sum = new int[3];
        while (Ok(n, m, x, y)) {
            sum[board[x, y]]++;
            x += dx;
            y += dy;
            if (Ok(n, m, x - k * dx, y - k * dy)) {
                if (sum[1] == k-1 && sum[2] == 1) {
                    return true;
                }
                sum[board[x - k * dx, y - k * dy]]--;
            }
        }
        return false;
    }


    static string Start(int[,] board, int n, int m, int k, string message, Func<int[,] , int , int , int , int , int , int , int, bool> func) {
        //right
        for (int i = 0; i < n; i++) {
            if (func(board, n, m, i, 0, 0, 1, k)) {
                return message; 
            } 
        }
        //down
        for (int j = 0; j < m; j++) {
            if (func(board, n, m, 0, j, 1, 0, k)) {
                return message;
            }
        }

        //right down
        for (int i = 0; i < n; i++) {
            if (func(board, n, m, i, 0, 1, 1, k)) {
                return message;
            }
        } 
        for (int j = 0; j < m; j++) {
            if (func(board, n, m, 0, j, 1, 1, k)) {
                return message;
            }
        }

        //left down
        for (int j = 0; j < m; j++) {
            if (func(board, n, m, 0, j, 1, -1, k)) {
                return message;
            }
        }

        for (int i = 0; i < n; i++) {
            if (func(board, n, m, i, m-1, 1, -1, k)) {
                return message;
            }
        } 
        return ""; 
    } 
}
