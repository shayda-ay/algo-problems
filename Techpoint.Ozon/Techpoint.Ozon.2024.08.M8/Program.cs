using System;
using System.IO;

/*Галерея искусств*/
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput()); 
        using var output = new StreamWriter(Console.OpenStandardOutput());
        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
            int n = int.Parse(input.ReadLine()); //количество коробок
            int[][] boxs = new int[n][];
            int n1 = 0;
            while (n1 < n) {
                var line = input.ReadLine().Split(' ');
                int width = int.Parse(line[0]); //ширина коробки 
                int length = int.Parse(line[1]); //длина коробки  
                //все коробки запишем так, чтобы ширина была всегда меньше, чем длина
                if (width > length) {
                    Swap(ref width, ref length);
                }
                boxs[n1] = new int[] { width, length };
                n1++;
            }

            int m = int.Parse(input.ReadLine()); //количество картин
            int[][] pics = new int[m][];
            int m1 = 0;
            while (m1 < m) {
                var line = input.ReadLine().Split(' ');
                int width = int.Parse(line[0]); //ширина картины
                int length = int.Parse(line[1]); //длина картины
                //все картины запишем так, чтобы ширина была всегда меньше, чем длина
                if (width > length) {
                    Swap(ref width, ref length);
                }
                pics[m1] = new int[] { width, length };
                m1++;
            }
            //отсортируем коробки и картины по убыванию ширины и длины, то есть по первому числу.
            Sort(boxs, 0); 
            Sort(pics, 0); 

            int ptrboxes = 0, //указатель массива коробок
                ptrimages = 0, //указатель массива картин
                width_taken = -1,  //максимальная ширина из уже взятых коробок
                width_all = -1,  // максимальная ширина из рассмотренных коробок
                count = 0; //необходимое количество коробок


            while (ptrimages < m && ptrboxes < n) {
                //Картина по длине вмещается в коробку
                if (pics[ptrimages][0] <= boxs[ptrboxes][0]) {
                    width_all = Math.Max(width_all, boxs[ptrboxes][1]); //обновим максимальную ширину рассмотреных коробок
                    ptrboxes++; //сдвинем указатель массива коробок
                } else { //Картина по длине не вмещается в коробку 
                    if (width_all < pics[ptrimages][1]) {  // Крайний случай картина не поместилась
                        count = -1;
                        break;
                    } 
                    if (width_taken < pics[ptrimages][1] && width_all >= pics[ptrimages][1]) { //Берем новую коробку
                        width_taken = width_all;
                        count++;
                    }
                    ptrimages++;
                }
            }
            if (ptrimages < m && width_taken < pics[ptrimages][1] && width_all >= pics[ptrimages][1]) { //Берем новую коробку
                count++;
            }
            if (count == 0) {
                count = -1;
            }
            output.WriteLine(count);
            t--;
        }
    }
    static void Swap<T>(ref T lhs, ref T rhs) {
        T temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }
    private static void Sort<T>(T[][] data, int col) {
        Comparer<T> comparer = Comparer<T>.Default;
        Array.Sort<T[]>(data, (x, y) => comparer.Compare(y[col], x[col]));
    }
}
