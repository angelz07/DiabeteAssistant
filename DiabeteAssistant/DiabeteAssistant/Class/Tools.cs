using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace DiabeteAssistant.Class
{
    public class Tools
    {
        public DateTime ConvertDateStringToDate(string data)
        {
            string format = "dd/MM/yyyy";
            DateTime dateTime = DateTime.ParseExact(data, format, CultureInfo.InvariantCulture);

            return dateTime;
        }

        public TimeSpan ConvertTimeStringToTime(string data)
        {
            var dateTimeToConvert = DateTime.ParseExact(data, "H:mm", null, System.Globalization.DateTimeStyles.None);

            TimeSpan timeConvert = new TimeSpan(dateTimeToConvert.Hour, dateTimeToConvert.Minute, 00);

            return timeConvert;
        }

        public bool ValidMail(string mail_address)
        {
            Regex myRegex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.IgnoreCase);
            return myRegex.IsMatch(mail_address);
        }

        public bool ValidPhone(string phoneNumber)
        {//@"^\\+[0-9][0-9][0-9]( [0-9][0-9])+$"
            Regex myRegex = new Regex("^[+/ 0-9 -]+", RegexOptions.IgnoreCase);
            return myRegex.IsMatch(phoneNumber);
        }

        public string ConvertTime1Chiffre(int data)
        {
            string retour = "";
            if (data < 10)
            {
                retour = "0" + data;
            }
            else
            {
                retour = data.ToString();
            }

            return retour;
        }


        public string MomentJourneeMesure(DateTime Matin, DateTime Midi, DateTime Soir, DateTime Maintenant)
        {
            string Retour = "";
           
            if (Matin <= Maintenant && Midi > Maintenant)
            {
                Retour = "midi";
            }

            else if (Midi <= Maintenant && Soir > Maintenant)
            {
                Retour = "soir";
            }

            else
            {
                Retour = "matin";
            }
            return Retour;

        }

        public string RetourIntervalTime(string TimeRef, string TimeNow)
        {
            string IntervalTemps = "";

            TimeSpan RefTime = ConvertTimeStringToTime(TimeRef);
            TimeSpan NowTime = ConvertTimeStringToTime(TimeNow);

            TimeSpan diffTemps = NowTime - RefTime;
            IntervalTemps = string.Format("{0} ", diffTemps.TotalMinutes.ToString());

            return IntervalTemps;
        }

        public string GetTimeString(int DurationInMinute)
        {
            TimeSpan timeSpan = TimeSpan.FromMinutes(DurationInMinute);

            if (timeSpan.Hours == 1 && timeSpan.Minutes == 1)
                return timeSpan.Hours + " Heure et " + timeSpan.Minutes + " Minutes";
            else if (timeSpan.Hours > 1 && timeSpan.Minutes > 1)
                return timeSpan.Hours + " Heures et " + timeSpan.Minutes + " Minutes";
            else if (timeSpan.Hours > 1 && timeSpan.Minutes < 1)
                return timeSpan.Hours + " Heures";
            else if (timeSpan.Hours < 1 && timeSpan.Minutes > 1)
                return timeSpan.Minutes + " Minutes";
            else if (timeSpan.Hours == 1 && timeSpan.Minutes > 1)
                return timeSpan.Hours + " Heure et " + timeSpan.Minutes + " Minutes";
            else if (timeSpan.Hours == 1 && timeSpan.Minutes == 0)
                return timeSpan.Hours + " Heure";
            else if (timeSpan.Hours == 0 && timeSpan.Minutes == 1)
                return timeSpan.Minutes + " Minute";
            else
                return timeSpan.Hours + " Heures et " + timeSpan.Minutes + " Minutes";
        }
    }
}
