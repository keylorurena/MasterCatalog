using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCatalog.Models
{
    public class DataJsonBase
    {
        private int currentScope;
        public int CurrentScope
        {
            get => currentScope;
            set => currentScope = value;
        }

        public void AddCurrentScope()
        {
            currentScope++;
        }
    }
}