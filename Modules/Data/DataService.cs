using System;
using System.IO;

namespace Mighty
{
    public static class DataService
    {
        #region Events
        #endregion

        #region Voids

                /*public void SaveData() --Go On in Next Update
        {

        }*/

        /// <summary>
        /// Get Mighty temp path.
        /// </summary>
        /// <returns>Path.GetTempPath() + @"\Mighty\"</returns>
        public static string GetTempPath()
        {
            try
            {
                return Path.GetTempPath() + @"\Mighty\";
            }
            catch (Exception e)
            {
                Log.PrintError(e, $"Falha ao obter GetTempPath, returning Null");
                return null;
            }
        }
        /// <summary>
        /// Get temp path of computer.
        /// </summary>
        /// <returns>Path.GetTempPath()"</returns>
        public static string GetTrueTempPath()
        {
            try
            {
                return Path.GetTempPath();
            }
            catch (Exception e)
            {
                Log.PrintError(e, $"Falha ao obter GetTrueTempPath, returning Null");
                return null;
            }
        }
        /// <summary>
        /// return .exe folder.
        /// </summary>
        /// <returns>System.Reflection.Assembly.GetExecutingAssembly().CodeBase</returns>
        public static string GetApplicationPath()
        {
            try
            {
                return Environment.CurrentDirectory;
            }
            catch(Exception e)
            {
                Log.PrintError(e, $"Falha ao obter ApplicationPath, retornando null");
                return null;
            }
        }
        /// <summary>
        /// Makes directory.
        /// </summary>
        /// <param name="directory"></param>
        public static void MakeDirectory(string directory)
        {
            try
            {
                //Log.Print($"$Yellow$Creating Directory...");
                Directory.CreateDirectory(directory);
                //Log.Print($"$Green$Diretorio criado: {directory}");
            }
            catch(Exception e)
            {
                Log.PrintError(e, $"Falha ao criar o diretorio: '{directory}' ");
            }
        }

        /// <summary>
        /// Make a TXT File.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        /// <param name="content"></param>
        public static void MakeTxtFile(string directory, string filename, string content="")
        {
            try
            {
                if (!VerifyDirectory(directory))
                    MakeDirectory(directory);

                //Log.Print($"$Yellow$Making TXT File: '{filename}', on '{directory}', and content");
                File.WriteAllText(directory + @"\" + filename + ".txt", content);
                //Log.Print("$Green$Arquivo TXT criado.");
            }
            catch(Exception e)
            {
                Log.PrintError(e, $"Falha ao criar o arquivo TXT em: '{directory}', File Name: '{filename}', Content: '{content}' ");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Make a file in directory
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        public static void MakeFile(string directory, string filename)
        {
            if (!VerifyDirectory(directory))
                MakeDirectory(directory);

            try 
            {
                //Log.Print($"$Yellow$Making File: '{filename}', on '{directory}'");
                File.WriteAllText(directory + @"\" + filename, "");
                //Log.Print("$Green$Arquivo Criado.");
            }
            catch (Exception e)
            {
                Log.PrintError(e, $"Falha ao criar o arquivo em: '{directory}', File Name: '{filename}' ");
            }
        }

        /// <summary>
        /// Make a file in directory with extension. 'OBS: extension without point.'
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        /// <param name="extension"></param>
        public static void MakeFile(string directory, string filename, string extension)
        {
            if (!VerifyDirectory(directory))
                MakeDirectory(directory);

            try
            {
                //Log.Print($"$Yellow$Making File: '{filename}', on '{directory}', with extension '{extension}'");
                if(extension.Contains("."))
                    File.WriteAllText(directory + @"\" + filename + extension, "");
                else
                    File.WriteAllText(directory + @"\" + filename + "." + extension, "");
                //Log.Print("$Green$Arquivo criado.");
            }
            catch (Exception e)
            {
                Log.PrintError(e, $"Falha em fazer o arquivo no diretorio: '{directory}', File Name: '{filename + extension}' ");
            }
        }

        /// <summary>
        /// Make a file in directory with extension and content
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        /// <param name="extension"></param>
        /// <param name="content"></param>
        public static void MakeFile(string directory, string filename, string extension, string content)
        {
            if(!VerifyDirectory(directory))
                MakeDirectory(directory);

            try
            {

                //Log.Print($"$Yellow$Making File: '{filename}', on '{directory}', with extension '{extension}', and content: '{content}'");
                if(extension.Contains("."))
                File.WriteAllText(directory + @"\" + filename + extension, content);
                else
                File.WriteAllText(directory + @"\" + filename + "." + extension, content);
                //Log.Print("$Green$Arquivo criado com sucesso.");
            }
            catch (Exception e)
            {
                Log.PrintError(e, $"Falha ao criar arquivo em: '{directory}', File Name: '{filename + extension}', Content: {content} ");
            }
        }
        /// <summary>
        /// Retorna a data atual como um DateTime.
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime GetActualTime()
        {
            return DateTime.Now;
        }
        /// <summary>
        /// Retorna a data atual em forma de string.
        /// </summary>
        /// <returns>String formatada com as datas</returns>
        public static string GetActualTimeString(string format = "dd/MM/yyyy - HH:mm")
        {
            DateTime actualTime = GetActualTime();
            string day = actualTime.Day.ToString("00");        // Formata o dia com dois dígitos
            string month = actualTime.Month.ToString("00");    // Formata o mês com dois dígitos
            string year = actualTime.Year.ToString("0000");     // Formata o ano com quatro dígitos
            string hour = actualTime.Hour.ToString("00");       // Formata a hora com dois dígitos
            string minute = actualTime.Minute.ToString("00");   // Formata o minuto com dois dígitos
            string seconds = actualTime.Second.ToString("00");
            string milis = actualTime.Millisecond.ToString();
            
            return format.Replace("dd", day).Replace("MM", month).Replace("yyyy", year).Replace("HH", hour).Replace("mm", minute).Replace("SS", seconds).Replace("ML", milis);
        }

        public static bool VerifyDirectory(string path)
        {
            return Directory.Exists(path);
        }



        #endregion
        

    }
}
