using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace FileSystem
{
    //клас методів розширення
    static partial class ExtensionMethod
    {
        //// Метод розширення який генерує масив данних
        public static void GenerateArray(this int[] data, int min, int max)
        {
            Random rnd = new();

            rnd.Next(min, max);

            for (int i = 0; i < data.Length; i++)
                data[i] = rnd.Next(min, max);
        }

        //// Метод розширення який друкує масив
        public static void PrintArray(this int[] arr)
        {

            string separator = new('-', 75);
            //Console.WriteLine(separator);
            //Console.WriteLine("Масив чисел:".PadCenter(75));
            Console.WriteLine(separator);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 20 == 0 && i != 0) Console.WriteLine($"\n{separator}");
                
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine($"\n{separator}");
        }
        
        //// Метод розширення який повертає прості числа з масиву
        public static int[] SimplyNum(this int[] arr)
        {
            List<int> values = new();

            foreach (int item in arr)
            {
                if (item > 1)
                {
                    int count = 0;
                    for (int i = 1; i <= item; i++)
                        if (item % i == 0) 
                            count++;

                        if (count == 2) 
                            values.Add(item);
                    
                }
            }
            values.Sort();  
            return values.ToArray();
        }

        //// Метод розширення який повертає числа Фібоначі з масиву
        public static int[] FibonacciInt(this int[] arr)
        {
            List<int> values = new();

            //генерируем масив Фібаначі
            int[] array = new int[30];
            for (int i = 0; i < 20; ++i)
                array[i] = i < 2 ? 1 : array[i - 2] + array[i - 1];

            //порівнюємо наш масив із масивом Фібаначі
            for (int i = 0; i < arr.Length; i++)
                if (array.Contains(arr[i]))
                    if (!values.Contains(arr[i]))
                        values.Add(arr[i]);

            if (values.Count > 0)
            {
                values.Sort();
                return values.ToArray();
            }
            else
            {
                Console.WriteLine("В масиву чисел Фібоначі не знайдено");
                return values.ToArray();
            }

        }

        //// Метод розширення який зберігає дані у тхт файл
        public static void SaveArrayInTxt(this int[] arr, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream fs = new FileStream(path + fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    foreach (int i in arr)
                        sw.Write($"{i} ");
                }
            }
        }

        //// Метод який зчитує вміст файла у стрінг
        public static string ReadFileTxt(this string str, string path)
        {

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    str = sr.ReadToEnd();
                }
            }
            return str;
        }

        //// Метод розширення який зберігає дані у тхт файл
        public static void SaveStringInTxt(this string str, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream fs = new FileStream(path + fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                        sw.Write(str);
                }
            }
        }

        //// Метод розширення який замінює шукає та замінює слова у стрінгу
        public static string ReplaceWord(this string str, string word, string replaceW) 
        {
            string returnText = "";
            char[] separators1 = new char[] { ' ', '.', ',', ':', ';' };
            char[] separators = new char[] { ' ' };
            int countStopWords = 0;

            //ділимо наше речення на суб речення по ознаку " " на кінці речення
            string[] textm = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < textm.Length; i++)
            {
                if (textm[i].Trim(separators1).ToLower() == word)
                {
                    textm[i] = replaceW;
                    countStopWords++;
                }
            }

            for (int i = 0; i < textm.Length; i++)
                returnText += textm[i] + " ";
                        
            string separatorP = new(separators1[3], 75);

            Console.WriteLine($"\n{separatorP}");
            Console.WriteLine($"Cтатистика: |{countStopWords}| замiни слова {word} на {replaceW}");
            Console.WriteLine($"{separatorP}\n");

            return returnText;
        }

        //// Метод розширення який замінює шукає слова та замінює слова у стрінгу
        public static string ReplaceWords(this string str, string word, string replaceW = "*")
        {
            string returnText = "";
            char[] separators = new char[] { ' ', '\n' };
            char[] separators1 = new char[] { ' ', '.', ',', ':', ';'};
            int countStopWords = 0;

            //ділимо наше речення на суб речення по ознаку " " на кінці речення
            string[] textm = str.Split(separators, StringSplitOptions.TrimEntries);
            string[] textm2 = word.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < textm.Length; i++)
            {
                for(int j = 0; j < textm2.Length; j++)
                {
                    if((textm[i].Trim(separators1)).ToLower() == textm2[j])
                    {
                        textm[i] = replaceW.Xn(textm2[j].Length);
                        countStopWords++;
                    }
                }
            }

            for (int i = 0; i < textm.Length; i++)
            {
                returnText += textm[i] + " ";
            }

            string separatorP = new(separators1[3], 75);

            Console.WriteLine($"\n{separatorP}");
            Console.WriteLine($"Кількість замiн слів |{countStopWords}|  {replaceW} -> {word}");
            Console.WriteLine($"{separatorP}\n");

            return returnText;
        }

        //// Метод розширення розвороту тексту
        public static string ReverseText(this string str)
        {
            List<char> textm = new();

            foreach (char s in str)
            {
                textm.Add(s);
            }

            textm.Reverse();

            string temp = "";

            foreach(char s in textm) 
            { 
                temp+= s;
            }

            return temp;
        }

        //// Метод розширення читання чисел із файлу
        public static int[] ReadFileInt(this int[] arr, string path)
        {
            string str = "";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    str = sr.ReadToEnd();
                }
            }

            char[] separators = new char[] { ' ', '\n' };
            string[] textToInt = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);



            int[] ifg = new int [9];
            ifg.GenerateArray(0, 2);

            return ifg;
        }
    }
}
