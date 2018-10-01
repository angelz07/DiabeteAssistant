using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace DiabeteAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Historiques : TabbedPage
    {
        public Historiques ()
        {
            InitializeComponent();
            LectureHistoriqueMatin();
            LectureHistoriqueMidi();
            LectureHistoriqueSoir();
        }

        private void LectureHistoriqueSoir()
        {
            string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(PrefsApp.fileSoirGlycemie);
            Console.WriteLine("Data = " + data);

            var list = JsonConvert.DeserializeObject<List<Soir>>(data);

            List<Entry> ChartsListGlycemieSoir = new List<Entry> { };
            List<Entry> ChartsListInsulineSoir = new List<Entry> { };

            foreach (var item in list)
            {

                /*
                 Modifier cette line en prod
                 */
                string GlycChiffre = Regex.Replace(item.Glycemie, "[^0-9.]", "");
                Entry NewItemGlycemie = new Entry(Single.Parse(GlycChiffre))
                {
                    Label = item.DatePriseMesure,
                    ValueLabel = item.Glycemie,
                    Color = SKColor.Parse("#68B9C0"),

                };
                ChartsListGlycemieSoir.Add(NewItemGlycemie);

                /*
                 Modifier cette line en prod
                 */
                string insuChiffre = Regex.Replace(item.Insuline, "[^0-9.]", "");
                Entry NewItemInsuline = new Entry(Single.Parse(insuChiffre))
                {
                    Label = item.Insuline,
                    ValueLabel = item.Insuline,
                    Color = SKColor.Parse("#266489")
                };
                ChartsListInsulineSoir.Add(NewItemInsuline);




            }
            // Microcharts.Forms.ChartView
            //Microcharts.Chart;
            //   Microcharts.Forms.ChartView.Chart {get; set;}
            SoirGlycmieCharts.Chart = new LineChart() { Entries = ChartsListGlycemieSoir };
            SoirInsulineCharts.Chart = new LineChart() { Entries = ChartsListInsulineSoir };
        }

        private void LectureHistoriqueMidi()
        {
            string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(PrefsApp.fileMidiGlycemie);
            Console.WriteLine("Data = " + data);
            var list = JsonConvert.DeserializeObject<List<Midi>>(data);

            List<Entry> ChartsListGlycemieMidi = new List<Entry> { };
            List<Entry> ChartsListInsulineMidi = new List<Entry> { };

            foreach (var item in list)
            {

                /*
                 Modifier cette line en prod
                 */
                string GlycChiffre = Regex.Replace(item.Glycemie, "[^0-9.]", "");
                Entry NewItemGlycemie = new Entry(Single.Parse(GlycChiffre))
                {
                    Label = item.DatePriseMesure,
                    ValueLabel = item.Glycemie,
                    Color = SKColor.Parse("#68B9C0"),

                };
                ChartsListGlycemieMidi.Add(NewItemGlycemie);

                /*
                 Modifier cette line en prod
                 */
                string insuChiffre = Regex.Replace(item.Insuline, "[^0-9.]", "");
                Entry NewItemInsuline = new Entry(Single.Parse(insuChiffre))
                {
                    Label = item.Insuline,
                    ValueLabel = item.Insuline,
                    Color = SKColor.Parse("#266489")
                };
                ChartsListInsulineMidi.Add(NewItemInsuline);




            }
            // Microcharts.Forms.ChartView
            //Microcharts.Chart;
            //   Microcharts.Forms.ChartView.Chart {get; set;}
            MidiGlycmieCharts.Chart = new LineChart() { Entries = ChartsListGlycemieMidi };
            MidiInsulineCharts.Chart = new LineChart() { Entries = ChartsListInsulineMidi };
        }

        private void LectureHistoriqueMatin()
        {
            string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(PrefsApp.fileMatinGlycemie);
            Console.WriteLine("Data = " + data);
            //infosHistoriqueMatin.Text = data;

            var list = JsonConvert.DeserializeObject<List<Matin>>(data);

            List<Entry> ChartsListGlycemieMatin = new List<Entry> { };
            List<Entry> ChartsListInsulineMatin = new List<Entry> { };

            foreach (var item in list)
            {

                /*
                 Modifier cette line en prod
                 */
                string GlycChiffre = Regex.Replace(item.Glycemie, "[^0-9.]", "");
                Entry NewItemGlycemie = new Entry(Single.Parse(GlycChiffre))
                {
                    Label = item.DatePriseMesure,
                    ValueLabel = item.Glycemie,
                    Color = SKColor.Parse("#68B9C0"),

                };
                ChartsListGlycemieMatin.Add(NewItemGlycemie);

                /*
                 Modifier cette line en prod
                 */
                string insuChiffre = Regex.Replace(item.Insuline, "[^0-9.]", "");
                Entry NewItemInsuline = new Entry(Single.Parse(insuChiffre))
                {
                    Label = item.Insuline,
                    ValueLabel = item.Insuline,
                    Color = SKColor.Parse("#266489")
                };
                ChartsListInsulineMatin.Add(NewItemInsuline);




            }
            // Microcharts.Forms.ChartView
            //Microcharts.Chart;
            //   Microcharts.Forms.ChartView.Chart {get; set;}
            MatinGlycmieCharts.Chart = new LineChart() { Entries = ChartsListGlycemieMatin };
            MatinInsulineCharts.Chart = new LineChart() { Entries = ChartsListInsulineMatin };

        }




    }
}