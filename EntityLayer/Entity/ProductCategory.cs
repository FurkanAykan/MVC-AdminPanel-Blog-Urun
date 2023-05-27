using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        [Key]
        public int CategoryID { get; set; }
        [StringLength(100)]
        [Required]
        public string CategoryName { get; set; }
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [StringLength(255)]
        public string ThumbUrl { get; set; }
        [StringLength(255)]
        public string MetaDescription { get; set; }
        [StringLength(255)]
        public string MetaKey { get; set; }
        public bool IsAvtive { get; set; }

        public virtual ICollection<Product> Products { get;}
    }
}
