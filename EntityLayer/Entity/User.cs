using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(100)]
        //[EmailAddress(ErrorMessage = "Email doğru bir formatda değil")]
        public string Email { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(1)]
        public string Roles { get; set; }
    }
}
