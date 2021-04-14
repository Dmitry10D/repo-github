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
        enum Commands { Open, Copy, Past, Move, Delete, Rename, Info, New_Folder };
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
                Console.WriteLine("Directory or file does not exist");
            }
            
            Cur_Subdirectories = Directory.GetDirectories(this.path);
            Cur_Files = Directory.GetFiles(this.path);
            
        }

       

    }
}
