using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DiabeteAssistant.Class
{
    public class MakeStackUIBase
    {
        FindInfos FindInfos = new FindInfos();
        Tools Tools = new Tools();
        Horloges Horloges = new Horloges();

        public StackLayout StackUIBase(StackLayout StackMainID, string arg, string message, MainPage ThisLocal) {
            StackLayout Retour = new StackLayout();

            UserInfosObjectStruct InfosUser = FindInfos.FindInfosUser();

            DateTime dateNow = DateTime.Now;
            DateTime dNow = DateTime.Parse(dateNow.Hour.ToString() + ":" + dateNow.Minute.ToString(), PrefsApp.cultureApp); //Peut être utiliser DateTime.TryParse pour valider l'heure
            DateTime dMatin = DateTime.Parse(InfosUser.HeureMatin, PrefsApp.cultureApp);
            DateTime dMidi = DateTime.Parse(InfosUser.HeureMidi, PrefsApp.cultureApp);
            DateTime dSoir = DateTime.Parse(InfosUser.HeureSoir, PrefsApp.cultureApp);

            string Quand = Tools.MomentJourneeMesure(dMatin, dMidi, dSoir, dNow);


          //  string Heure = "";
          //  string NomHeureMessage = "";
            if (Quand == "midi")
            {
                PrefsApp.Heure = InfosUser.HeureMidi;
                PrefsApp.HeureRefMesure = InfosUser.HeureMidi;
                PrefsApp.NomHeureMessage = "de midi";
                PrefsApp.NomMomentRefMesure = "midi";
            }

            else if (Quand == "soir")
            {
                PrefsApp.Heure = InfosUser.HeureSoir;
                PrefsApp.HeureRefMesure = InfosUser.HeureSoir;
                PrefsApp.NomHeureMessage = "du soir";
                PrefsApp.NomMomentRefMesure = "soir";
            }

            else
            {
                PrefsApp.Heure = InfosUser.HeureMatin;
                PrefsApp.HeureRefMesure = InfosUser.HeureMatin;
                PrefsApp.NomHeureMessage = "du matin";
                PrefsApp.NomMomentRefMesure = "matin";
            }

            PrefsApp.heureDeMesure = PrefsApp.Heure;

            Label Infos = new Label
            {

                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                StyleId = "InfosID",
                BackgroundColor = Color.Azure,
                TextColor = Color.Red,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
        };

            if (arg == "rater")
            {
                Console.WriteLine("RATER " + message);
                Infos.Text = message;
                Infos.TextColor = Color.Red;
                //                Infos.BackgroundColor = Color.;
            }
            else if (arg == "valider")
            {
                Console.WriteLine("valider " + message);
                Infos.Text = message;
                Infos.TextColor = Color.Green;
                //               Infos.BackgroundColor = Color.Indigo;
            }
            else
            {
                //  Console.WriteLine("ELSE");
                Infos.Text = "";
            }




            Frame HorlogeEncadrement = new Frame()
            {
                BorderColor = Color.BlueViolet,
                Margin = new Thickness(0, 10, 0, 10),
                HasShadow = true,
                Padding = 5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand

            };


            Label Horloge = new Label
            {
                Text = "",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                StyleId = "HorlogeID",

                TextColor = Color.Blue,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))

            };
            HorlogeEncadrement.Content = Horloge;






            Label Bienvenue = new Label
            {
                Text = "Bonjour " + InfosUser.Prenom + " " + InfosUser.Nom + " votre prochain controle " + PrefsApp.NomHeureMessage + " est à : " + PrefsApp.Heure,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.DarkSlateBlue,
                StyleId = "BienvenueID",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Retour.Children.Add(Infos);
            Retour.Children.Add(HorlogeEncadrement);
            Retour.Children.Add(Bienvenue);



            

            Horloges._isRunningMainTimer = true;
            Horloges.SetTimerMain(Horloge, StackMainID, ThisLocal);


            return Retour;
        }
    }
}
