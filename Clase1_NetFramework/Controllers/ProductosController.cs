using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Clase1_NetFramework.Models;

namespace Clase1_NetFramework.Controllers
{
    public class ProductosController : Controller
    {
        private string url = "http://localhost:1905/api/products";

        public ActionResult Index()
        {
            List<Product> productos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("products");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Product>>();
                    readTask.Wait();
                    productos = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error de server.");
                }
            }
            return View(productos);

        }
    }
}