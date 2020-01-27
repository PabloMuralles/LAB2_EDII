using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_arbolB.Controllers
{
 
    public class BebidasController : ControllerBase
    {
        [HttpGet]
        [Route("api/list")]

        public ActionResult<string> List()
        {

            return "";
        }

        [HttpGet]
        [Route("api/element")]

        public ActionResult<string> Element()
        {
            return "";

        }


        [HttpPost]
        [Route("api/insert")]

        public ActionResult Create([FromBody] Nodo Soda)
        {


        }


    }
}