using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100,ErrorMessage ="En fazla 100 karakter girilebilir.")]
        public string Title { get; set; }
        [StringLength(255, ErrorMessage = "En fazla 255 karakter girilebilir.")]
        public string Description { get; set; }
        [StringLength(255, ErrorMessage = "En fazla 255 karakter girilebilir.")]
        public string ImageUrl { get; set; }
    }
}
