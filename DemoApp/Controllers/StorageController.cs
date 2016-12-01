using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [Route("/[controller]")]
    public class StorageController : Controller
    {
        private static List<string> data = new List<string>() { };
        // GET storage/
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return data;
        }

        // POST storage
        [HttpPost]
        public IEnumerable<string> Post([FromBody]Payload p)
        {
            data.Add(p.Data);
            return data;
        }

        // PUT storage/5
        [HttpPut("{val}")]
        public void Put(string val, [FromBody]string value)
        {
            data.Add(val);
        }

        // DELETE storage/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Payload
    {
        public string Data { get; set; }
    }
}
