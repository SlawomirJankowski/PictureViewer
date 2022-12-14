using System.IO;

namespace PictureViewer
{
    internal static class AppSettings
    {
        public static void SaveImageLocationProperty(string imageLocation)
        {
            File.WriteAllText(Program._settingsFilePath, imageLocation);
        }

        public static string LoadImageLocationProperty(string path)
        {
            try { return File.ReadAllText(path); }
            catch { return null; }
        }
    }
}
