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
        public string path { get; set; }

        public string [] Cur_Subdirectories { get; }

        public string[] Cur_Files { get; }

        public FileCrowler (string path)
        {
            this.path = path;
            Cur_Subdirectories = Directory.GetDirectories(path);
            Cur_Files = Directory.GetFiles(path);
        }


       

    }
}
