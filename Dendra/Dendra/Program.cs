using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Dendra
{
    class Program
    {
        static void Main(string[] args)
        {
            DendraInterface A = new DendraInterface();

            FileCrowler B = new FileCrowler(@"C:/");
            
            DendraInterface.Frame_actualizer(A,B);
            DendraInterface.Framing(A);
            //DendraInterface.Cursor(0, A);
            
            //DendraInterface.Framing(A);
            //DendraInterface.Cursor(B.Cur_Subdirectories[0]);
            while(true)
            {
                string input = Console.ReadLine();
                Parser.Command(input);
                DendraInterface.Frame_actualizer(A, B);
                DendraInterface.Framing(A);
            }

            
        }

        ////        //static string[] Method1(string[] input)
        ////        //{
        ////        //    string[] output = new string[input.Length]; 

        ////        //    for (var i=0;i<input.Length;i++)
        ////        //    {

        ////        //        output = Directory.GetFileSystemEntries(input[i]);
        ////        //        return output;
        ////        //    }
        ////        //    Method1(output);
        ////        //    return output;
        ////        //}

        ////        //Console.WriteLine("Введите путь каталога");
        ////        //    string input = Console.ReadLine();
        ////        //string[] entries = Directory.GetFileSystemEntries(input);
        ////        //    //File.WriteAllLines("TreeByCycle.txt", entries);

        ////        //    //, "*", SearchOption.AllDirectories
        ////        //    for (int i = 0; i<entries.Length; i++)
        ////        //    {
        ////        //        Console.WriteLine(entries[i]);

    }

}

