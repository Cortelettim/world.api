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
    public class CidadeController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Cidade>>> Get([FromServices] ApplicationDBContext context)
        {
            var cidades = await context.Cidades.ToListAsync();
            return cidades;
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetById([FromServices] ApplicationDBContext context, int id)
        {
            var cidade = await context.Cidades.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CidadeId == id);
            return cidade;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Cidade>> Post([FromServices] ApplicationDBContext context, [FromBody] Cidade model)
        {
            if (ModelState.IsValid)
            {
                context.Cidades.Add(model);
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
