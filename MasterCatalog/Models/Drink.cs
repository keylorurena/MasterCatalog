using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCatalog.Models
{
    public class Drink
    {
        public int ID { get; set; }
        public string ItemLookupCode { get; set; }
        public string Name { get; set; }
        public bool IsCarbonated { get; set; }
        public string IsCarbonatedString => IsCarbonated ? "Cabonated" : "Not Cabonated";
        public string SubDescription1 { get; set; }
        public string SubDescription2 { get; set; }
        public string SubDescription3 { get; set; }
        public string Content { get; set; }
        public virtual string DrinkType => "Drink";
        public virtual string Description
        {
            get
            {
                return $"{Name}, {IsCarbonatedString}";
            }
        }
        public virtual string ExtendedDescription
        {
            get
            {
                return $"{Name}, {IsCarbonatedString}";
            }
        }
    }
}