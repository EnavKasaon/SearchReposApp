using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchGitHubRepos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SearchGitHubRepos.Models;

namespace SearchGitHubRepos.Controllers
{
    public class RepositoriesController : Controller
    {
        // GET: Repositories
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetRepositories(string term)
        {
            var result = new List<RepositoryModel>();
            if (!string.IsNullOrEmpty(term))
            {
                string html = string.Empty;
                string url = @"https://api.github.com/search/repositories?q=" + term;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.Method = "GET";
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.UserAgent = "request";


                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                JObject json = JObject.Parse(html);
                var items = json["items"].ToList();
                List<RepositoryModel> list = new List<RepositoryModel>();

                foreach (var item in items)
                {
                    var owner = item["owner"];
                    list.Add(new RepositoryModel()
                    {
                        id = item.Value<string>("id"),
                        name = item.Value<string>("name"),
                        avatar = owner.Value<string>("avatar_url")
                    });
                }

                result = list;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
    }
}