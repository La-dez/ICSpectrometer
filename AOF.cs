using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//using aom; 

namespace ICSpec
{
    class AOF
    {     
        public const string basepath = "aom.dll";
    /*    public void SetBasePath(string path)
        {
            basepath = path;
        }*/
         //Назначение: функция возвращает число подключенных акустооптических фильтров.
        [DllImport(basepath)]
        public static extern int AOM_GetNumDevices();
        public static int AOM_GetNumDevices(bool IsSimulator)
        {
            if (IsSimulator) return 1;
            else return AOM_GetNumDevices();
        }

           //Назначение: функция производит инициализацию подключенного акустооптического фильтра 
        //(обычное значение devicenum = 0, т.е. первое).
        [DllImport(basepath)]
        public static extern int AOM_Init(int devicenum);
        public static int AOM_Init(int devicenum, bool IsSimulator)
        {
            if (IsSimulator) return 0;
            else return AOM_Init(devicenum);
        }
        //Назначение: функция выполняет деинициализацию акустооптического фильтра.
        [DllImport(basepath)]
        public static extern int AOM_Close();
        public static int AOM_Close(bool IsSimulator)
        {
            if (IsSimulator) return 0;
            else return AOM_Close();
        }

        //Назначение: функция записывает в переменную id значение идентификатор подключенного акустооптического фильтра.
        [DllImport(basepath,CharSet = CharSet.Ansi)]
        public static extern int AOM_GetID([MarshalAs(UnmanagedType.LPStr)] StringBuilder id);
        public static int AOM_GetID(StringBuilder id,bool IsSimulator)
        {
            if (IsSimulator) { id.Append("avmX-XXX"); return 0; }
            else return AOM_GetID(id);
        }
        //Назначение: функция производит загрузку значений максимальной
        //(wlmax) и минимальной длины волны (wlmin) из файла с именем filename с расширением *.dev.
        [DllImport(basepath, 
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int AOM_LoadSettings(string filename, ref float wlmin, ref float wlmax);
     /*   public static int AOM_LoadSettings(string filename, ref float wlmin, ref float wlmax, bool IsSimulator)
        {
            /*if (IsSimulator) return 0;
           // else return AOM_LoadSettings(filename, ref wlmin, ref wlmax);
        }*/

        //Назначение: функция выполняет выгрузку установленных значений из калибровочного файла формата *.dev.
        [DllImport(basepath)]
        public static extern int AOM_UnloadSettings();

        //Назначение: функция производит установку требуемой частоты акустооптического фильтра
        [DllImport(basepath)]
        public static extern int AOM_SetWL(float wl);
        public static int AOM_SetWL(float wl,bool IsSimulator)
        {
            if (IsSimulator) return 0;
            else return AOM_SetWL(wl);
        }

        //Назначение: функция производит включение акустооптического фильтра.
        [DllImport(basepath)]
        public static extern int AOM_PowerOn();
        public static int AOM_PowerOn(bool IsSimulator)
        {
            if (IsSimulator) return 0;
            else return AOM_PowerOn();
        }

        //Назначение: функция производит выключение акустооптического фильтра.
        [DllImport(basepath)]
        public static extern int AOM_PowerOff();

        public static int AOM_PowerOff(bool IsSimulator)
        {
            if (IsSimulator) return 0;
            else return AOM_PowerOff();
        }
        public static string AOM_IntErr(int i)
        {
            string answer = null;
            switch (i)
            {
                case 0:
                    answer = "AOM_OK";
                    break;
                case 1:
                    answer = "AOM_ALREADY_INITIALIZED";
                    break;
                case 2:
                    answer = "AOM_ALREADY_LOADED";
                    break;
                case 3:
                    answer = "AOM_NOT_INITIALIZED";
                    break;
                case 4:
                    answer = "AOM_DEVICE_NOTFOUND";
                    break;
                case 5:
                    answer = "AOM_BAD_RESPONSE";
                    break;
                case 6:
                    answer = "AOM_NULL_POINTER";
                    break;
                case 7:
                    answer = "AOM_FILE_NOTFOUND";
                    break;
                case 8:
                    answer = "AOM_FILE_READ_ERROR";
                    break;
                case 9:
                    answer = "AOM_WINUSB_INIT_FAIL";
                    break;
                case 10:
                    answer = "AOM_NOT_LOADED";
                    break;
                case 11:
                    answer = "AOM_RANGE_ERROR";
                    break;
            }

            return answer;
        }

    }
}
