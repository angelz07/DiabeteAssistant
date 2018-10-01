using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DiabeteAssistant.Class
{
    public class ToolsCheck
    {
        public Boolean TestIfRecorded()
        {
            Boolean retour = false;
            string fileName = PrefsApp.fileUserPref;


            Boolean IsFileConfigExist = DependencyService.Get<Class.IFileReadWrite>().IsFileExiste(fileName);
            if (IsFileConfigExist == true)
            {
                string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(fileName);
                var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(data);

                UserInfosObjectStruct infos = (UserInfosObjectStruct)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonObj.ToString(), typeof(UserInfosObjectStruct));
                if (infos.Recorded == "true")
                {
                    retour = true;
                }
            }
            else
            {
                UserInfosObjectStruct UserInfos = new UserInfosObjectStruct
                {
                    Recorded = "",
                    Prenom = "",
                    Nom = "",
                    Mail = "",
                    Gsm = "",
                    DateNaissance = "",
                    NomContact = "",
                    PrenomContact = "",
                    GsmContact = "",
                    MailContact = "",
                    HeureMatin = "",
                    HeureMidi = "",
                    HeureSoir = ""
                };

                string json = JsonConvert.SerializeObject(UserInfos);
                DependencyService.Get<Class.IFileReadWrite>().WriteData(fileName, json);
            }
            return retour;
        }

        public Boolean TestIfGlycemieRecorded()
        {
            Boolean retour = false;
            string fileName = PrefsApp.fileConfigGlycemie;


            Boolean IsFileConfigExist = DependencyService.Get<Class.IFileReadWrite>().IsFileExiste(fileName);
            if (IsFileConfigExist == true)
            {

                string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(fileName);
                var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(data);

                GlycemieInfosObjectStruct infosGlycemie = (GlycemieInfosObjectStruct)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonObj.ToString(), typeof(GlycemieInfosObjectStruct));
                if (infosGlycemie.GlycemieConfigRecorded == "true")
                {
                    retour = true;
                }
            }
            else
            {
                try
                {
                    GlycemieInfosObjectStruct infosGlycemie = new GlycemieInfosObjectStruct
                    {
                        GlycemieConfigRecorded = "",

                        GlycemieMoins70Matin = "",
                        GlycemieMoins70Midi = "",
                        GlycemieMoins70Soir = "",

                        Glycemie70A100Matin = "",
                        Glycemie70A100Midi = "",
                        Glycemie70A100Soir = "",

                        Glycemie101A150Matin = "",
                        Glycemie101A150Midi = "",
                        Glycemie101A150Soir = "",

                        Glycemie151A200Matin = "",
                        Glycemie151A200Midi = "",
                        Glycemie151A200Soir = "",

                        Glycemie201A250Matin = "",
                        Glycemie201A250Midi = "",
                        Glycemie201A250Soir = "",

                        Glycemie251A300Matin = "",
                        Glycemie251A300Midi = "",
                        Glycemie251A300Soir = "",

                        GlycemiePlus300Matin = "",
                        GlycemiePlus300Midi = "",
                        GlycemiePlus300Soir = "",
                    };

                    string json = JsonConvert.SerializeObject(infosGlycemie);
                    DependencyService.Get<Class.IFileReadWrite>().WriteData(fileName, json);
                }
                catch (Exception erreur)
                {
                    Console.WriteLine("Erreur Test si Glycemie est enregistrer Ecriture Fichier : " + erreur.Message.ToString());
                }

            }
            return retour;
        }
    }
}
