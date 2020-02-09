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
   

        [HttpPost]
        [Route("api/insert")]

        public ActionResult Create([FromBody] Bebidas Soda)
        {
            if (ModelState.IsValid)
            {               
              Almacenamiento.ArbolB.Instance.Add(Soda.Name, Soda.flavor, Soda.inventory, Soda.price, Soda.Made);
                
                return Ok();
            }
            return BadRequest(ModelState);
        }


        [HttpGet]
        [Route("api/buscar/{nombre}")]
        public ActionResult Buscar(string nombre)
        {
            if (ModelState.IsValid)
            {
                Bebidas bebida = Almacenamiento.ArbolB.Instance.Buscar(nombre);
                if (bebida != null)
                    return Ok(bebida);
                return NotFound();
            }
            return BadRequest(ModelState);
        }




        [HttpGet]
        [Route("api/registro")]
        public ActionResult<string> Registro()
        {
           
            
                
                var json = JsonConvert.SerializeObject(Almacenamiento.ArbolB.Instance.IngresarRetorno());
                return json;
            
             
        }






    }
}