using System;
using System.Threading;
using System.Threading.Tasks;

namespace sletat.ru
{
    //public class HomeController : Controller
    //{
    //    //public ActionResult Index() //Deadlock
    //    //{
    //    //    var service = new SomeService();
    //    //    int start = DateTime.Now.Millisecond;
    //    //    service.DoSomeJobAsync().Wait();
    //    //    int stop = DateTime.Now.Millisecond;
    //    //    ViewBag.TotalTime = stop - start;
    //    //    return View();
    //    //}

    //    public async Task<ActionResult> Index()
    //    {
    //        var service = new SomeService();
    //        int start = DateTime.Now.Millisecond;
    //        await service.DoSomeJobAsync();
    //        int stop = DateTime.Now.Millisecond;
    //        ViewBag.TotalTime = stop - start;
    //        return View();
    //    }
    //}

    public class SomeService
    {
        public async Task DoSomeJobAsync()
        {
            Console.WriteLine("2. DoSomeJobAsync {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(200)/*1.ConfigureAwait(false)*/;
            Console.WriteLine("3. DoSomeJobAsync {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
        }
    }
}
