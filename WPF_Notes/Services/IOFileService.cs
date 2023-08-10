using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Notes.Models;

namespace WPF_Notes.Services
{
    class IOFileService
    {
        private readonly string PATH;

        public IOFileService(string path)
        {
            PATH = path;
        }

        public BindingList<MakeModel> LoadData()
        {
            if (!File.Exists(PATH))
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<MakeModel>();
            }
            using (StreamReader reader = File.OpenText(PATH))
            {
                string fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<MakeModel>>(fileText);
            }
        }

        public void SaveData(BindingList<MakeModel> makeDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                writer.Write(JsonConvert.SerializeObject(makeDataList));
            }
        }
    }
}
