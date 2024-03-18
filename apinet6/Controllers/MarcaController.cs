using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using apinet6.Models;
using APIPRUEBAS.Models;
using Microsoft.AspNetCore.Cors;

namespace apinet6.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public MarcaController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> GetMarca()
        {
            var lista = await _context.marcas.ToListAsync(); //context que es la base de datos
            //var lista = await _context.Marcas.OrderBy(X => X.SalarioBase).ToListAsync();
            //var lista = await _context.Marcas.OrderByDescending(X => X.SalarioBase).ToListAsync();
            //var lista = await _context.Marcas.OrderByDescending(X => X.SalarioBase).ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Marca>>> GetSingleMarca(int id)
        {
            var miobjeto = await _context.marcas.FirstOrDefaultAsync(ob => ob.id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Marca>> CreateMarca(Marca objeto)
        {

            _context.marcas.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbMarca());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Marca>>> UpdateMarca(Marca objeto)
        {

            var DbObjeto = await _context.marcas.FindAsync(objeto.id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.descripcion = objeto.descripcion;
            DbObjeto.habilitado = objeto.habilitado;

            await _context.SaveChangesAsync();

            return Ok(await _context.marcas.ToListAsync());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Marca>>> DeleteMarca(int id)
        {
            var DbObjeto = await _context.marcas.FirstOrDefaultAsync(Ob => Ob.id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.marcas.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbMarca());
        }


        private async Task<List<Marca>> GetDbMarca()
        {
            return await _context.marcas.ToListAsync();
        }
    }
}
