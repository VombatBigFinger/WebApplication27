using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication27.Models;
namespace WebApplication27.Controllers
{
    public class HomeController : Controller
    {

        MyBlogContext db = new MyBlogContext();



        public ActionResult Index()
        {
            var blog = db.Blog;
            ViewBag.Blog = blog;
            return View();
        }



        [HttpGet]
        public ActionResult Red(int id)
        {
            ViewBag.BlogId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Red(string NameBlog, string TextField, int id)
        {
            MyBlog r = db.Blog.First(d => d.Id == id);
            
            r.DateAdded = DateTime.Now;
            r.NameBlog = NameBlog;
            r.TextField = TextField;
            
            db.SaveChanges();
            return Redirect("/Home");
        }



        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string NameBlog, string TextField)
        {
            MyBlog newblog = new MyBlog();

            newblog.NameBlog = NameBlog;
            newblog.TextField = TextField;
            newblog.DateAdded = DateTime.Now;
            db.Blog.Add(newblog);
            db.SaveChanges();

            return Redirect("/Home");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            MyBlog d = db.Blog.Find(id);
            if(d==null)
            {
                return HttpNotFound();
            }
            return View(d);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MyBlog d = db.Blog.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }
             db.Blog.Remove(d);
             db.SaveChanges(); 
            return Redirect("/Home");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }  
}