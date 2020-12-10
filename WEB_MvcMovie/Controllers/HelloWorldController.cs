using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace WEB_MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //public string Index()
        //{
        //    return "This is my default action...";
        //}

        //public string Welcome(string name, int id = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {id}");
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int id = 10)
        {
            ViewData["Message"] = "hello " + name;
            ViewData["id"] = id;
            return View();
        }
    }
}