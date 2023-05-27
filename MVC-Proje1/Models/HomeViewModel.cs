using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Proje1.Models
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}