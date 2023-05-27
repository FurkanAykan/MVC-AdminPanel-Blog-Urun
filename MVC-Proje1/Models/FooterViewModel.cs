using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Proje1.Models
{
    public class FooterViewModel
    {
        public Contact Contact { get; set; }
        public List<Page> LastPages { get; set; }
        public Social Socials { get; set; }
    }
}