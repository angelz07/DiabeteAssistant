using DiabeteAssistant.Fichiers;
using DiabeteAssistant.Objets;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DiabeteAssistant.Class
{
    public class FindInfos
    {
        public UserInfosObjectStruct FindInfosUser()
        {

            string fileName = PrefsApp.fileUserPref;

            string data = DependencyService.Get<Class.IFileReadWrite>().ReadData(fileName);
            var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(data);

            UserInfosObjectStruct infos = (UserInfosObjectStruct)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonObj.ToString(), typeof(UserInfosObjectStruct));


            return infos;
        }
    }
}
