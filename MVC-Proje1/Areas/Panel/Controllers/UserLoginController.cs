using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;

namespace MVC_Proje1.Areas.Panel.Controllers
{
    public class UserLoginController : Controller
    {
        EntityModelContext db = new EntityModelContext();

        public ActionResult Login()
        {
            return View(new User()); // boş kullanıcı yolladık

        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            #region güvensiz şifreleme sql sorgusu yazılabilir
            //WebLibrary.SqlData d = new WebLibrary.SqlData();
            //string passHash= WebLibrary.CryptoClass.ToSHA1Hash(u.Password);
            //DataRow druser = d.GetDataRow("select * from Users Where Email='" + u.Email + "' and Password='"+passHash+"'");
            //var user = new User();
            #endregion

            string formpassword = WebLibrary.CryptoClass.ToSHA1Hash(u.Password); // şifreyi database ye şifreli kayıt ettik
            //var user = db.Users.Where(x => x.Email == u.Email && x.Password == u.Password).FirstOrDefault();
            var user = db.Users.ToList().Where(x => x.Email == u.Email && x.Password == formpassword).FirstOrDefault();
            //user = new User() { Email="ayknfrkn@gmail.com",UserName="aaadfasfa"};
            if (user != null) // boş geğilse 
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);

                HttpCookie cerez = new HttpCookie("user");
                cerez.Expires = DateTime.Now.AddDays(2); // bu çerez 2 gün geçerli dedik
                cerez.Value = user.UserID.ToString();
                Response.Cookies.Add(cerez);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.hata = "Kulanıcı adı veya şifre hatalı";
            }
            return View(u);

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult SendPassword() // şifremi unuttum da mail yollama 
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendPassword(string email) // şifremi unuttum da mail yollama 
        {
            var user = db.Users.Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                var password = WebLibrary.StringClass.RandomString(8);
                user.Password = WebLibrary.CryptoClass.ToSHA1Hash(password);
                db.SaveChanges();
                StringBuilder sb = new StringBuilder();
                sb.Append(password);
                MailMessage o = new MailMessage("test@catakbahce.com", "ayknfrkn@gmail.com", "Yeni Şifre", sb.ToString());
                NetworkCredential netCred = new NetworkCredential("test@catakbahce.com", "A147258a*");
                SmtpClient smtpobj = new SmtpClient("rd-prime-win.guzelhosting.com", 587);
                smtpobj.EnableSsl = false;
                smtpobj.Credentials = netCred;
                smtpobj.Send(o);
            }
            return View();
        }
    }
}