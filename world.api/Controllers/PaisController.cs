using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using world.api.Models;
using world.api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

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
        public async Task<ActionResult<Pais>> GetById([FromServices] ApplicationDBContext context, int id)
        {
            var pais = await context.Paises.AsNoTracking()
                .FirstOrDefaultAsync(x => x.PaisId == id);
            return pais;
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
        public async Task<ActionResult<Pais>> Put([FromBody] Pais model, [FromServices] ApplicationDBContext context, int id)
        {
            if (ModelState.IsValid)
            {

                var pais = await context.Paises.FirstOrDefaultAsync(x => x.PaisId == id);

                if (pais != null)
                {
                    pais.NomePais = model.NomePais;
                    pais.PaisId = model.PaisId;

                    await context.SaveChangesAsync();
                }

                return Ok();
            }
            else
            {
                return BadRequest(ModelState); ;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pais>> Delete(int id, [FromServices] ApplicationDBContext context)
        {
            var pais = await context.Paises.AsNoTracking()
                .FirstOrDefaultAsync(x => x.PaisId == id);

            context.Paises.Remove(pais);
            await context.SaveChangesAsync();
            return pais;
        }
    }
}
