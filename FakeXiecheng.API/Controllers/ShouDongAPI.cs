using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FakeXiecheng.API.Controllers
{
    [Route("api/shoudongapi")]

    public class ShouDongAPI:Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}

