using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DiabeteAssistant.Class
{
    public class ConfigurationGlycemie
    {
        public bool TestIfMomentFilesJsonExist() {
            Boolean Retour = false;

            try
            {
                Boolean IsFileConfigMatinExist = DependencyService.Get<Class.IFileReadWrite>().IsFileExiste(PrefsApp.fileMatinGlycemie);

                if (IsFileConfigMatinExist == false || DependencyService.Get<Class.IFileReadWrite>().ReadData(PrefsApp.fileMatinGlycemie) == null)
                {
                    List<Matin> NewListMatin = new List<Matin>();
                    string json = JsonConvert.SerializeObject(NewListMatin, Formatting.Indented);
                    DependencyService.Get<Class.IFileReadWrite>().WriteData(PrefsApp.fileMatinGlycemie, json);
                }
                Retour = true;
            }
            catch (Exception)
            {
                Retour = false;
            }

            try
            {
                Boolean IsFileConfigMidiExist = DependencyService.Get<Class.IFileReadWrite>().IsFileExiste(PrefsApp.fileMidiGlycemie);
                if (IsFileConfigMidiExist == false)
                {
                    List<Midi> NewListMidi = new List<Midi>();
                    string json = JsonConvert.SerializeObject(NewListMidi, Formatting.Indented);
                    DependencyService.Get<Class.IFileReadWrite>().WriteData(PrefsApp.fileMidiGlycemie, json);
                }
                Retour = true;
            }
            catch (Exception)
            {
                Retour = false;
            }


            try
            {
                Boolean IsFileConfigSoirExist = DependencyService.Get<Class.IFileReadWrite>().IsFileExiste(PrefsApp.fileSoirGlycemie);
                if (IsFileConfigSoirExist == false)
                {
                    List<Soir> NewListSoir = new List<Soir>();
                    string json = JsonConvert.SerializeObject(NewListSoir, Formatting.Indented);
                    DependencyService.Get<Class.IFileReadWrite>().WriteData(PrefsApp.fileSoirGlycemie, json);
                }
                Retour = true;
            }
            catch (Exception)
            {
                Retour = false;
            }
            

            return Retour;
        }
    }
}
