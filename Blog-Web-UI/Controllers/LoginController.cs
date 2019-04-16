using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web_UI.Controllers
{
    public class LoginController : Controller
    {

        UnitOfWork _uw=new UnitOfWork();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email,string Password)
        {
         User user= _uw.userRepository.Login(Email, Password);
            if (user != null)
            {
                Session["UserID"] = user.Id;
                Session["Email"] =user.Email;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string Name, string SurName,string Email,string Password,string Password2)
        {
            if (Password.Equals(Password2))
            {
                User user = new User();
                user.Name = Name;
                user.SurName = SurName;
                user.Email = Email;
                user.Password = Password;
                _uw.userRepository.Add(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["Email"] = null;
            Session["UserID"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}