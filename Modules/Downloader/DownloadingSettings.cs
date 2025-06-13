using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty
{

    /// <summary>
    /// Settings for downloading a File from a URL.
    /// </summary>
    public class DownloadingSettings
    {
        public string FileUrl { get; private set; }
        public string DownloadDirectory { get; private set; }

        public bool ExtractFiles { get; private set; } = false;


        public DownloadingSettings(string fileUrl, string downloadDirectory)
        {
            FileUrl = fileUrl;
            DownloadDirectory = downloadDirectory;
        }
        public DownloadingSettings(string fileUrl, string downloadDirectory, bool extractFiles)
        {
            FileUrl = fileUrl;
            DownloadDirectory = downloadDirectory;
            ExtractFiles = extractFiles;
        }
    }
}
