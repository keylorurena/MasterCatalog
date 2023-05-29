using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCatalog.Models
{
    public class DescriptionSettings : DataJsonBase
    {
        public List<DescriptionSettingsItem> Data { get; set; }
    }
}