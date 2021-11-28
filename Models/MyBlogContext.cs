
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication27.Models
{
    public class MyBlogContext:DbContext
    {
        public MyBlogContext():base ("MyBlogContext")
        {

        }




        public DbSet<MyBlog> Blog { get; set; }
    }

    public class MyBlogDbIniliazer: DropCreateDatabaseAlways<MyBlogContext>
    {
        protected override void Seed(MyBlogContext db)
        {

            db.Blog.Add(new MyBlog { NameBlog = "Dodomyan", TextField = "I love big cocks", FullTextField="ВВВВВ!!!!    ДОААА", DateAdded =DateTime.Now});
            db.Blog.Add(new MyBlog { NameBlog = "Dodomывyan", TextField = "I love big cыввывыocks", FullTextField="вавав         авыаыва", DateAdded = DateTime.Now });
            base.Seed(db);
        }
    }
}