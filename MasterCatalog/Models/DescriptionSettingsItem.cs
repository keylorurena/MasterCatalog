using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MasterCatalog.Models
{
    public class DescriptionSettingsItem
    {
        public int ID { get; set; }
        public string DrinkType { get; set; }
        public int DescriptionType { get; set; }
        public string Rule { get; set; }
        public string[] RuleList
        {
            get
            {
                if (!string.IsNullOrEmpty(Rule))
                {
                    try
                    {
                        List<string> valores = new List<string>();
                        string patron = @"\$\[([^\]]+)\]";
                        MatchCollection coincidencias = Regex.Matches(Rule, patron);

                        foreach (Match coincidencia in coincidencias)
                        {
                            valores.Add(coincidencia.Groups[1].Value);
                        }

                        return valores.ToArray();
                    }
                    catch (Exception)
                    {
                        return new string[0];
                    }
                }
                else return new string[0];
            }
        }
    }
}