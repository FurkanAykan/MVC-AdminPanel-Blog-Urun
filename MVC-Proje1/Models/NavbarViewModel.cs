using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Proje1.Models
{
    public class NavbarViewModel
    {

        public List<ProductCategory> Products { get; set; }
        public List<Page> Pages { get; set; }

    }
}