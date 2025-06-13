using System;
using System.Diagnostics;

namespace Mighty
{
    public enum LogType
    {
        Debug,
        Warning,
        Error,
        Info
    }
    public static class Log
    {
        //TODO: Implementar os Log Types.
        public static List<LogType> AllowedLogTypes = new();
        
        /// <summary>
        /// Default:<HOUR><MINUTE>.<SECONDS> - $Gray$($Cyan$<CLASS>$Gray$): $White$<MESSAGE>
        /// </summary>
        public static string LogFormat = @"$White$<MESSAGE>";
        public static string ErrorFormat = "$Red$<HOUR>:<MINUTE>.<SECONDS> - Ocorreu um erro em $BackRed$$White$'<CLASS>.<FUNCTION>'$BackBlack$$Red$ Mensagem de Erro: $BackRed$$White$'<CUSTOMERRORMESSAGE>'$BackBlack$$Red$\nInformações:\n\nErro: <ERROR>\nSource: <ERRORSOURCE>\nStackTrace: \n<ERRORSTACKTRACE>\n\nCulpado: <TARGETSITE>";

        private static string logFileName = DataService.GetActualTimeString("[HH-mm] - dd-MM-yyyy");
        public static string ServerLogFormat { get; } = "<HOUR>:<MINUTE>:<SECONDS> - $Gray$($Cyan$<CLASS>$Gray$): $White$<MESSAGE>"; 

        public static Action OnTextPrinted;

        private static bool isExitEventCreated = false;

        public static string log { private set; get; } = DataService.GetActualTimeString() + "\n\n";

        /// <summary>
        /// Printa no console o parametro "Message" Formatado com base na string "LogFormat".
        /// Mais informações sobre como customizar o LogFormat na documentação
        /// </summary>
        /// <param name="Message"></param>
        public static void Print(string Message)
        {
            string RawOutput = LogFormat.Replace("<MESSAGE>", Message).Replace("<FUNCTION>", GetCallerMethodName()).Replace("<CLASS>", GetCallerClassName()).Replace("<HOUR>", DataService.GetActualTimeString("HH")).Replace("<MINUTE>", DataService.GetActualTimeString("mm")).Replace("<SECONDS>", DataService.GetActualTimeString("SS")).Replace("<MILIS>", DataService.GetActualTimeString("ML"));

            AplicarCores(RawOutput);
            
            Console.ResetColor(); // Certifique-se de redefinir as cores após a impressão.
        }

        /// <summary>
        /// Printa no console o parametro "Message" Formatado com base na string "LogFormat".
        /// Mais informações sobre como customizar o LogFormat na documentação
        /// </summary>
        /// <param name="Message"></param>
        public static void PrintLn(string Message, LogType? logType = null)
        {
            string RawOutput = LogFormat.Replace("<MESSAGE>", Message).Replace("<FUNCTION>", GetCallerMethodName()).Replace("<CLASS>", GetCallerClassName()).Replace("<HOUR>", DataService.GetActualTimeString("HH")).Replace("<MINUTE>", DataService.GetActualTimeString("mm")).Replace("<SECONDS>", DataService.GetActualTimeString("SS")).Replace("<MILIS>", DataService.GetActualTimeString("ML"));

            AplicarCores(RawOutput);
            Console.WriteLine();

            Console.ResetColor(); // Certifique-se de redefinir as cores após a impressão.
        }

        /// <summary>
        /// Salva o arquivo de log atual.
        /// </summary>
        public static void SaveLog()
        {
            DataService.MakeTxtFile(DataService.GetApplicationPath() + @"\logs\", logFileName, log);
        }

        public static string GetLog()
        {
            return log;
        }
        static string AplicarCores(string texto)
        {
            if (!isExitEventCreated)
            {
                AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
                {
                    //Print("$Yellow$Programa sendo encerrado. Salvando Log...", "Log");
                    SaveLog();
                    // Coloque aqui o código que deseja executar antes do encerramento do programa.
                };
                AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                    SaveLog();
                };
                isExitEventCreated = true;
            }

            // Mapeia nomes de cores para valores ConsoleColor
            Dictionary<string, ConsoleColor> cores = new Dictionary<string, ConsoleColor>
            {
                { "Black", ConsoleColor.Black },
                { "Blue", ConsoleColor.Blue },
                { "Cyan", ConsoleColor.Cyan },
                { "DarkBlue", ConsoleColor.DarkBlue },
                { "DarkCyan", ConsoleColor.DarkCyan },
                { "DarkGray", ConsoleColor.DarkGray },
                { "DarkGreen", ConsoleColor.DarkGreen },
                { "DarkMagenta", ConsoleColor.DarkMagenta },
                { "DarkRed", ConsoleColor.DarkRed },
                { "DarkYellow", ConsoleColor.DarkYellow },
                { "Gray", ConsoleColor.Gray },
                { "Green", ConsoleColor.Green },
                { "Magenta", ConsoleColor.Magenta },
                { "Red", ConsoleColor.Red },
                { "White", ConsoleColor.White },
                { "Yellow", ConsoleColor.Yellow }
            };

            Dictionary<string, ConsoleColor> backgroundColors = new Dictionary<string, ConsoleColor>
            {
                { "BackBlack", ConsoleColor.Black },
                { "BackBlue", ConsoleColor.Blue },
                { "BackCyan", ConsoleColor.Cyan },
                { "BackDarkBlue", ConsoleColor.DarkBlue },
                { "BackDarkCyan", ConsoleColor.DarkCyan },
                { "BackDarkGray", ConsoleColor.DarkGray },
                { "BackDarkGreen", ConsoleColor.DarkGreen },
                { "BackDarkMagenta", ConsoleColor.DarkMagenta },
                { "BackDarkRed", ConsoleColor.DarkRed },
                { "BackDarkYellow", ConsoleColor.DarkYellow },
                { "BackGray", ConsoleColor.Gray },
                { "BackGreen", ConsoleColor.Green },
                { "BackMagenta", ConsoleColor.Magenta },
                { "BackRed", ConsoleColor.Red },
                { "BackWhite", ConsoleColor.White },
                { "BackYellow", ConsoleColor.Yellow }
            };

            // Divide o texto em partes com base nas marcações de formatação
            string[] partes = texto.Split('$');

            foreach (string parte in partes)
            {
                if (cores.TryGetValue(parte, out ConsoleColor cor))
                {
                    Console.ForegroundColor = cor;
                }
                else if (backgroundColors.TryGetValue(parte, out ConsoleColor backcor))
                {
                    Console.BackgroundColor = backcor;
                }

                else
                {
                    Console.Write(parte); // Imprime a parte do texto
                    log += parte;
                }
            }
            log += "\n";
            return texto;
        }

        /// <summary>
        /// Printa no console o parametro "Message" Formatado com base na string "LogFormat" e com o Nome do Modulo(ModuleName).
        /// Mais informações sobre como customizar o LogFormat na documentação
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="ModuleName"></param>
        public static void Print(string Message, string ModuleName)
        {
            string RawOutput = LogFormat.Replace("<MESSAGE>", Message).Replace("<FUNCTION>", ModuleName).Replace("<CLASS>", ModuleName).Replace("<HOUR>", DataService.GetActualTimeString("HH")).Replace("<MINUTE>", DataService.GetActualTimeString("mm")).Replace("<SECONDS>", DataService.GetActualTimeString("SS")).Replace("<MILIS>", DataService.GetActualTimeString("ML"));

            AplicarCores(RawOutput);
            Console.WriteLine();

            Console.ResetColor();
        }

        /// <summary>
        /// Printa um erro detalhado no console com várias informações e com uma Mensagem customizada(CustomErrorMessage) Formatado com base na string "ErrorFormat"
        /// Mais informações sobre como customizar o ErrorFormat na documentação
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="CustomErrorMessage"></param>
        public static void PrintError(Exception ex, string CustomErrorMessage = "Mensagem customizada não especificada.")
        {
            string RawOutput = ErrorFormat.Replace("<FUNCTION>", GetCallerMethodName()).Replace("<CLASS>", GetCallerClassName())
                .Replace("<ERROR>", ex.Message)
                .Replace("<ERRORSOURCE>", ex.Source)
                .Replace("<ERRORSTACKTRACE>", ex.StackTrace)
                .Replace("<TARGETSITE>", ex.TargetSite.Name + "()")
                .Replace("<CUSTOMERRORMESSAGE>", CustomErrorMessage).Replace("<HOUR>", DataService.GetActualTimeString("HH")).Replace("<MINUTE>", DataService.GetActualTimeString("mm")).Replace("<SECONDS>", DataService.GetActualTimeString("SS")).Replace("<MILIS>", DataService.GetActualTimeString("ML"));

            AplicarCores(RawOutput);
            Console.WriteLine();

            SaveLog();

            Console.ResetColor();
        }
        static string GetCallerMethodName()
        {
            // Obtém a pilha de chamada
            StackTrace stackTrace = new StackTrace();

            // Obtém o quadro de pilha do chamador (o método que chamou quem chamou GetCallerMethodName)
            StackFrame callerFrame = stackTrace.GetFrame(2);

            // Obtém o método do quadro de pilha do chamador
            System.Reflection.MethodBase callerMethod = callerFrame.GetMethod();

            // Retorna o nome do método chamador
            return callerMethod.Name;
        }

        static string GetCallerClassName()
        {
            // Obtém a pilha de chamada
            StackTrace stackTrace = new StackTrace();

            // Obtém o quadro de pilha do chamador (o método que chamou quem chamou GetCallerClassName)
            StackFrame callerFrame = stackTrace.GetFrame(2);

            // Obtém o tipo (classe) do método do quadro de pilha do chamador
            Type callerType = callerFrame.GetMethod().DeclaringType;

            // Retorna o nome da classe do chamador
            return callerType.Name.Replace("<", "").Split('>')[0];
        }
    }
}
