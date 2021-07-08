using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using world.api.Models;
using world.api.Database;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace world.api.Controllers
{
    [Route("api/paises")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Pais>>>  Get([FromServices] ApplicationDBContext context )
        {
            var paises = await context.Paises.ToListAsync();
            return paises;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Pais>> Post([FromServices] ApplicationDBContext context, [FromBody] Pais model)
        {
            if (ModelState.IsValid)
            {
                context.Paises.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
