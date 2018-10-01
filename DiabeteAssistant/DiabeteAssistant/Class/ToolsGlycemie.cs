using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DiabeteAssistant.Class
{
    public class ToolsGlycemie
    {
        public string FindNombreUniteInsuline(string glycemieMesure, string nomHeureCalculUnitie, MainPage mainPage)
        {
            string Retour = "";

            string fileName = PrefsApp.fileConfigGlycemie;
            string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(fileName);
            var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(data);
           
            GlycemieInfosObjectStruct InfosGlycemie = (GlycemieInfosObjectStruct)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonObj.ToString(), typeof(GlycemieInfosObjectStruct));
            if (InfosGlycemie.GlycemieConfigRecorded == "true")
            {
               

                if (PrefsApp.NomHeureCalculUnitie == "Matin")
                {
                   
                    if (FindNombreUniteMatin(glycemieMesure, InfosGlycemie) != "erreur")
                    {
                        Console.Write("retour glycemie:" + Retour);
                        Retour = FindNombreUniteMatin(glycemieMesure, InfosGlycemie);
                    }
                    else
                    {
                        Retour = "erreur";
                    }

                }
                else if (PrefsApp.NomHeureCalculUnitie == "Midi")
                {
                    if (FindNombreUniteMidi(glycemieMesure, InfosGlycemie) != "erreur")
                    {
                        Console.Write("retour glycemie:" + Retour);
                        Retour = FindNombreUniteMidi(glycemieMesure, InfosGlycemie);
                    }
                    else
                    {
                        Retour = "erreur";
                    }
                }
                else if (PrefsApp.NomHeureCalculUnitie == "Soir")
                {
                    if (FindNombreUniteSoir(glycemieMesure, InfosGlycemie) != "erreur")
                    {
                        Console.Write("retour glycemie:" + Retour);
                        Retour = FindNombreUniteSoir(glycemieMesure, InfosGlycemie);
                    }
                    else
                    {
                        Retour = "erreur";
                    }
                }
                else
                {
                    Retour = "erreur";
                }

            }
            else
            {
                Retour = "erreur";
            }

            return Retour;
        }

        private string FindNombreUniteSoir(string glycemieMesure, GlycemieInfosObjectStruct InfosGlycemie)
        {
            string Retour = "erreur";
            try
            {
                Console.WriteLine("glycemie: " + glycemieMesure);
                int glycemieNumerique = Convert.ToInt32(glycemieMesure);
                if (glycemieNumerique < 70)
                {
                    Retour = InfosGlycemie.GlycemieMoins70Soir;
                }
                else if (glycemieNumerique >= 70 && glycemieNumerique < 101)
                {
                    Retour = InfosGlycemie.Glycemie70A100Soir;
                }
                else if (glycemieNumerique >= 101 && glycemieNumerique < 151)
                {
                    Retour = InfosGlycemie.Glycemie101A150Soir;
                }
                else if (glycemieNumerique >= 151 && glycemieNumerique < 201)
                {
                    Retour = InfosGlycemie.Glycemie151A200Soir;
                }
                else if (glycemieNumerique >= 201 && glycemieNumerique < 251)
                {
                    Retour = InfosGlycemie.Glycemie201A250Soir;
                }
                else if (glycemieNumerique >= 251 && glycemieNumerique < 301)
                {
                    Retour = InfosGlycemie.Glycemie251A300Soir;
                }
                else if (glycemieNumerique > 300)
                {
                    Retour = InfosGlycemie.GlycemiePlus300Soir;
                }
                Console.WriteLine("glycemieNumerique: " + InfosGlycemie.GlycemieMoins70Midi);
            }
            catch (Exception error)
            {
                Retour = "erreur";
                Console.WriteLine("Utlisateur non enregistré. ou erreur:" + error.Message.ToString());
            }

            return Retour;
        }

        private string FindNombreUniteMidi(string glycemieMesure, GlycemieInfosObjectStruct InfosGlycemie)
        {
            string Retour = "erreur";
            try
            {
                Console.WriteLine("glycemie: " + glycemieMesure);
                int glycemieNumerique = Convert.ToInt32(glycemieMesure);
                if (glycemieNumerique < 70)
                {
                    Retour = InfosGlycemie.GlycemieMoins70Midi;
                }
                else if (glycemieNumerique >= 70 && glycemieNumerique < 101)
                {
                    Retour = InfosGlycemie.Glycemie70A100Midi;
                }
                else if (glycemieNumerique >= 101 && glycemieNumerique < 151)
                {
                    Retour = InfosGlycemie.Glycemie101A150Midi;
                }
                else if (glycemieNumerique >= 151 && glycemieNumerique < 201)
                {
                    Retour = InfosGlycemie.Glycemie151A200Midi;
                }
                else if (glycemieNumerique >= 201 && glycemieNumerique < 251)
                {
                    Retour = InfosGlycemie.Glycemie201A250Midi;
                }
                else if (glycemieNumerique >= 251 && glycemieNumerique < 301)
                {
                    Retour = InfosGlycemie.Glycemie251A300Midi;
                }
                else if (glycemieNumerique > 300)
                {
                    Retour = InfosGlycemie.GlycemiePlus300Midi;
                }
                Console.WriteLine("glycemieNumerique: " + InfosGlycemie.GlycemieMoins70Midi);
            }
            catch (Exception error)
            {
                Retour = "erreur";
                Console.WriteLine("Utlisateur non enregistré. ou erreur:" + error.Message.ToString());
            }

            return Retour;
        }

        private string FindNombreUniteMatin(string glycemieMesure, GlycemieInfosObjectStruct InfosGlycemie)
        {
           
            string Retour = "erreur";
            try
            {
                Console.WriteLine("glycemie: " + glycemieMesure);
                int glycemieNumerique = Convert.ToInt32(glycemieMesure);
                if (glycemieNumerique < 70)
                {
                   
                    Retour = InfosGlycemie.GlycemieMoins70Matin;
                }
                else if (glycemieNumerique >= 70 && glycemieNumerique < 101)
                {
                 
                    Retour = InfosGlycemie.Glycemie70A100Matin;
                }
                else if (glycemieNumerique >= 101 && glycemieNumerique < 151)
                {
                   
                    Retour = InfosGlycemie.Glycemie101A150Matin;
                }
                else if (glycemieNumerique >= 151 && glycemieNumerique < 201)
                {
                    
                    Retour = InfosGlycemie.Glycemie151A200Matin;
                }
                else if (glycemieNumerique >= 201 && glycemieNumerique < 251)
                {
                   
                    Retour = InfosGlycemie.Glycemie201A250Matin;
                }
                else if (glycemieNumerique >= 251 && glycemieNumerique < 301)
                {
                   
                    Retour = InfosGlycemie.Glycemie251A300Matin;
                }
                else if (glycemieNumerique > 300)
                {
                    
                    Retour = InfosGlycemie.GlycemiePlus300Matin;
                }
              //  Console.WriteLine("glycemieNumerique: " + InfosGlycemie.GlycemieMoins70Matin);
            }
            catch (Exception error)
            {
                Retour = "erreur";
               
                Console.WriteLine("Utlisateur non enregistré. ou erreur:" + error.Message.ToString());
            }

            return Retour;
        }
    }
}
