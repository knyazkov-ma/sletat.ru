using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = new SomeService();
            int start = DateTime.Now.Millisecond;
            service.DoSomeJobAsync().Wait();
            int stop = DateTime.Now.Millisecond;
            ViewBag.TotalTime = stop - start;
            return View();
        }

        public class SomeService
        {
            public async Task DoSomeJobAsync()
            {
                await Task.Delay(200);
                Thread.Sleep(100);
            }
        }

    }
}