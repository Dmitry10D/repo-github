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
            
            Frame_actualizer(A,B);
            DendraInterface.Framing(A);
            
            while(true)
            {
                string input = Console.ReadLine();
                Console.Clear();
                Parser P = new Parser(input);
                FileCrowler C = new FileCrowler(P.str);
                Controller(P);
            }    
        }

        public static void Controller (Parser P)
        {
            if (P.command == -1)
            {
                try 
                {
                    DendraInterface A = new DendraInterface();
                    FileCrowler B = new FileCrowler(P.str);
                    Frame_actualizer(A, B);
                    DendraInterface.Framing(A);
                }
                catch
                {
                    Console.WriteLine("Directory or file does not exist");
                }
            }
            else
            {
                
                   FileCrowler.Command (P.command, P.str);
                
                
            }
        }

        public static char[,] Frame_actualizer(DendraInterface A, FileCrowler B)
        {
            //Текущая директория в блоке Path
            DendraInterface.Filling_Path(A, B.path);

            A.Directory_list = DendraInterface.Concatinator(B.Cur_Subdirectories, B.Cur_Files);

            //Список подкаталогов отображается блоке Main_field
            DendraInterface.Filling_Main(A);
            return A.frame;
        }
    }
}

