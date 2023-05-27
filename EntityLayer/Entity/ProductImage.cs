using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class ProductImage
    {
        [Key]
        public int ImageID { get; set; }
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [StringLength(255)]
        public string ThumbUrl { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
