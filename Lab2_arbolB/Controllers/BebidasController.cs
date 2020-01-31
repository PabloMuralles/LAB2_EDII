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
        private static Almacenamiento.ArbolB Arbol = new Almacenamiento.ArbolB();

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

        public ActionResult Create([FromBody] Bebidas Soda)
        {
            if (ModelState.IsValid)
            {
                Arbol.Add(Soda.Name, Soda.flavor, Soda.inventory, Soda.price, Soda.Made);
                
                return Ok();
            }
            return BadRequest(ModelState);
        }




    }
}