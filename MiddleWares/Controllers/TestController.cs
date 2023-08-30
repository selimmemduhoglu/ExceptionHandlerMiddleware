using Microsoft.AspNetCore.Mvc;
using System;

namespace MiddleWares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {

        [HttpGet]
        public String Get()
        {
            int a = 0;
            int b = 1 / a;

            return "OK";
           
        }
    }
}
