using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web_UI.Controllers
{
    public class CommentController:Controller
    {
        UnitOfWork _uw = new UnitOfWork();

        public void Sil(int id)
        {
            _uw.commentRepository.Delete(id);
        }

        //public ActionResult Update()
        //{

        //}
    }
}