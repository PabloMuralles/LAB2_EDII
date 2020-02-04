using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


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
            
            var peli = Arbol.RetornarDato();
            var json = JsonConvert.SerializeObject(peli);
            return json;

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


        [HttpPost]
        [Route("api/buscar")]

        public ActionResult Encontrar([FromBody] NombreBusqueda NameSoda)
        {
            if (ModelState.IsValid)
            {
                Arbol.Busar(NameSoda.Name);

                return Ok();
            }
            return BadRequest(ModelState);
        }



    }
}