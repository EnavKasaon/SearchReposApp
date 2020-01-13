using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchGitHubRepos.Models
{
    public class BookmarksModel
    {
        public List<RepositoryModel> allRepositories = new List<RepositoryModel>();

        public static BookmarksModel Current
        {
            get
            {
                var bookmarks = HttpContext.Current.Session["bookmarks"] as BookmarksModel;
                if (null == bookmarks)
                {
                    bookmarks = new BookmarksModel();
                    HttpContext.Current.Session["bookmarks"] = bookmarks;
                }
                return bookmarks;
            }
        }

        public Boolean AddBookmark(RepositoryModel r)
        {
            var exists = allRepositories.FirstOrDefault(rep => rep.id.CompareTo(r.id) == 0);
            if (exists == null)
            {
                allRepositories.Add(r);
            }
            return false;
        }
    }
}