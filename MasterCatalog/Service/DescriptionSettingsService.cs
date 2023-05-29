using MasterCatalog.Models;
using MasterCatalog.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;

namespace MasterCatalog.Service
{
    public static class DescriptionSettingsService
    {
        private static string SettingsPath = HostingEnvironment.MapPath($"~/{WebConfigurationManager.AppSettings["DataDescriptionSettingsJsonName"]}");//Path.Combine(Path.GetDirectoryName(typeof(DescriptionSettingsService).Assembly.Location), WebConfigurationManager.AppSettings["DataDescriptionSettingsJsonName"]);

        public static DescriptionSettings GetDescriptionSettings()
        {
            DescriptionSettings descriptionSettings = DataFileHelper.ReadJsonFromFile<DescriptionSettings>(SettingsPath);

            return descriptionSettings;
        }

        public static DescriptionSettingsItem GetDescriptionSettingsItem(string drinkType, int descriptionType = 1)
        {
            DescriptionSettings descriptionSettings = GetDescriptionSettings();

            foreach(DescriptionSettingsItem item in descriptionSettings.Data)
            {
                if(item.DrinkType == drinkType && item.DescriptionType == descriptionType)
                    return item;
            }

            return null;
        }

        public static (bool, string) SaveSettings(DescriptionSettingsItem descriptionSettingsItem)
        {
            DescriptionSettings descriptionSettings = GetDescriptionSettings();

            if (descriptionSettings.Data.Exists(d => d.DescriptionType == descriptionSettingsItem.DescriptionType && d.DrinkType == descriptionSettingsItem.DrinkType && d.ID != descriptionSettingsItem.ID))
                return (false, "A record already exists with same data");
            
            if(descriptionSettingsItem.ID > 0)
            {
                if(descriptionSettings.Data.Exists(i => i.ID == descriptionSettingsItem.ID))
                {
                    DescriptionSettingsItem item = descriptionSettings.Data.Find(i => i.ID == descriptionSettingsItem.ID);

                    item.DrinkType = descriptionSettingsItem.DrinkType;
                    item.DescriptionType = descriptionSettingsItem.DescriptionType;
                    item.Rule = descriptionSettingsItem.Rule;

                } else return (false, "There is not a record for update");
            }
            else
            {
                descriptionSettingsItem.ID = descriptionSettings.CurrentScope + 1;
                descriptionSettings.Data.Add(descriptionSettingsItem);
            }

            DataFileHelper.SaveJsonToFile<DescriptionSettings>(descriptionSettings, SettingsPath);

            return (true, "Record Updated!");
        }
    }
}