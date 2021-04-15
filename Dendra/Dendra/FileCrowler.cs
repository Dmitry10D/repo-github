using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dendra
{
    class FileCrowler
    {
        public enum Commands { Open, Copy, Move, Delete, Rename, Info, New_Folder };
        public string path { get; set; }

        public string [] Cur_Subdirectories { get; }

        public string[] Cur_Files { get; }

        public FileCrowler (string path)
        {
            if (File.Exists(path))
            {
                    FileInfo fi = new FileInfo(path);
                    this.path = fi.DirectoryName;
                    fi.Open(FileMode.Open, FileAccess.ReadWrite);
            }
            if (Directory.Exists(path))
            {
                this.path = path;
            }
            else
            {
                this.path = @"C:/";
                Console.WriteLine("Directory or file does not exist");
            }
            
            Cur_Subdirectories = Directory.GetDirectories(this.path);
            Cur_Files = Directory.GetFiles(this.path);
            
        }

        public static void Command (int com_id, string path)
        {
            
            switch (com_id)
            {
                case 1:
                    Copy(path);
                    break;
                case 2:
                    
                    break;
            }
        }

        private static void Copy (string input)
        {
            string[] substr = Parser.Split_all_spaces(input);
            string source_path = substr [0];
            string dest_path = substr [1];

            File.Copy(source_path, dest_path);
        }
       

    }
}
