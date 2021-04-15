using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dendra
{
    class Parser
    {
        public int command;
        public string str;
        public Parser(string input)
        {
            this.command = Command(input);
            if (this.command != -1)
            {
                str = Split_cmd(input);
            }
            else str = input;
        }
        public string Split_cmd (string input)
        {
            char[] sep = { ' ' };
            string path = input.Split(sep, 2)[1];
            return path;
        }
        public static int Command (string input)
        {
            if (input[0] == 'o' && input[1] == ' ') return 0;  //Open
            if (input[0] == 'c' && input[1] == ' ') return 1;  //Copy
            if (input[0] == 'm' && input[1] == ' ') return 2;  //Move
            if (input[0] == 'd' && input[1] == ' ') return 3;  //Delete
            if (input[0] == 'r' && input[1] == ' ') return 4;  //Rename
            if (input[0] == 'i' && input[1] == ' ') return 5;  //Info
            if (input[0] == 'n' && input[1] == ' ') return 6;  //New folder
            else return -1;
        }
        public static string [] Split_all_spaces(string input)
        {
            string [] substr = input.Split(' ');
            return substr;
            
        }
    }
}
