using DiabeteAssistant.Fichiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DiabeteAssistant.Class
{
    public class Horloges : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool _isRunningMainTimer = false;
        public bool _isRunningMesureTimer = false;

        Tools Tools = new Tools();


        string _HeureMain;
        public string HeureMain
        {
            get { return _HeureMain; }
            set
            {
                if (_HeureMain != value)
                {
                    _HeureMain = value;
                    OnPropertyChanged("HeureMain");
                }
            }
        }

        private void OnPropertyChanged(string Name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

        string _HeureMesure;
        internal bool isAlert;

        public string HeureMesure
        {
            get { return _HeureMesure; }
            set
            {
                if (_HeureMesure != value)
                {
                    _HeureMesure = value;
                    OnPropertyChanged("HeureMesure");
                }
            }
        }

        public string AlertMessage { get; internal set; }

        public void SetTimerMain(Label Timer1, StackLayout StackMainID, MainPage MainPageLocal)
        {
            Binding HeureMainBinding = new Binding
            {
                Source = this,
                Path = "HeureMain"
            };
            Timer1.SetBinding(Label.TextProperty, HeureMainBinding);

            Device.StartTimer(TimeSpan.FromSeconds(1), (Func<bool>)(() =>
            {
                
                this.HeureMain = DateTime.Now.ToString("HH:mm:ss");
               // Console.WriteLine("*******************************************TIMER 1*******************************************   --  " + this.HeureMain);

                string DateNowTimer = DateTime.Now.ToString("HH:mm");
                // Heure = "18:32";
                if (DateNowTimer == PrefsApp.Heure)
                {
                    _isRunningMainTimer = false;
                    PrefsApp.MesureIsActive = true;
                    MainPageLocal.UIMesure();
                    //   StackLayoutRoot.Children.Add(baseStack);


                }


                return _isRunningMainTimer;

            }));


        }

        public void SetTimerMesure(Label Timer2, Label Alert, MainPage MainPageLocal, StackLayout StackMainID)
        {
            Binding HeureMesureBinding = new Binding
            {
                Source = this,
                Path = "HeureMesure"
            };
            Timer2.SetBinding(Label.TextProperty, HeureMesureBinding);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {

                this.HeureMesure = DateTime.Now.ToString("HH:mm:ss");
                string Interval = Tools.RetourIntervalTime(PrefsApp.HeureRefMesure, DateTime.Now.ToString("HH:mm"));
                int IntervalInt = int.Parse(Interval);
                string IntervalHoursMin = Tools.GetTimeString(IntervalInt);

                if (IntervalInt == 1)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    // AlarmeMesure(thisObj, "", IntervalHoursMin);
                    isAlert = true;
                }
                else if (IntervalInt == 30)
                {
                    //AlarmeMesure(thisObj, "", IntervalHoursMin);
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    isAlert = true;
                }
                else if (IntervalInt == 45)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    // AlarmeMesure(thisObj, "", IntervalHoursMin);
                    isAlert = true;
                }
                else if (IntervalInt == 60)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    //AlarmeMesure(thisObj, "", IntervalHoursMin);
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    isAlert = true;
                }
                else if (IntervalInt == 75)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    //AlarmeMesure(thisObj ,"", IntervalHoursMin);
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    isAlert = true;
                }
                else if (IntervalInt == 90)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    //AlarmeMesure(thisObj, "", IntervalHoursMin);
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    isAlert = true;
                }
                else if (IntervalInt == 105)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    //AlarmeMesure(thisObj ,"", IntervalHoursMin);
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    isAlert = true;
                }
                else if (IntervalInt == 120)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    //AlarmeMesure(thisObj ,"", IntervalHoursMin);
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    isAlert = true;
                }
                else if (IntervalInt == 135)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    //AlarmeMesure(thisObj ,"", IntervalHoursMin);
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    isAlert = true;
                }
                else if (IntervalInt == 150)
                {
                    Alert.Text = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    //AlarmeMesure(thisObj, "", IntervalHoursMin);
                    AlertMessage = "Cela fait : " + IntervalHoursMin + " que vous auriez du prendre vos médicaments et faire votre mesure de glycémie.";
                    isAlert = true;
                }
                else if (IntervalInt == 165)
                {
                    Alert.Text = "Vous avez raté la prise de mesure et de médicament. Attention !!!";

                   PrefsApp.MesureIsActive = false;
                    isAlert = false;
                    MainPageLocal.UIBase("rater", "Vous avez raté la prise de mesure et de médicament pour " + PrefsApp.NomHeure + ". Attention !!!");
                    // AlarmeMesure(thisObj , "incomplet", IntervalHoursMin);
                }

              
                return _isRunningMesureTimer;


            });
        }
    }
}
