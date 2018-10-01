using DiabeteAssistant.Class;
using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiabeteAssistant
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigurationPage : ContentPage
	{
        ToolBars ToolBars = new ToolBars();
        Tools ToolsLocal = new Tools();

        public ConfigurationPage ()
		{
			InitializeComponent ();
            ToolBars.MenuConfigurationPage(this, this.Navigation);

        }
        protected override void OnAppearing()
        {
            LectureInfos();

        }

        private void LectureInfos()
        {
            try
            {
                string fileName = PrefsApp.fileUserPref;
                string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(fileName);
                var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(data);
                UserInfosObjectStruct infos = (UserInfosObjectStruct)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonObj.ToString(), typeof(UserInfosObjectStruct));
                if (infos.Recorded == "true")
                {
                    prenom.Text = infos.Prenom;
                    nom.Text = infos.Nom;
                    mail.Text = infos.Mail;
                    gsm.Text = infos.Gsm;

                    dateNaissance.Date = ToolsLocal.ConvertDateStringToDate(infos.DateNaissance);
                    nomContact.Text = infos.NomContact;
                    prenomContact.Text = infos.PrenomContact;
                    gsmContact.Text = infos.GsmContact;
                    mailContact.Text = infos.MailContact;

                    heureMatin.Time = ToolsLocal.ConvertTimeStringToTime(infos.HeureMatin);
                    heureMidi.Time = ToolsLocal.ConvertTimeStringToTime(infos.HeureMidi);
                    heureSoir.Time = ToolsLocal.ConvertTimeStringToTime(infos.HeureSoir);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Utlisateur non enregistré. ou erreur:" + err.Message.ToString());
            }
        }


        private void ResetInfos()
        {

            prenom.Text = "";
            nom.Text = "";
            mail.Text = "";
            gsm.Text = "";

            dateNaissance.Date = ToolsLocal.ConvertDateStringToDate("20/07/2018");
            nomContact.Text = "";
            prenomContact.Text = "";
            gsmContact.Text = "";
            mailContact.Text = "";

            heureMatin.Time = ToolsLocal.ConvertTimeStringToTime("00:00");
            heureMidi.Time = ToolsLocal.ConvertTimeStringToTime("00:00");
            heureSoir.Time = ToolsLocal.ConvertTimeStringToTime("00:00");


        }


        private async Task Bp_record_ClickedAsync(object sender, EventArgs e)
        {
            Boolean FormCompleted = true;
            Boolean DateNaissanceCompleted = true;
            Boolean HeureCompleted = true;
            Boolean mailUserOk = true;
            Boolean mailContactOk = true;
            Boolean gsmOk = true;
            Boolean gsmContactOk = true;

            string fileName = PrefsApp.fileUserPref;
            UserInfosObjectStruct UserInfos = new UserInfosObjectStruct();

            if (nom.Text == "")
            {
                FormCompleted = false;
            }
            UserInfos.Nom = nom.Text;
            if (prenom.Text == "")
            {
                FormCompleted = false;
            }
            UserInfos.Prenom = prenom.Text;
            if (mail.Text == "")
            {
                FormCompleted = false;
            }
            UserInfos.Mail = mail.Text;
            if (mail.Text == "")
            {
                FormCompleted = false;
            }
            else
            {
                if (ToolsLocal.ValidMail(UserInfos.Mail) == false)
                {
                    mailUserOk = false;
                }
            }

            UserInfos.Gsm = gsm.Text;
            if (gsm.Text == "")
            {
                FormCompleted = false;
            }
            if (ToolsLocal.ValidPhone(UserInfos.Gsm) == false)
            {
                gsmOk = false;
            }



            if (dateNaissance.Date.ToString("dd/MM/yyyy") == "20/07/2018")
            {
                DateNaissanceCompleted = false;
            }
            UserInfos.DateNaissance = dateNaissance.Date.ToString("dd/MM/yyyy");

            if (nomContact.Text == "")
            {
                FormCompleted = false;
            }
            UserInfos.NomContact = nomContact.Text;
            if (prenomContact.Text == "")
            {
                FormCompleted = false;
            }
            UserInfos.PrenomContact = prenomContact.Text;

            UserInfos.GsmContact = gsmContact.Text;
            if (gsmContact.Text == "")
            {
                FormCompleted = false;
            }
            if (ToolsLocal.ValidPhone(UserInfos.GsmContact) == false)
            {
                gsmContactOk = false;
            }





            UserInfos.MailContact = mailContact.Text;
            if (mailContact.Text == "")
            {
                FormCompleted = false;
            }
            else
            {
                if (ToolsLocal.ValidMail(mailContact.Text) == false)
                {
                    mailContactOk = false;
                }
            }






            if (heureMatin.Time.Hours.ToString() + ":" + heureMatin.Time.Minutes.ToString() == "0:0")
            {
                HeureCompleted = false;
            }
            //   Class.Tools.ConvertTime1Chiffre(heureMatin.Time.Hours)  Class.Tools.ConvertTime1Chiffre(heureMatin.Time.Minutes)
            UserInfos.HeureMatin = ToolsLocal.ConvertTime1Chiffre(heureMatin.Time.Hours).ToString() + ":" + ToolsLocal.ConvertTime1Chiffre(heureMatin.Time.Minutes).ToString();

            if (heureMidi.Time.Hours.ToString() + ":" + heureMidi.Time.Minutes.ToString() == "0:0")
            {
                HeureCompleted = false;
            }
            UserInfos.HeureMidi = ToolsLocal.ConvertTime1Chiffre(heureMidi.Time.Hours).ToString() + ":" + ToolsLocal.ConvertTime1Chiffre(heureMidi.Time.Minutes).ToString();

            if (heureSoir.Time.Hours.ToString() + ":" + heureSoir.Time.Minutes.ToString() == "0:0")
            {
                HeureCompleted = false;
            }
            UserInfos.HeureSoir = ToolsLocal.ConvertTime1Chiffre(heureSoir.Time.Hours).ToString() + ":" + ToolsLocal.ConvertTime1Chiffre(heureSoir.Time.Minutes).ToString();


            if (FormCompleted == true && DateNaissanceCompleted == true && HeureCompleted == true && mailUserOk == true && mailContactOk == true && gsmOk == true && gsmContactOk == true)
            {
                UserInfos.Recorded = "true";
                try
                {
                    string json = JsonConvert.SerializeObject(UserInfos);
                    DependencyService.Get<Class.IFileReadWrite>().WriteData(fileName, json);
                    await DisplayAlert("Info", "Préférences Utilisateur sauvegardé.: ", "ok");
                }
                catch (Exception err)
                {
                    await DisplayAlert("Erreur", "erreur: " + err.Message.ToString(), "ok");

                }

            }
            else
            {
                Boolean DateEtHeure = true;
                if (FormCompleted == false)
                {
                    await DisplayAlert("Erreur", "Tout les champs texte doivent être rempli", "OK");
                }
                else
                {
                    if (mailUserOk == false || mailContactOk == false || gsmOk == false || gsmContactOk == false)
                    {
                        if (mailUserOk == false)
                        {
                            await DisplayAlert("Erreur", "le mail utilisateur est incorrecte", "OK");
                        }
                        if (mailContactOk == false)
                        {
                            await DisplayAlert("Erreur", "le mail de la personne de contact est incorrecte", "OK");
                        }
                        if (gsmOk == false)
                        {
                            await DisplayAlert("Erreur", "le gsm de l'utilisateur est incorrecte", "OK");
                        }

                        if (gsmContactOk == false)
                        {
                            await DisplayAlert("Erreur", "le gsm de la personne de contact est incorrecte", "OK");
                        }
                    }
                    else
                    {
                        if (DateNaissanceCompleted == false)
                        {
                            Boolean answer = await DisplayAlert("Question?", "Est-ce que votre date de naissance est bien le 20/07/2018 ? si c'estnon veuillez changer la date, Merci.", "Oui", "Non");
                            if (answer == false)
                            {
                                DateEtHeure = false;
                            }

                        }
                        if (HeureCompleted == false)
                        {

                            var answer = await DisplayAlert("Question?", "Voici Vos heures de repas: Matin->" + heureMatin.Time.Hours.ToString() + ":" + heureMatin.Time.Minutes.ToString() + ", Midi->" + heureMidi.Time.Hours.ToString() + ":" + heureMidi.Time.Minutes.ToString() + "et soir->" + heureSoir.Time.Hours.ToString() + ":" + heureSoir.Time.Minutes.ToString() + ". Est-ce Correcte ? si non veuillez modifie, merci.", "Oui", "Non");
                            if (answer == false)
                            {
                                DateEtHeure = false;
                            }
                        }
                    }

                }


                if (DateEtHeure == true && FormCompleted == true && mailUserOk == true && mailContactOk == true && gsmOk == true && gsmContactOk == true)
                {
                    UserInfos.Recorded = "true";
                    try
                    {
                        string json = JsonConvert.SerializeObject(UserInfos);
                        DependencyService.Get<Class.IFileReadWrite>().WriteData(fileName, json);
                        await DisplayAlert("Info", "Préférences Utilisateur sauvegardé.: ", "ok");

                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Erreur", "erreur: " + err.Message.ToString(), "ok");

                    }
                }



            }
        }

        private async Task Bp_delete_ClickedAsync(object sender, EventArgs e)
        {
            Boolean answer = await DisplayAlert("Question?", "êtes-vous certain de vouloir effacer cet utilisateur?", "Oui", "Non");
            if (answer == true)
            {
                string fileName = PrefsApp.fileUserPref;
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
                await DisplayAlert("Info", "Utilisateur effacé.: ", "ok");
                ResetInfos();

            }
        }



    }
}