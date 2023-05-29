using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MasterCatalog.Util
{
    public static class DataFileHelper
    {
        public static T ReadJsonFromFile<T>(string filePath) where T: class
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Data File does not exist.");
            }

            string json = File.ReadAllText(filePath);
            T data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }

        public static JObject GetJsonData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Data File does not exist.");
            }

            string json = File.ReadAllText(filePath);
            return JObject.Parse(json);
        }

        public static void SaveJsonToFile<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(filePath, json);
        }
    }
}