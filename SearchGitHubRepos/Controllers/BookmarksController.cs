using SearchGitHubRepos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SearchGitHubRepos.Controllers
{
    public class BookmarksController : Controller
    {
        // GET: Bookmarks
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public JsonResult AddBookmark([FromBody]RepositoryModel rep)
        {
            BookmarksModel myBookmarks = BookmarksModel.Current;
            var success = myBookmarks.AddBookmark(rep);
            return Json(myBookmarks.allRepositories, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetAll()
        {
            BookmarksModel myBookmarks = BookmarksModel.Current;
            return Json(myBookmarks.allRepositories, JsonRequestBehavior.AllowGet);
        }
    }
}