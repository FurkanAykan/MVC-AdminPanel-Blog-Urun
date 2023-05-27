using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Product
    {
        public Product()
        {
            ProductImages=new List<ProductImage>();
        }
        [Key]
        public int ProductID { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [StringLength(255)]
        public string ThumbUrl { get; set; }
        [StringLength(255)]
        public string MetaDescription { get; set; }
        [StringLength(255)]
        public string MetaKey { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime ProductDate { get; set; }
        public bool IsActive { get; set; }
        public int CategoryID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
