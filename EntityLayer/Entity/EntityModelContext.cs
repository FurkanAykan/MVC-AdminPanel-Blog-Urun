using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class EntityModelContext:DbContext
    {
        public EntityModelContext():base("name=sqlcon")
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<PageCategory> PageCategories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Slider> Sliders { get; set; }


    }
}
