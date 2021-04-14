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
            
            while(true)
            {
                string input = Console.ReadLine();
                if (Parser.Command(input) != -1)
                {

                }
                DendraInterface.Frame_actualizer(A, B);
                DendraInterface.Framing(A);
            }    
        }
    }
}

