using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Entity
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Adress { get; set; }
        [StringLength(14)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(14)]
        public string Whatsapp { get; set; }
       
        [AllowHtml]
        public string Map { get; set; }
    }
}
