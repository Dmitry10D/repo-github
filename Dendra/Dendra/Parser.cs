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
            if (input[0] == 'o' && input[1] == ' ') return 0;  //Open
            if (input[0] == 'c' && input[1] == ' ') return 1;  //Copy
            if (input[0] == 'p' && input[1] == ' ') return 2;  //Past
            if (input[0] == 'm' && input[1] == ' ') return 3;  //Move
            if (input[0] == 'd' && input[1] == ' ') return 4;  //Delete
            if (input[0] == 'r' && input[1] == ' ') return 5;  //Rename
            if (input[0] == 'i' && input[1] == ' ') return 6;  //Info
            if (input[0] == 'n' && input[1] == ' ') return 7;  //New folder
            else return -1;
        }
    }
}
