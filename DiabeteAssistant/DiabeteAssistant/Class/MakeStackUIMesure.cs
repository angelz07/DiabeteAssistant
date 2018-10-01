using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace DiabeteAssistant.Class
{
    public class MakeStackUIMesure
    {
        FindInfos FindInfos = new FindInfos();
        Tools Tools = new Tools();
        Horloges Horloges = new Horloges();
        ToolsGlycemie ToolsGlycemie = new ToolsGlycemie();

        public StackLayout StackUIMesure(MainPage mainPage, StackLayout StackMainID)
        {
            StackLayout Retour = new StackLayout();

            UserInfosObjectStruct InfosUser = FindInfos.FindInfosUser();
            DateTime dateNow = DateTime.Now;
            DateTime dNow = DateTime.Parse(dateNow.Hour.ToString() + ":" + dateNow.Minute.ToString(), PrefsApp.cultureApp); //Peut être utiliser DateTime.TryParse pour valider l'heure
            DateTime dMatin = DateTime.Parse(InfosUser.HeureMatin, PrefsApp.cultureApp);
            DateTime dMidi = DateTime.Parse(InfosUser.HeureMidi, PrefsApp.cultureApp);
            DateTime dSoir = DateTime.Parse(InfosUser.HeureSoir, PrefsApp.cultureApp);


            if (PrefsApp.NomMomentRefMesure == "midi")
            {

                PrefsApp.Heure = InfosUser.HeureMidi;
                PrefsApp.NomHeure = "de Midi";
                PrefsApp.NomHeureCalculUnitie = "Midi";
            }

            else if (PrefsApp.NomMomentRefMesure == "soir")
            {

                PrefsApp.Heure = InfosUser.HeureSoir;
                PrefsApp.NomHeure = "du Soir";
                PrefsApp.NomHeureCalculUnitie = "Soir";
            }

            else
            {

                PrefsApp.Heure = InfosUser.HeureMatin;
                PrefsApp.NomHeure = "du Matin";
                PrefsApp.NomHeureCalculUnitie = "Matin";
            }

            Label Alert = new Label
            {
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.Bold,

                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Azure,
                TextColor = Color.Red,
                StyleId = "AlertID",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            if (Horloges.isAlert == true)
            {
                Alert.Text = Horloges.AlertMessage;
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
                Text = "c'est l'heure de mesurer votre glycémie et de prendre vos médicaments pour le repas " + PrefsApp.NomHeure,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                StyleId = "BienvenueID",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };


            Label GlycemieLabel = new Label
            {
                Text = "Glycémie",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.None,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                StyleId = "",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };


            Entry Glycemie = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.None,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                StyleId = "",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            

            Label Insuline = new Label
            {
                Text = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.None,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                StyleId = "",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Glycemie.Unfocused += (sender, EventArgs) => { Glycemie_lostFocus(sender, EventArgs, Insuline, Glycemie, mainPage); };
            /*
             Ajout switch si necessaire
             
             */

            Button BpSave = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.None,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Valider"
            };
            //  BpSave.Clicked += ButtonSave_Clicked;
            BpSave.Clicked += (sender, EventArgs) => { ButtonSave_Clicked(sender, EventArgs, Alert, Horloge, Bienvenue, Glycemie, Insuline, mainPage); };
            // StackMainID.Children.Add(baseStack);


            Retour.Children.Add(Alert);
            Retour.Children.Add(HorlogeEncadrement);
            Retour.Children.Add(Bienvenue);
            Retour.Children.Add(GlycemieLabel);
            Retour.Children.Add(Glycemie);
            Retour.Children.Add(Insuline);
         //   Retour.Children.Add(validateMesure);
            Retour.Children.Add(BpSave);


            Horloges._isRunningMesureTimer = true;
            Horloges.SetTimerMesure(Horloge, Alert, mainPage, StackMainID);
            // Label Timer2, Label Alert, MainPage MainPageLocal, StackLayout StackMainID

            

            return Retour;
        }

        public void Glycemie_lostFocus(object sender, FocusEventArgs eventArgs, Label insuline, Entry glycemie, MainPage mainpage)
        {
            PrefsApp.GlycemieMesure = glycemie.Text;
            //DisplayAlert("infos", "GlycemieMesure:" + GlycemieMesure + " ", "ok");
            string resultCalculInsuline = ToolsGlycemie.FindNombreUniteInsuline(PrefsApp.GlycemieMesure, PrefsApp.NomHeureCalculUnitie, mainpage);
           // mainpage.ShowMessage("Erreur", resultCalculInsuline, "OK");
            // DisplayAlert("infos", resultCalculInsuline, "ok");
              if (resultCalculInsuline != "erreur")
              {
                  insuline.BackgroundColor = Color.Aqua;
                  insuline.TextColor = Color.Green;
                  insuline.FontAttributes = FontAttributes.Bold;
                  PrefsApp.InsulineNbUnite = resultCalculInsuline;
                  insuline.Text = PrefsApp.InsulineNbUnite + " Unités";
              }
              else
              {
                  mainpage.ShowMessage("Erreur", "Il y a eu une erreur veuillez recommencer.", "OK");
              }
        }

        public void ButtonSave_Clicked(object sender, EventArgs e, Label Alert, Label Horloge, Label Bienvenue, Entry Glycemie, Label Insuline, MainPage mainPage)
        {
            bool isCompleteGlycemie = true;
            Horloges._isRunningMesureTimer = false;
            PrefsApp.MesureIsActive = false;
            Horloges.isAlert = false;

            if (PrefsApp.GlycemieMesure == "" || PrefsApp.GlycemieMesure == null)
            {
                isCompleteGlycemie = false;
            }

            if (PrefsApp.InsulineNbUnite == "" || PrefsApp.InsulineNbUnite == null)
            {
                isCompleteGlycemie = false;
            }




            if (isCompleteGlycemie == false)
            {
                mainPage.ShowMessage("Erreur", "Vous devez inscrire votre taux de Glycémie et valider!", "OK");
            }
            else
            {
                if (PrefsApp.NomHeureCalculUnitie == "Matin")
                {
                    //  DisplayAlert("infos", "Matin", "ok");
                    string fileName = PrefsApp.fileMatinGlycemie;

                    string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(fileName);
                    var list = JsonConvert.DeserializeObject<List<Matin>>(data);

                    PrefsApp.GlycemieMesure = Glycemie.Text;
                    PrefsApp.InsulineNbUnite =  Regex.Replace(Insuline.Text, "[^0-9.]", ""); 

                    Matin infosMatin = new Matin();
                    DateTime dateNow = DateTime.Now;
                    infosMatin.DatePriseMesure = DateTime.Now.ToString("dd-MM-yyyy");
                    infosMatin.HeurePriseMesure = DateTime.Now.ToString("HH:mm");
                    infosMatin.Glycemie = PrefsApp.GlycemieMesure;
                    infosMatin.Insuline = PrefsApp.InsulineNbUnite;
                    infosMatin.Quand = PrefsApp.NomMomentRefMesure;


                    list.Add(infosMatin);
                    string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                    DependencyService.Get<Class.IFileReadWrite>().WriteData(fileName, json);

                    string message = "votre glycemie pour " + PrefsApp.NomHeure + " était de : " + PrefsApp.GlycemieMesure + " vous avez pris : " + PrefsApp.InsulineNbUnite + " Unités d'insuline à : " + Horloge.Text + " .";


                    // AlertSonore.StopVibrerTéléphone();
                    //  AlertSonore.StopAlarmTéléphone();
                    mainPage.UIBase("valider", message);
                }


                else if (PrefsApp.NomHeureCalculUnitie == "Midi")
                {

                    //  DisplayAlert("infos", "Midi", "ok");
                    string fileName = PrefsApp.fileMidiGlycemie;

                    string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(fileName);
                    var list = JsonConvert.DeserializeObject<List<Midi>>(data);


                    PrefsApp.GlycemieMesure = Glycemie.Text;
                    PrefsApp.InsulineNbUnite = Regex.Replace(Insuline.Text, "[^0-9.]", ""); 


                    Midi infosMidi = new Midi();
                    DateTime dateNow = DateTime.Now;
                    infosMidi.DatePriseMesure = DateTime.Now.ToString("dd-MM-yyyy");
                    infosMidi.HeurePriseMesure = DateTime.Now.ToString("HH:mm");
                    infosMidi.Glycemie = PrefsApp.GlycemieMesure;
                    infosMidi.Insuline = PrefsApp.InsulineNbUnite;
                    infosMidi.Quand = PrefsApp.NomMomentRefMesure;

                    list.Add(infosMidi);
                    string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                    DependencyService.Get<Class.IFileReadWrite>().WriteData(fileName, json);

                    // AlertSonore.StopVibrerTéléphone();
                    // AlertSonore.StopAlarmTéléphone();
                    string message = "votre glycemie pour " + PrefsApp.NomHeure + " était de : " + PrefsApp.GlycemieMesure + " vous avez pris : " + PrefsApp.InsulineNbUnite + " Unités d'insuline à : " + Horloge.Text + " .";

                    mainPage.UIBase("valider", message);
                }
                else if (PrefsApp.NomHeureCalculUnitie == "Soir")
                {

                    // DisplayAlert("infos", "Soir", "ok");
                    string fileName = PrefsApp.fileSoirGlycemie;

                    string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(fileName);
                    var list = JsonConvert.DeserializeObject<List<Soir>>(data);

                    PrefsApp.GlycemieMesure = Glycemie.Text;
                    PrefsApp.InsulineNbUnite = Regex.Replace(Insuline.Text, "[^0-9.]", ""); 

                    Soir infosSoir = new Soir();
                    DateTime dateNow = DateTime.Now;
                    infosSoir.DatePriseMesure = DateTime.Now.ToString("dd-MM-yyyy");
                    infosSoir.HeurePriseMesure = DateTime.Now.ToString("HH:mm");
                    infosSoir.Glycemie = PrefsApp.GlycemieMesure;
                    infosSoir.Insuline = PrefsApp.InsulineNbUnite;
                    infosSoir.Quand = PrefsApp.NomMomentRefMesure;

                    list.Add(infosSoir);
                    string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                    DependencyService.Get<Class.IFileReadWrite>().WriteData(fileName, json);


                    //AlertSonore.StopVibrerTéléphone();
                    // AlertSonore.StopAlarmTéléphone();
                    string message = "votre glycemie pour " + PrefsApp.NomHeure + " était de : " + PrefsApp.GlycemieMesure + " vous avez pris : " + PrefsApp.InsulineNbUnite + " Unités d'insuline à : " + Horloge.Text + " .";

                    mainPage.UIBase("valider", message);
                }
                else
                {
                    Console.WriteLine("erreur Record");
                }
            }
        }
    }
}
