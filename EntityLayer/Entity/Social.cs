using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Social
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string Facebook { get; set; }
        [StringLength(255)]
        public string Instagram { get; set; }
        [StringLength(255)]
        public string Twitter { get; set; }
        [StringLength(255)]
        public string Youtube { get; set; }
        [StringLength(255)]
        public string Linkedin { get; set; }
    }
}
