using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MainModels
    {
        public string SearchText { get; set; }
        public List<Data2.Products> Products { get; set; }
    }
}