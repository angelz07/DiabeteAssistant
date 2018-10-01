using DiabeteAssistant.Class;
using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiabeteAssistant
{
    public partial class MainPage : ContentPage
    {
        Tools ToolsLocal = new Tools();
        ToolsCheck ToolsCheck = new ToolsCheck();
        Horloges Horloges = new Horloges();
        ConfigurationGlycemie ConfigurationGlycemie = new ConfigurationGlycemie();
        ToolBars ToolBars = new ToolBars();
        MakeStackUIBase MakeStackUIBase = new MakeStackUIBase();
        MakeStackUIMesure MakeStackUIMesure = new MakeStackUIMesure();
        public MainPage()   
        {
            InitializeComponent();

            bool FileMomentExist = ConfigurationGlycemie.TestIfMomentFilesJsonExist();
            if (FileMomentExist == false) {
                DisplayAlert("Erreur", "Les Fichiers de Configuration Moment de Journée n'existe pas veuillez redémarer l'app!", "Ok");
            }

            // Ajout Menu Tool Bar
            ToolBars.MenuMainPage(this, this.Navigation);
        }
        protected override void OnAppearing()
        {
            ToolsCheck.TestIfRecorded();
            if (ToolsCheck.TestIfRecorded() == false)
            {
                this.Navigation.PushAsync(new ConfigurationPage());
            }
            else if (ToolsCheck.TestIfGlycemieRecorded() == false)
            {
                this.Navigation.PushAsync(new ConfGlycemie());
            }
            else
            {
                /* Start App */
                StackMainID.Children.Clear();
                if (PrefsApp.MesureIsActive == true)
                {
                    UIMesure();
                }
                else
                {
                    UIBase("init", "");
                }
            }
        }

        public void UIBase(string arg, string message)
        {
            StackMainID.Children.Clear();

            StackLayout StackUIMain = MakeStackUIBase.StackUIBase(StackMainID, arg, message, this);
            StackMainID.Children.Add(StackUIMain);
        }


        public void UIMesure()
        {
            StackMainID.Children.Clear();
          
            StackLayout StackUIMesure = MakeStackUIMesure.StackUIMesure(this, StackMainID);
            StackMainID.Children.Add(StackUIMesure);
        }

        public void ShowMessage(string Titre, string Message, string TextBoutton) {
            DisplayAlert(Titre, Message, TextBoutton);
        } 
    }
}
