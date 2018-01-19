using System;
using System.Diagnostics;
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

            Debug.WriteLine("1. DoSomeJobAsync " + Thread.CurrentThread.ManagedThreadId);

            service.DoSomeJobAsync().Wait();

            Debug.WriteLine("4. DoSomeJobAsync " + Thread.CurrentThread.ManagedThreadId);

            int stop = DateTime.Now.Millisecond;
            ViewBag.TotalTime = stop - start;
            return View();
        }

        //public async Task<ActionResult> Index()
        //{
        //    var service = new SomeService();
        //    int start = DateTime.Now.Millisecond;

        //    Debug.WriteLine("1. DoSomeJobAsync " + Thread.CurrentThread.ManagedThreadId);

        //    await service.DoSomeJobAsync();

        //    Debug.WriteLine("4. DoSomeJobAsync " + Thread.CurrentThread.ManagedThreadId);

        //    int stop = DateTime.Now.Millisecond;
        //    ViewBag.TotalTime = stop - start;
        //    return View();
        //}

        public class SomeService
        {
            public async Task DoSomeJobAsync()
            {
                Debug.WriteLine("2. DoSomeJobAsync " + Thread.CurrentThread.ManagedThreadId);

                await Task.Delay(200)/*1.ConfigureAwait(false)*/;

                Debug.WriteLine("3. DoSomeJobAsync " + Thread.CurrentThread.ManagedThreadId);

                Thread.Sleep(100);
            }
        }

    }
}