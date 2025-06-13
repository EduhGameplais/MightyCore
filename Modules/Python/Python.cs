using System.Diagnostics;

namespace Mighty
{
    public static class Python
    {
        public static string PythonExecutablePath { get; private set; }

        public static void SetCustomPythonExecPath(string customPythonPath)
        {
            PythonExecutablePath = customPythonPath + @"\python.exe";
        }

        /*public static void RunFunctionInCode(string function, dynamic[] args = null)
        {

        }
        public static string RunFunctionInCodeString(string function, dynamic[] args = null) 
        {
            
        }*///Make Later

        public static void Run(string codePath, bool waitForEndCode = true)
        {
            if (PythonExecutablePath == null)
            {
                Log.Print("$Yellow$Tentando encontrar algum python instalado...");
                FindInstalledPython();
                if (PythonExecutablePath == null)
                {
                    Log.Print("$Red$Nenhum python foi detectado automaticamente, instale ou então use SetCustomPythonExecPath.");
                    throw new InvalidOperationException("Nenhum python foi detectado automaticamente, instale ou então use SetCustomPythonExecPath antes do código.");
                }
                else
                {
                    Log.Print($"$Green$Python encontrado em: {PythonExecutablePath}");
                }
            }

            Process process = new Process();
            process.StartInfo.FileName = PythonExecutablePath;
            process.StartInfo.Arguments = codePath;
            process.Start();
            if (waitForEndCode)
                process.WaitForExit();
                
        }
        public static void FindInstalledPython()
        {
            string pathVariable = Environment.GetEnvironmentVariable("PATH");
            string[] paths = pathVariable.Split(';');

            foreach (string path in paths)
            {
                if (path.ToLower().Contains("python"))
                {
                    PythonExecutablePath = path + @"\python.exe";
                }
            }
        }

        public static void RunCode(string code, bool waitEndOfCode = true)
        {
            if (PythonExecutablePath == null)
            {
                Log.Print("$Yellow$Tentando encontrar algum python instalado...");
                FindInstalledPython();
                if (PythonExecutablePath == null)
                {
                    Log.Print("$Red$Nenhum python foi detectado automaticamente, instale ou então use SetCustomPythonExecPath.");
                    throw new InvalidOperationException("Nenhum python foi detectado automaticamente, instale ou então use SetCustomPythonExecPath antes do código.");
                }
                else
                {
                    Log.Print($"$Green$Python encontrado em: {PythonExecutablePath}");
                }
            }

            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, code);
            Run(tempFile, waitEndOfCode);

            
        }

        public static void InstallLibrary(string lib, string version = "", bool verify = false)
        {
            if (PythonExecutablePath == null)
            {
                Log.Print("$Yellow$Tentando encontrar algum python instalado...");
                FindInstalledPython();
                if (PythonExecutablePath == null)
                {
                    Log.Print("$Red$Nenhum python foi detectado automaticamente, instale ou então use SetCustomPythonExecPath.");
                    throw new InvalidOperationException("Nenhum python foi detectado automaticamente, instale ou então use SetCustomPythonExecPath antes do código.");
                }
                else
                {
                    Log.Print($"$Green$Python encontrado em: {PythonExecutablePath}");
                }
            }

            Log.Print($"$Yellow$Tentando instalar '{lib}' na versão '{version}'...");

            if (version == "")
                Run("-m pip install " + lib);
            else
                Run("-m pip install " + lib + "==" + version);

            if (verify)
            {
                Log.Print("$Yellow$Verificando lib...");
                RunCode(@$"import importlib

try:
    import {lib}
    print(""\033[92mLib foi instalada corretamente."")
except ImportError:
    print(""\033[91mLib não foi instalada corretamente."")");
            }

            Log.Print($"$Green$Tentativa de instalar '{lib}' concluída.");
        }

        public static string DownloadPython(string version)
        {
            // Implementação para download do Python
            // Retorne o caminho para o executável baixado ou faça o download e retorne vazio ("") caso não seja necessário neste contexto.
            return "";
        }
    }
}
