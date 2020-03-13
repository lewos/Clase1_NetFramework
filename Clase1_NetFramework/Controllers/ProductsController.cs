using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clase1_NetFramework.Models;

namespace Clase1_NetFramework.Controllers
{
    public class ProductsController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();


        [HttpGet]
        public List<Product> getAll()
        {
            var products = from s in db.Products
                           select s;
            var response = products.ToList();
            return response;
        }

        [HttpGet]
        public Product getById(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return new Product
                {
                    ProductName = "No encontrado"
                };
            }
            return product;
        }

    }
}
