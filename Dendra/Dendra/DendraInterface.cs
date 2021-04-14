using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Dendra
{
    class DendraInterface
    {
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_SIZE = 0xF000;
        private const int SC_MINIMIZE = 0xF020;

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private void Console_Menu_Redactor()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
            }
        }
//////////////////////////////////////////////////////////////////

        private char [,] frame { get; }

        private string[] Directory_list { get; set; }

        private int main_field_str_num = 25;

        //Задание параметров консоли
        private int win_width = 120;
        private int win_height = 35;

        private int main_field_X;
        private int main_field_Y;
        private int main_field_height;
        private int main_field_width;

        private int info_field_X;
        private int info_field_Y;
        private int info_field_height;
        private int info_field_width;

        private int command_field_X;
        private int command_field_Y;
        private int command_field_height;
        private int command_field_width;

        private int path_field_X;
        private int path_field_Y;
        private int path_field_height;
        private int path_field_width;

        public DendraInterface ()
        {
            Console_Menu_Redactor();
            Windowing();
            frame = new char[win_width, win_height - 1];

            path_field_X = 1;
            path_field_Y = 1;
            path_field_height = 1;
            path_field_width = 88;

            main_field_X = 3;
            main_field_Y = 1;
            main_field_height = win_height - 4 - path_field_height;
            main_field_width = path_field_width;

            info_field_X = path_field_width + 1;
            info_field_Y = 1;
            info_field_height = frame.GetLength(1) * 2 / 3 - 1;
            info_field_width = frame.GetLength(0) - main_field_width - 3;

            command_field_X = info_field_height + 1;
            command_field_Y = main_field_width + 2;
            command_field_height = frame.GetLength(1) - info_field_height - 4;
            command_field_width = info_field_width;

            frame = Frame_Ctreator(frame);
        }
     
        private char[,] Frame_Ctreator(char [,] frame )
        {
            
            //Заполнение пробелами массива 
            for (var j = 0; j < frame.GetLength(1); j++)
            {
                for (var i = 0; i < frame.GetLength(0); i++)
                {
                    frame[i, j] = ' ';
                }
            }

            //Рисуем рамки
            //Внешняя верхняя граница
            for (var i = 0; i < frame.GetLength(0); i++)
            {
                frame[i, 0] = '\u2550';
            }
            //Внешняя левая граница
            for (var i = 0; i < frame.GetLength(1); i++)
            {
                frame[0, i] = '\u2551';
            }
            //Внешняя правая граница
            for (var i = 0; i < frame.GetLength(1); i++)
            {
                frame[frame.GetLength(0) - 1, i] = '\u2551';
            }
            //Внешняя нижняя граница
            for (var i = 0; i < frame.GetLength(0); i++)
            {
                frame[i, frame.GetLength(1) - 1] = '\u2550';
            }
            //Внешняя рамка, углы
            frame[0, 0] = '\u2554';
            frame[frame.GetLength(0) - 1, 0] = '\u2557';
            frame[0, frame.GetLength(1) - 1] = '\u255A';
            frame[frame.GetLength(0) - 1, frame.GetLength(1) - 1] = '\u255D';

            //ИНФО-блок
            //Внутренняя правая граница block2
            int info_frame_X = win_width- info_field_width;
            for (var i = 0; i < frame.GetLength(1); i++)
            {
                frame[info_frame_X, i] = '\u2551';
            }
            frame[info_frame_X, 0] = '\u2566';
            frame[info_frame_X, frame.GetLength(1) - 1] = '\u2569';

            //Внутренняя горизонтальная граница block3
            int info_frame_Y = info_field_height;
            for (var i = info_frame_X + 1; i < frame.GetLength(0) - 1; i++)
            {
                frame[i, info_frame_Y-1] = '\u2550';
            }
            frame[info_frame_X, info_frame_Y - 1] = '\u2560';
            frame[frame.GetLength(0) - 1, info_frame_Y - 1] = '\u2563';

            //Внутренняя верхняя горизонтальная граница
            for (var i = 1; i< info_frame_X ;i++)
            {
                frame[i,2] = '\u2500';
            }

            return frame;
        }

        public static void Framing (DendraInterface A)
        {
            //Рисовка массива построчно
            for (var j = 0; j < A.frame.GetLength(1); j++)
            {
                for (var i = 0; i < A.frame.GetLength(0); i++)
                {
                    Console.Write(A.frame[i, j]);
                }
            }
        }

        public static char[,] Frame_actualizer (DendraInterface A, FileCrowler B)
        {
            //Текущая директория в блоке Path
            Filling_Path(A, B);
            
            A.Directory_list = Concatinator(B.Cur_Subdirectories, B.Cur_Files);

            //Список подкаталогов отображается блоке Main_field
            Filling_Main(A);
            return A.frame;
        }

        //Заполнение блока Path в массиве frame
        private static void Filling_Path(DendraInterface A, FileCrowler B)
        {
            char[] output = B.path.ToCharArray();
            
            for (var i = 0; i<Math.Min((A.path_field_width), output.Length); i++)
            {
                A.frame[A.path_field_Y + i, A.path_field_X] = output[i];
            }
        }
        //Заполнение блока main в массиве frame
        private static void Filling_Main (DendraInterface A)
        {
            //Список подкаталогов отображается первым в блоке Main_field
            for (var j = 0; j < Math.Min(A.Directory_list.Length, A.main_field_str_num); j++)
            {
                char[] output = A.Directory_list[j].ToCharArray();

                for (var i = 0; i < Math.Min((A.main_field_width), output.Length); i++)
                {
                    A.frame[A.main_field_Y + i, A.main_field_X + j] = output[i];
                }
            }
        }

        public static void Cursor(int str_number, DendraInterface A)
        {
            Console.SetCursorPosition(A.main_field_Y, A.main_field_X);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            for (var i = A.main_field_Y; i<A.main_field_width; ++i)
            {
                Console.Write ("\r{0}", A.frame[str_number, i]); 
                
            }
        }

        //Соединяет последовательно два массива
        private static string[] Concatinator(string[] A, string[] B)
        {
            string[] abomination = new string[A.Length + B.Length];

            for (var i = 0; i < A.Length; i++)
            {
                abomination[i] = A[i];
            }
            for (var i = 0; i < B.Length; i++)
            {
                abomination[A.Length + i] = B[i];
            }
            return abomination;
        }

        //Задание размера консоли и фона
        public void Windowing ()
        {
            Console.SetWindowSize(win_width, win_height);
            Console.SetBufferSize(win_width, win_height);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}

