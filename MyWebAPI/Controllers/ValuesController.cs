using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            List<string> products = new List<string>() { "Iphone 6", "Samsung s8", "Nokia 311" };
            return products;
        }

        // GET api/values/5
        public string Get(int id)
        {
            List<string> products = new List<string>() { "Iphone 6", "Samsung s8", "Nokia 311" };
            return products[id];
        }

        // POST api/values
        public List<string> Post([FromBody] string value)
        {
            List<string> products = new List<string>() { "Iphone 6", "Samsung s8", "Nokia 311" };
            products.Add(value);
            return products;
        }

        // PUT api/values/5
        public List<string> Put(int id, [FromBody] string value)
        {
            List<string> products = new List<string>() { "Iphone 6", "Samsung s8", "Nokia 311" };
            products[id] = value;
            return products;
        }

        // DELETE api/values/5
        public List<string> Delete(int id)
        {
            List<string> products = new List<string>() { "Iphone 6", "Samsung s8", "Nokia 311" };
            products.RemoveAt(id);
            return products;
        }
    }
}
