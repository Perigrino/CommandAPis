using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetString()
        {
            return new string[] {"Bitch better have my money", "I'd follow you where every you go" };
        }
    }
}