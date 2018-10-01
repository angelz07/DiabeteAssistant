using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DiabeteAssistant.Fichiers
{
    public class PrefsApp
    {
        public static string fileUserPref = "preferences.json";
        public static string fileConfigGlycemie = "glycemie.json";
        public static string fileMatinGlycemie = "HistoriqueMatinGlycemie.json";
        public static string fileMidiGlycemie = "HistoriqueMidiGlycemie.json";
        public static string fileSoirGlycemie = "HistoriqueSoirGlycemie.json";
        public static IFormatProvider cultureApp = new CultureInfo("fr-FR", true);
        public static bool MesureIsActive = false;


        public static string HeureRefMesure = "";
        public static string NomMomentRefMesure = "";
        public static string heureDeMesure = "";

        public static string NomHeureMessage = "";
        public static string Heure = "";

        public static string NomHeure = "";
        public static string NomHeureCalculUnitie = "";

        public static string GlycemieMesure = "";

        public static string InsulineNbUnite = "";
    }
}
