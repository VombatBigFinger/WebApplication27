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
            var blog = db.Blog.OrderByDescending(t=>t.DateAdded);
            
            ViewBag.Blog = blog;
            return View();
        }
        [HttpGet]
        public ActionResult WatchBlog(int id)
        {
            var blog = db.Blog.Where(t => t.Id == id);
            ViewBag.Blog = blog;
            return View();
        }
        public ActionResult Search(String Name)
        {
            var blog = db.Blog.Where(t => t.NameBlog == Name);
            ViewBag.Blog = blog;
            return View();
        }

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Red(int id)
        {
            var blog = db.Blog.Where(t => t.Id == id);

            ViewBag.BlogId = id;
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Red(string NameBlog, string TextField, string FullTextField, int id)
        {
            MyBlog r = db.Blog.First(d => d.Id == id);

            r.DateAdded = DateTime.Now;
            if(!string.IsNullOrEmpty(NameBlog))
                r.NameBlog = NameBlog;

            if (!string.IsNullOrEmpty(TextField))
                r.TextField = TextField;

            if (!string.IsNullOrEmpty(FullTextField))
                r.FullTextField = FullTextField;

            db.SaveChanges();
            return Redirect("/Home");
        }

        public ActionResult Add()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(string NameBlog, string TextField, string FullTextField)
        {
            MyBlog newblog = new MyBlog();
            if (!string.IsNullOrEmpty(NameBlog) )
            {
                newblog.NameBlog = NameBlog;
                newblog.TextField = TextField;
                newblog.FullTextField = FullTextField;
                newblog.DateAdded = DateTime.Now;
                db.Blog.Add(newblog);
                db.SaveChanges();
            }
          
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }  
}