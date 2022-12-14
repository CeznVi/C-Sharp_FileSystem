using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.OutputEncoding = Encoding.Unicode;

            //TaskSolutionMenu m = new TaskSolutionMenu();
            //m.Menu();

            ////
            Console.Clear();
            //int[] arr = new int[100000];

            //int[] arr = new int[10];
            //arr.GenerateArray(-99999, 99999);
            //arr.SaveArrayInTxt("../../../../InputFile", "/task5.txt");

            int[] positiveIntArr = null;
            positiveIntArr = positiveIntArr.ReadFileInt("../../../../InputFile/task5.txt");
            positiveIntArr.PrintArray();






            //Console.WriteLine("\nПрості числа");
            //int[] simplyInt = arr.SimplyNum();
            //simplyInt.PrintArray();
            //simplyInt.SaveArrayInTxt("../../../../ResultTask1", "/SimplyInt.txt");

            //Console.WriteLine("\nЧисла Фібоначі");
            //int[] fibInt = arr.FibonacciInt();
            //fibInt.PrintArray();
            //fibInt.SaveArrayInTxt("../../../../ResultTask1", "/FibInt.txt");

            //DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            //string path = d.Parent.ToString();
            //path = path.Remove(path.Length - 10) + @"\ResultTask1";

            //Console.WriteLine("Файли з результатами збережено у теці ResultTask1 яка знаходиться:");
            //Console.WriteLine(path);
            Console.ReadKey();


        }

    }
}
