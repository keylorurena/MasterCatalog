using MasterCatalog.Models;
using MasterCatalog.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;

namespace MasterCatalog.Service
{
    public static class DataItemsService
    {
        private static string ItemsPath = HostingEnvironment.MapPath($"~/{WebConfigurationManager.AppSettings["DataItemsJsonName"]}");//Path.Combine(Path.GetDirectoryName(typeof(DescriptionSettingsService).Assembly.Location), WebConfigurationManager.AppSettings["DataDescriptionSettingsJsonName"]);
        public static Items GetItems()
        {
            JObject jsonObject = DataFileHelper.GetJsonData(ItemsPath);

            Items items = new Items() { CurrentScope = Convert.ToInt32(jsonObject["CurrentScope"]) };

            items.Data = new List<Drink>();

            foreach(JObject i in jsonObject["Data"])
            {
                switch ((string)i["DrinkType"])
                {
                    case "Beer": items.Data.Add(i.ToObject<Beer>()); break;
                    case "Juice": items.Data.Add(i.ToObject<Juice>()); break;
                    case "Soda": items.Data.Add(i.ToObject<Soda>()); break;
                    default: break;
                }
            }

            return items;
        }

        public static List<Drink> GetDrinks()
        {
            Items items = GetItems();

            return items.Data;
        }

        public static Drink GetDrink(int ID)
        {
            return GetDrinks().Where(d => d.ID == ID).Single();
        }
    }
}