using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DiabeteAssistant.Class;
using DiabeteAssistant.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace DiabeteAssistant.Droid
{
    public class FileHelper : IFileReadWrite
    {
        public void WriteData(string filename, string data)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, data);
        }
        public string ReadData(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
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