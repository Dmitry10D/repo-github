using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
                
                Process.Start(path);
            }
            if (Directory.Exists(path))
            {
                this.path = Path.GetFullPath(path);
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
                    Move(path);
                    break;
                case 3:
                    Delete(path);
                    break;
                case 4:
                    Rename(path);
                    break;
                case 5:
                    Info(path);
                    break;
                case 6:
                    Directory.CreateDirectory(path);
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
       
        private static void Move (string input)
        {
            string[] substr = Parser.Split_all_spaces(input);
            string source_path = substr[0];
            string dest_path = substr[1];

            File.Move(source_path, dest_path);
        }

        private static void Delete (string input)
        {
            File.Delete(input);
        }

        private static void Rename (string input)
        {
            string[] substr = Parser.Split_all_spaces(input);
            string file_name = substr[0];
            string new_file_name = substr[1];

            File.Copy(file_name, new_file_name);
            File.Delete(file_name);
        }

        private static void Info (string input)
        {
            
            
        }
        private static float CalculateFolderSize(string path)
        {
            float folderSize = 0.0f;
            try
            {
                //Checks if the path is valid or not
                if (!Directory.Exists(path))
                    return folderSize;
                else
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(path))
                        {
                            if (File.Exists(file))
                            {
                                FileInfo fi = new FileInfo(file);
                                folderSize += fi.Length;
                            }
                        }

                        foreach (string dir in Directory.GetDirectories(path))
                            folderSize += CalculateFolderSize(dir);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
            }
            return folderSize;
        }
    }
}
