namespace Mighty
{
    public static class ArgsParser
    {
        static string[] Args = null;

        public static void SetArgs(string[] args)
        {
            Args = args;
        }

        public static bool GetArgEnabled(string Arg)
        {
            for (int i = 0; i < Args.Length; i++)
            {
                if (Args[i] == "--" + Arg & Args[i + 1] == "ON")
                {
                    return true;
                }
                if (Args[i] == "--" + Arg & Args[i + 1] == "OFF")
                {
                    return false;
                }
            }
            return false;
        }

        public static double GetArgDouble(string Arg)
        {
            for (int i = 0; i < Args.Length; i++)
            {
                if (Args[i] == "--" + Arg)
                {
                    return double.Parse(Args[i + 1]);
                }
                if (Args[i] == "--" + Arg + "-OFF")
                {
                    return double.Parse(Args[i + 1]);
                }
            }
            return 0;
        }

        public static string GetArgString(string Arg)
        {
            for (int i = 0; i < Args.Length; i++)
            {
                if (Args[i] == "--" + Arg)
                {
                    return Args[i + 1];
                }
                if (Args[i] == "--" + Arg + "-OFF")
                {
                    return Args[i + 1];
                }
            }
            return null;
        }
    }
}
