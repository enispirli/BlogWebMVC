using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web_UI.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _uw=new UnitOfWork();
        // GET: Home
      
        public ActionResult Index()
        {
           
            return View(_uw.articleRepository.GetAll());
        }
   
    }
}