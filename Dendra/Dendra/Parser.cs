using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dendra
{
    class Parser
    {
        public void Parsing (string input)
        {
            string[] sub_str = input.Split(' ');
        }


        public static int Command (string input)
        {
            if (input[0] == 'o') return 0; //Open
            if (input[0] == 'c') return 1;  //Copy
            if (input[0] == 'p') return 2;  //Past
            if (input[0] == 'm') return 3;  //Move
            if (input[0] == 'd') return 4;  //Delete
            if (input[0] == 'r') return 5;  //Rename
            if (input[0] == 'i') return 6;  //Info
            if (input[0] == 'n') return 7;  //New folder
            else return -1;
        }
    }
}
