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
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Estado>>> Get([FromServices] ApplicationDBContext context)
        {
            var estados = await context.Estados.ToListAsync();
            return estados ;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetById([FromServices] ApplicationDBContext context, int id)
        {
            var estado = await context.Estados.AsNoTracking()
                .FirstOrDefaultAsync(x => x.EstadoId == id);
            return estado;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Estado>> Post([FromServices] ApplicationDBContext context, [FromBody] Estado model)
        {
            if (ModelState.IsValid)
            {
                context.Estados.Add(model);
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
        public async Task<ActionResult<Estado>> Put([FromServices] ApplicationDBContext context, int id)
        {
            var estado = await context.Estados.AsNoTracking()
                .FirstOrDefaultAsync(x => x.EstadoId == id);

              context.Estados.Update(estado);
            return estado;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> Delete(int id, [FromServices] ApplicationDBContext context)
        {
            var estado = await context.Estados.AsNoTracking()
                .FirstOrDefaultAsync(x => x.EstadoId == id);

            context.Estados.Remove(estado);
            return estado;
        }
    }
}
