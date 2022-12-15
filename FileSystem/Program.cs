using Microsoft.VisualBasic;
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

            TaskSolutionMenu m = new TaskSolutionMenu();
            m.Menu();


        }

    }
}
