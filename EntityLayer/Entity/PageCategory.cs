using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class PageCategory
    {
        public PageCategory()
        {
            Pages = new List<Page>();
        }
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(100)]

        public string CategoryName { get; set; }
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [StringLength(255)]
        public string MetaDescription { get; set; }
        [StringLength(255)]
        public string MetaKey { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
