using MasterCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCatalog.Models
{
    public class Juice : Drink
    {
        public string FruitMade { get; set; }
        public override string Description
        {
            get
            {
                DescriptionSettingsItem item = DescriptionSettingsService.GetDescriptionSettingsItem(DrinkType);

                if (item != null)
                {
                    string result = item.Rule;

                    foreach(string prop in item.RuleList)
                    {
                        var resultPropiedad = typeof(Juice).GetProperty(prop)?.GetValue(this, null);
                        
                        if (resultPropiedad != null)
                        {
                            result = result.Replace($"$[{prop}]", resultPropiedad.ToString());
                        }
                    }

                    return result;
                }
                else return base.Description;
            }
        }

        public override string ExtendedDescription
        {
            get
            {
                DescriptionSettingsItem item = DescriptionSettingsService.GetDescriptionSettingsItem(DrinkType, 2);

                if (item != null)
                {
                    string result = item.Rule;

                    foreach (string prop in item.RuleList)
                    {
                        var resultPropiedad = typeof(Juice).GetProperty(prop)?.GetValue(this, null);

                        if (resultPropiedad != null)
                        {
                            result = result.Replace($"$[{prop}]", resultPropiedad.ToString());
                        }
                    }

                    return result;
                }
                else return base.Description;
            }
        }
        public override string DrinkType => GetType().Name;
    }
}