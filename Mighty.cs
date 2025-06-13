namespace Mighty
{
    /// <summary>
    /// Mighty primary class.
    /// </summary>
    public static class MMighty
    {

        public static bool Debug { get; private set; }
        public static bool ProgramDebug { get; private set; }
        //public static bool extremeDebug { get; private set; } -- REMOVED ON VERSION 0.1.0 public release

        /// <summary>
        /// Start printing Mighty debug Log on console.
        /// </summary>
        public static void SaveLog()
        {
            if (Debug)
            { 
                //Log.SaveLog();
            }
        }

        /// <summary>
        /// Verify Mighty updates ---
        ///  
        /// if with the updates your program get errors Mighty go to use the old version.
        /// </summary>

        static void OnExit(object sender, EventArgs e)
        {
            Log.Print("Mighty", "Save Log Disabled.");
            //Log.SaveLog();
        }
    }
}
