using System.Collections.Generic;
using System.Web.Http;

namespace StoreApp.Controllers
{
    [Route("api/storage")]
    public class StorageController : ApiController
    {
        private static List<Payload> data = new List<Payload>() { new Payload() { Message = "msg" } };

        [HttpGet]
        public IEnumerable<Payload> Get()
        {
            return data;
        }

        [HttpPost]
        public IEnumerable<Payload> Post([FromBody]Payload p)
        {
            data.Add(p);
            return data;
        }
    }

    public class Payload
    {
        public string Message { get; set; }
    }
}
