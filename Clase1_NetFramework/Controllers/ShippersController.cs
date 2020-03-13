using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clase1_NetFramework.Models;

namespace Clase1_NetFramework.Controllers
{
    public class ShippersController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();


        [HttpGet]
        public List<Shipper> getAll()
        {
            var shippers = from s in db.Shippers
                           select s;
            return shippers.ToList();
        }

        [HttpGet]
        public Shipper getById(int id)
        {
            var shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return new Shipper
                {
                    CompanyName = "No encontrado"
                };
            }
            return shipper;
        }


    }
}
