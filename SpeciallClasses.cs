using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace ICSpec
{
    public class ImageStyle//инициализация класса сохранения параметров изображения
    {
        public string Extension { set; get; }
        public int Quality { set; get; }
        public string Directory { set; get; }
    }
    public class ExpCurve
    {
        int StartWL = 0;
        int FinishWL = 0;
        public static void GetNiceCurve(int pRealMin, int pRealMax, int pStWL, int pFinWL, int pStep, List<int> pWls, List<double> pExps)
        {
            int pMinWL = pRealMin;
            int pMaxhWL = pRealMax;
            if (pWls.Count != pExps.Count)
                throw new Exception("Некорректное содержимое файла для перестройки.");
            RestructValues(ref pWls, ref pExps);
            InterpolateValues(pMinWL, pMaxhWL, ref pWls, ref pExps);
            CutValues(pStWL, pFinWL, pStep, ref pWls, ref pExps);

        }
        public static void Get_andWrite_NiceCurveFromDirectory(string path, int pRealMin, int pRealMax, int pStWL, int pFinWL,int pStep, ref List<int> pWls, ref List<double> pExps,
            ref double pGain,ref double pFPS)
        {
            int pMinWL = pRealMin;
            int pMaxhWL = pRealMax;
            GetCurveFromDirectory(path, ref pWls, ref pExps,ref pGain,ref pFPS);
            if (pWls.Count != pExps.Count)
                throw new Exception("Некорректное содержимое файла для перестройки.");
            RestructValues(ref pWls, ref pExps);
            InterpolateValues(pMinWL, pMaxhWL, ref pWls, ref pExps);
            Form1.ShowStringDelegate obj = null;
            WriteCurveToFile(path, pWls, pExps, pGain, pFPS, ref obj,true);
            CutValues(pStWL, pFinWL, pStep, ref pWls, ref pExps);
        }
        public static void GetCurveFromDirectory(string path,ref List<int> pWls,ref List<double> pExps,ref double pGain,ref double pFPS)
        {
            string[] readText = File.ReadAllLines(path);
            int StartPos = 0, EndPos = 0;
            int StartPosFPS = 0, StartPosGain = 0;

            for (int i = 0; i < readText.Count(); i++)
            {
                if (readText[i].IndexOf('.') != -1)
                {
                    readText[i]=readText[i].Replace(".", ",");
                }
                if (readText[i] == "<Data>") StartPos = i + 1;
                else if (readText[i] == "</Data>") EndPos = i;
                else if (readText[i] == "<FPS>") StartPosFPS = i+1;
                else if (readText[i] == "<Gain>") StartPosGain = i+1;
            }
            int num = EndPos - StartPos;
            for (int i= StartPos; i< EndPos; i++)
            {
                pWls.Add(Convert.ToInt32(readText[i].Substring(0, readText[i].IndexOf('\t'))));
                pExps.Add(Convert.ToDouble(readText[i].Substring(readText[i].LastIndexOf('\t') + 1)));
            }
            pGain = Convert.ToDouble(readText[StartPosGain].Replace('.',','));
            pFPS = Convert.ToDouble(readText[StartPosFPS].Replace('.', ','));
        }
        private static void RestructValues(ref List<int> ppWls, ref List<double> ppExps)//сортивка методом вставок
        {
            for (int i = 1; i < ppWls.Count; i++)
            {
                int cur = ppWls[i];
                double cur2 = ppExps[i];
                int j = i;
                while (j > 0 && cur < ppWls[j - 1])
                {
                    ppWls[j] = ppWls[j - 1];
                    ppExps[j] = ppExps[j - 1];
                    j--;
                }
                ppWls[j] = cur;
                ppExps[j] = cur2;
            }
        }
        private static void InterpolateValues(int ppMinWL, int ppMaxWL, ref List<int> ppWls, ref List<double> ppExps)
        {
            int ValuesEdded = 0;
            bool StartWL_exists = false;
            bool FinishWL_exists = false;
            if(ppWls[0]!= ppMinWL)
            {
                if((ppWls[0]< ppMinWL)&&(ppWls.IndexOf(ppMinWL) == -1))
                {

                   double expcur= ppExps[1]-( (ppExps[1]- ppExps[0]) / (double)(ppWls[1]- ppWls[0]))*((double)(ppWls[1] - ppMinWL));
                    ppWls[0] = ppMinWL;
                    ppExps[0] = expcur;
                }
                else if (ppWls[0] > ppMinWL)
                {
                    double expcur = ppExps[1] - ((ppExps[1] - ppExps[0]) / (double)(ppWls[1] - ppWls[0])) * ((double)(ppWls[1] - ppMinWL));
                    ppWls.Insert(0,ppMinWL);
                    ppExps.Insert(0,expcur);
                }
            }
            else
            {
                StartWL_exists = true;
            }
            if (ppWls[ppWls.Count-1] != ppMaxWL)
            {
                if (ppWls[ppWls.Count - 1] < ppMaxWL)
                {
                    int a = ppWls.Count - 1;
                    int b = ppWls.Count - 2;
                    double expcur = ppExps[a] - ((ppExps[a] - ppExps[b]) / (double)(ppWls[a] - ppWls[b])) * ((double)(ppWls[a] - ppMaxWL));
                    ppWls.Add(ppMaxWL);
                    ppExps.Add(expcur);
                }
                else if ((ppWls[ppWls.Count - 1] > ppMaxWL)&&((ppWls.IndexOf(ppMaxWL) == -1)))
                {
                    int a = ppWls.Count - 1;
                    int b = ppWls.Count - 2;
                    double expcur = ppExps[a] - ((ppExps[a] - ppExps[b]) / (double)(ppWls[a] - ppWls[b])) * ((double)(ppWls[a] - ppMaxWL));
                    ppWls[a] = ppMaxWL;
                    ppExps[a] = expcur;
                }
            }
            else
            {
                FinishWL_exists = true;
            }
            int[] IndWithWLs = new int[ppWls.Count];
            IndWithWLs[0] = ppWls[0];
            int NextWL = 0;
            IndWithWLs[IndWithWLs.Count() - 1] = ppWls[ppWls.Count - 1];

            for (int i=0;i<ppWls.Count-1;i++)
            {
                NextWL++;
                int NeedToAdd = ppWls[i + 1] - ppWls[i] - 1;
                for(int j = NeedToAdd; j>=1 ;j--)
                {
                    ppWls.Insert(i + 1, ppWls[i] + j);
                    ppExps.Insert(i + 1, ppExps[i + 1 + NeedToAdd - j] + (ppExps[i] - ppExps[i + 1 + NeedToAdd - j]) * ((double)(NeedToAdd+1 - j) / (double)(NeedToAdd + 1)));
                }
                IndWithWLs[NextWL] = i + 1 + NeedToAdd;
                i += NeedToAdd;
            }
        }
        private static void CutValues(int ppStartWL,int ppFinishWL,int ppStep, ref List<int> ppWls,ref List<double> ppExps)
        {
            
            int ValuesAdded = 0;
            List<int> NewWls = new List<int>();
            List<double> NewExps = new List<double>();
            List<int> IndToAdd = new List<int>();
            bool EndWlNeed = (((ppFinishWL - ppStartWL) % ppStep) == 0) ? false : true;
            for (int i=0;i< ppWls.Count;i++)
            {
                if((ppWls[i] == ppStartWL+ ppStep*ValuesAdded)||(ppWls[i] == ppFinishWL))
                {
                    IndToAdd.Add(i);
                    ValuesAdded++;
                    if (ppWls[i] == ppFinishWL) break;
                }
            }
            for(int i = 0;i< IndToAdd.Count; i++)
            {
                NewWls.Add(ppWls[IndToAdd[i]]);
                NewExps.Add(Form1.PerfectRounding(ppExps[IndToAdd[i]],5));
            }
            ppWls = NewWls;
            ppExps = NewExps;
        }

        public static void CreateCurve(ref System.ComponentModel.BackgroundWorker pBackWorker, ref System.ComponentModel.DoWorkEventArgs pE,
            ref TIS.Imaging.ICImagingControl IC, ref TIS.Imaging.VCDHelpers.VCDSimpleProperty VSExp, ref TIS.Imaging.VCDAbsoluteValueProperty pAbsVal,
            int pWlRealMin, int pWlRealMax, int pStWL, int pFinWL, int pStep, int pCurGain, double pFPS,
            Form1.ShowStringDelegate pMesShowDel,bool pwasAutomation)
        {
            try
            {
                if (pBackWorker.CancellationPending) { pE.Cancel = true; return; }
                int minSecondsToWait = 1;
                double FPSminSecondsToWait = 10.0 / pFPS;
                double SecondsToWait = (minSecondsToWait < FPSminSecondsToWait) ? FPSminSecondsToWait : minSecondsToWait;
                
                List<int> Wls = new List<int>();
                List<double> Exps = new List<double>();
               // bool EndWlNeed = (((pFinWL - pStWL) % pStep) == 0) ? false : true;
                int TotalWls = (pFinWL - pStWL) / pStep;
                for (int i = 0; i < TotalWls; i++)
                {
                    Wls.Add(pStWL + i * pStep);
                }
                Wls.Add(pFinWL);
                if (pBackWorker.CancellationPending) { pE.Cancel = true; return; }
                string ChangeVCDID = TIS.Imaging.VCDIDs.VCDID_Exposure;
                if (!VSExp.AutoAvailable(ChangeVCDID))
                     {
                         throw new Exception("Автоподстройка невозможна из-за отсутствия функции автоподстройки на данной камере"); 
                     }
                     else
                     {
                         VSExp.Automation[ChangeVCDID] = true;
                     }
                if (pBackWorker.CancellationPending) { pE.Cancel = true; return; }
                AOF.AOM_SetWL(Wls[0]);
                System.Threading.Thread.Sleep(1000);
                System.Diagnostics.Stopwatch stw = new System.Diagnostics.Stopwatch();
                double CurrentExp = pAbsVal.Value;
                for (int i = 0; i < Wls.Count(); i++)
                {
                    if (pBackWorker.CancellationPending) { pE.Cancel = true; return; }
                    string message = "Начальная экспозиция для длины волны " + Wls[i].ToString() + ": " + CurrentExp.ToString();
                    pMesShowDel.Invoke(message);                
                    //LB.BeginInvoke(pMesShowDel, new object[] { message });
                    AOF.AOM_SetWL(Wls[i]);
                    stw.Restart();
                    //  System.Threading.Thread.Sleep()
                    bool TimeNotElapsed = true;
                    while (TimeNotElapsed)
                    {
                        if (pBackWorker.CancellationPending) { pE.Cancel = true; return; }
                        if (pAbsVal.Value != CurrentExp)
                        {
                            CurrentExp = pAbsVal.Value;
                            stw.Restart();
                        }
                        else if (stw.Elapsed.TotalSeconds > SecondsToWait)
                        {
                            TimeNotElapsed = false;
                            Exps.Add(Form1.PerfectRounding(CurrentExp,7));
                            pBackWorker.ReportProgress(Wls[i]);
                            string message2 = "Подобрана экспозиция для длины волны " + Wls[i].ToString() + ": " + Exps[i].ToString();
                            pMesShowDel.Invoke(message2);
                           // LB.BeginInvoke(pMesShowDel, new object[] { message2 });
                        }
                    }
                }
                string filename = IC.DeviceCurrent.Name.ToString()+"_"+Form1.GetFullDateString() + ".expcurv";
                string message3 = "Подбор экспозиций завершен! Запись в файл "+ filename;
                pMesShowDel.Invoke(message3);
                if (pBackWorker.CancellationPending) { pE.Cancel = true; return; }
                //  LB.BeginInvoke(pMesShowDel, new object[] { message3 });
                WriteCurveToFile(filename,Wls,Exps,pCurGain,pFPS,ref pMesShowDel,false);

            }
            catch(Exception exc)
            {
                string ChangeVCDID = TIS.Imaging.VCDIDs.VCDID_Exposure;
                if (pwasAutomation) VSExp.Automation[ChangeVCDID] = pwasAutomation;
                throw exc;
            }
        }
        public static void WriteCurveToFile(string filename, List<int> pWls,List<double> pExps,double ppGain,double ppFPS,ref Form1.ShowStringDelegate ppMesShowDel,bool NeedEnotherExt)
        {
            try
            {
                if (NeedEnotherExt) filename = filename.Insert(filename.LastIndexOf('.') + 1, "f");
                List<string> ListToWrite = new List<string>();
                ListToWrite.Add("<Gain>");
                string sGain = (ppGain == -1) ? "user defined" : ppGain.ToString().Replace(',', '.');
                ListToWrite.Add(sGain);
                ListToWrite.Add("</Gain>");
                ListToWrite.Add("<FPS>");
                string sFPS = (ppFPS == -1) ? "user defined" : ppFPS.ToString().Replace(',', '.');
                ListToWrite.Add(sFPS);
                ListToWrite.Add("</FPS>");
                ListToWrite.Add("<Data>");
                for (int i = 0; i < pWls.Count(); i++)
                {
                    ListToWrite.Add(pWls[i].ToString() + "\t" +pExps[i].ToString().Replace(',','.'));
                    string message3 = "Длина волны " + pWls[i].ToString() + " со значением экспозиции " + pExps[i].ToString().Replace(',', '.') + " сохранена";
                    if(ppMesShowDel!=null) ppMesShowDel.Invoke(message3);
                }
                ListToWrite.Add("</Data>");
                File.WriteAllLines(filename, ListToWrite, Encoding.UTF8);
                string message = "Запись в файл " + filename + " завершена успешно!";
                if (ppMesShowDel != null) ppMesShowDel.Invoke(message);
            }
            catch(Exception exc)
            {
                string message = "Запись в файл " + filename + " завершена с ошибкой.";
                if (ppMesShowDel != null) ppMesShowDel.Invoke(message);
                throw exc;
            }
        }
    }
    public static class Files
    {
        public static string OpenDirectory()
        {
            string result = null;
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                result = FBD.SelectedPath;
            }
            if (System.IO.Directory.Exists(result)) return result;
            else return null;
        }
        public static string CreateFilter_ForFileDialog(bool pAllowAllExtensions, params string[] format)
        {
            string result = "";
            for (int i = 0; i < format.Count(); i++)
            {
                if (format[i].IndexOf('.') != -1)
                    format[i] = format[i].Remove(format[i].IndexOf('.'), 1);
                format[i] = String.Format(format[i].ToUpper() + " Files(*.{0}) |*.{0}|", format[i].ToLower());
            }
            for (int i = 0; i < format.Count(); i++)
            {
                result += format[i];
            }
            if (pAllowAllExtensions) result += "All files(*.*) |*.*";
            else { result = result.Substring(0, result.Length - 1); }
            return result;
        }
        public static string OpenSaveDialog(bool AllowAllExtensions, params string[] extensions)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = CreateFilter_ForFileDialog(AllowAllExtensions, extensions);
            SFD.AddExtension = true;
            if (SFD.ShowDialog() == DialogResult.Cancel) return null;
            // получаем выбранный файл
            string filename = SFD.FileName;
            // сохраняем текст в файл
            return filename;
        }
        public static string[] OpenFiles(string Title, bool AllowAllExtensions,bool ismultiselect, params string[] extensions)
        {
            string[] result = null;
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = CreateFilter_ForFileDialog(true, extensions);
            OFD.Title = Title;
            OFD.Multiselect = ismultiselect;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                result = OFD.FileNames;
            }
            return result;
        }
        public static List<string> FindFiles_byExstension(string path, string ext)
        {
            List<string> result = new List<string>();
            if (ext.Substring(0, 1) != ".") return result;

            var allFilenames = Directory.EnumerateFiles(path).Select(p => Path.GetFileName(p));

            // Get all filenames that have a .txt extension, excluding the extension
            var candidates = allFilenames.Where(fn => Path.GetExtension(fn) == ext)
                                         .Select(fn => Path.Combine(path, fn));
            result = new List<string>(candidates);
            return result;
        }

        public static List<string> Read_txt(string path)
        {
            string[] AllLines = File.ReadAllLines(path);
            List<string> result = new List<string>(AllLines);
            return result;
        }
        public static bool Write_txt(string path, List<string> data)
        {
            bool result = false;
            try
            {
                string[] AllLines = new string[data.Count];
                data.CopyTo(AllLines);
                File.WriteAllLines(path, AllLines);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static List<int> List_Sort_viaLastNumber(ref List<string> FullImageWays, string ext)
        {
            List<int> result = new List<int>();

            List<string> data_res = new List<string>(FullImageWays.Select(fn => Path.GetFileNameWithoutExtension(fn)));
            result = new List<int>(data_res.Select(fn => Get_LastNumber_from_name(fn)));

            result.Sort(delegate (int wl1, int wl2) { return wl1.CompareTo(wl2); });
            FullImageWays.Sort(delegate (string wl1, string wl2)
            {
                return (Get_LastNumber_from_name(Path.GetFileNameWithoutExtension(wl1)))
             .CompareTo(Get_LastNumber_from_name(Path.GetFileNameWithoutExtension(wl2)));
            });
            return result;
        }
        public static int Get_LastNumber_from_name(string a)
        {
            int res = -1;
            res = Convert.ToInt32(a.Substring(a.LastIndexOf('_') + 1));
            return res;
        }
        public static void Get_WLData_byKnownCountofNumbers(int countofnumbers, string[] AllStrings,
            out float[] pWls, out float[] pHzs, out float[] pCoefs)
        {

            float CurWl = 0, CurHz = 0, CurCoef = 0;
            List<float> dWls = new List<float>();
            List<float> dHzs = new List<float>();
            List<float> dCoefs = new List<float>();

            float[] Params = new float[countofnumbers];
            for (int i = 0; i < AllStrings.Length; ++i)
            {
                try
                {
                    Get_WLData_fromDevString(AllStrings[i], countofnumbers, Params);
                    dHzs.Add(Params[0]); dWls.Add(Params[1]); dCoefs.Add(Params[2]);
                }
                catch
                {
                    continue;
                }
            }
            dWls.Reverse();
            dHzs.Reverse();
            dCoefs.Reverse();

            pWls = dWls.ToArray();
            pHzs = dHzs.ToArray();
            pCoefs = dCoefs.ToArray();
        }
        public static void Get_WLData_fromDevString(string datastring, int NumberOfParamsInString, float[] pPars)
        {
            int startindex = 0; bool startfound = false;
            int finishindex = 0; bool finishfound = false;
            List<float> datavalues = new List<float>();
            for (int i = 0; i < datastring.Length; i++)
            {
                if ((datastring[i] != ' ') && ((Char.IsDigit(datastring[i])) || (datastring[i] == '.') || (datastring[i] == ',') || (datastring[i] == '-')))
                {
                    if (startfound)
                    {
                        finishindex++;
                    }
                    else
                    {
                        startindex = i;
                        startfound = true;
                    }
                }
                else
                {
                    if (startfound)
                    {
                        finishindex = i;
                        finishfound = true;
                    }
                }
                if (startfound && finishfound)
                {
                    string data = datastring.Substring(startindex, finishindex - startindex);
                    datavalues.Add((float)Convert.ToDouble(data.Replace('.', ',')));
                    startfound = finishfound = false;
                }
            }
            if (startfound && !finishfound)
            {
                string data = datastring.Substring(startindex);
                datavalues.Add((float)Convert.ToDouble(data.Replace('.', ',')));
            }
            for (int i = 0; i < NumberOfParamsInString; i++) { pPars[i] = datavalues[i]; }
        }
    }
}
