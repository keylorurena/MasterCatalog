using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCatalog.Models
{
    public class Items : DataJsonBase
    {
        public List<Drink> Data { get; set; }
    }
}