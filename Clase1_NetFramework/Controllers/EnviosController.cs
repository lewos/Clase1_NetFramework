using Clase1_NetFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Clase1_NetFramework.Controllers
{
    public class EnviosController : Controller
    {
        private string url = "http://localhost:1905/api/shipppers";

        public ActionResult Index()
        {
            List<Shipper> envios = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("shippers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Shipper>>();
                    readTask.Wait();
                    envios = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error de server.");
                }
            }
            return View(envios);

        }

    }
}