using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Web_UI.Controllers
{
    public class ArticleController : Controller
    {
        UnitOfWork _uw=new UnitOfWork();
        // GET: Article
        public ActionResult Index()
        {
            return View(_uw.articleRepository.OrderByDate());
        }
        [HttpGet]
        public ActionResult NewArticle()
        {
            ViewBag.Categories = _uw.categoryRepository.GetAll();
            ViewBag.Tags = _uw.tagRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult NewArticle(string Title, int Category,string Content)
        {
            string Tags = Request.Form["Tags[]"];
            List<Tag> tags = _uw.tagRepository.GetTags(Tags);
            Article article = new Article();
            article.UserID = (int)Session["UserID"];
            article.Title = Title;
            article.CatergoryID = Category;
            article.GetArticleTags =tags ;
            article.ArticleContent = Content;
            _uw.articleRepository.Add(article);
            return RedirectToAction("Index");
        }

        public void Sil(int id)
        {
            _uw.articleRepository.Delete(id);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Categories = _uw.categoryRepository.GetAll();
            ViewBag.Tags = _uw.tagRepository.GetAll();
            Article article = new Article();
            article = _uw.articleRepository.GetById(id);
           
            return View(article);
        }

        [HttpPost]
        public ActionResult Update(int id,string Title,int Category,string Content)
        {
            string Tags = Request.Form["Tags[]"];
            List<Tag> tags = _uw.tagRepository.GetTags(Tags);
            Article article = new Article();
            article = _uw.articleRepository.GetById(id);
            article.Title = Title;
            article.CatergoryID = Category;
            article.GetArticleTags.Clear();
            article.GetArticleTags = tags;
            article.ArticleContent = Content;
            _uw.articleRepository.Update(article);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Article article = new Article();
            article = _uw.articleRepository.GetById(id);
            return View(article);
        }
        [HttpPost]
        public ActionResult Detail(int id,string Content)
        {
            Comment comment = new Comment();
            comment.ArticleID = id;
            comment.UserID = (int)Session["UserID"];
            comment.CommentContent = Content;
            _uw.commentRepository.Add(comment);
            return RedirectToAction("Detail");

        }
    }
}