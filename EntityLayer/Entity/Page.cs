using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }
        [StringLength(255)]
        public string PageTitle { get; set; }
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [StringLength(255)]
        public string Thumbrl { get; set; }
        [StringLength(255)]
        public string MetaDescription { get; set; }
        [StringLength(255)]
        public string MetaKey { get; set; }
        
        public string Description { get; set; }
        public DateTime PageDate { get; set; }
        public bool IsActive { get; set; }
        public int CategoryID { get; set; }
        public virtual PageCategory PageCategory { get; set; }
    }
}
