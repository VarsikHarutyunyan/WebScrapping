using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebScrapping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {

        [HttpGet]
        public async Task<string> Get()
        {
            string xmlData = await Scrapping.GetData();
            return xmlData;
        }
    }
}
