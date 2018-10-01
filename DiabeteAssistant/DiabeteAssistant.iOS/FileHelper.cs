using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DiabeteAssistant.Class;
using DiabeteAssistant.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace DiabeteAssistant.iOS
{
    public class FileHelper : IFileReadWrite
    {
        public void WriteData(string filename, string data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, data);
        }
        public string ReadData(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllText(filePath);
        }

        public Boolean IsFileExiste(string filename)
        {
            Boolean retour = false;
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            if (File.Exists(filePath))
            {

                retour = true;
            }

            return retour;
        }
    }
}