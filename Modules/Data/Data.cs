using System;

namespace Mighty
{
    public class MData
    {
        public string DataDirectory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// Set Directory of data.
        /// </summary>
        /// <param name="dataDirectory"></param>
        public void SetDirectory(string dataDirectory)
        {
            DataDirectory = dataDirectory;
            Log.Print("$Green$Set data directory!");
        }

        public void SaveData()
        {
            Log.Print($"Data saved on: {DataDirectory}", "Data");
        }

    }
}
