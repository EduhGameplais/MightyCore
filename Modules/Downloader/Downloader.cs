using System;
using System.IO;
using System.Net;
using System.IO.Compression;


namespace Mighty
{
    public class Downloader
    {
        private static string _downloadDirectory;
        private static string _downloadedFileDirectory;
        private static string _unzipedDirectory;
        /// <summary>
        /// Download a file from especific URL.
        /// </summary>
        public static string DownloadFromUrl(DownloadingSettings downloaderConfig)
        {

            Log.Print("$Yellow$Getting downloading settings...");

            Log.Print("$Yellow$Making download directory...");
            DataService.MakeDirectory(downloaderConfig.DownloadDirectory);



            if (downloaderConfig.ExtractFiles)
                using (var client = new WebClient())
                {
                    try
                    {
                        Log.Print("Extract files required.");



                        Random random = new Random();
                        _downloadDirectory = DataService.GetTempPath() + @"Downloads\" + random.Next(9999999) + "x" + random.Next(9999999) + "x" + random.Next(9999999);



                        Log.Print("$Yellow$Starting downloading of: " + '"' + downloaderConfig.FileUrl + '"' + $" on {_downloadDirectory}");

                        DataService.MakeDirectory(_downloadDirectory);

                        _downloadedFileDirectory = _downloadDirectory + @"\" + random.Next(11111, int.MaxValue) + ".mpmextract";

                        client.DownloadFile(downloaderConfig.FileUrl, _downloadedFileDirectory);

                        Log.Print("$Green$Download Completed!");
                    }
                    catch(Exception e)
                    {
                        Log.PrintError(e, $"Error on download file: '{downloaderConfig.FileUrl}' to '{downloaderConfig.DownloadDirectory}'");

                        return null;
                    }

                    try
                    {
                        Log.Print("$Yellow$Initializing file extraction...");

                        _unzipedDirectory = downloaderConfig.DownloadDirectory;

                        ZipFile.ExtractToDirectory(
                            _downloadedFileDirectory,
                            _unzipedDirectory
                            );



                        Log.Print($"$Green$Extraction occurred successfully: {_unzipedDirectory}");

                        return _unzipedDirectory;
                    }
                    catch (Exception e)
                    {
                        Log.PrintError(e, $"Error on extract file: '{_downloadedFileDirectory}' to '{_unzipedDirectory}'");

                        return null;
                    }
                }
            else
                using (var client = new WebClient())
                {
                    try
                    {
                        Log.Print("Extract files are not required.", "Downloader");
                        Random random = new Random();
                        _downloadDirectory = DataService.GetTempPath() + @"Downloads\" + random.Next(9999999) + "x" + random.Next(9999999) + "x" + random.Next(9999999);

                        DataService.MakeDirectory(_downloadDirectory);

                        Log.Print("$Yellow$Starting downloading of: " + '"' + downloaderConfig.FileUrl + '"' + $" on {_downloadDirectory}");

                        _downloadedFileDirectory = _downloadDirectory + @"\" + random.Next(11111, int.MaxValue) + ".png";

                        client.DownloadFile(downloaderConfig.FileUrl, _downloadedFileDirectory);

                        Log.Print("$Green$Download Completed!");

                        return _downloadedFileDirectory;
                    }
                    catch (Exception e)
                    {
                        Log.PrintError(e, $"Error on download file: '{downloaderConfig.FileUrl}' to '{downloaderConfig.DownloadDirectory}'");

                        return null;
                    }
                }

        }
    }
    
}
