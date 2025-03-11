using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Data;
using WEBAPI.Model;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DettagliOrdineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DettagliOrdineController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DettagliOrdine/ByOrdine/{idOrdine}
        [HttpGet("ByOrdine/{idOrdine}")]
        public async Task<ActionResult<IEnumerable<DettaglioOrdine>>> GetDettagliByOrdine(int idOrdine)
        {
            var dettagli = await _context.DettagliOrdine
                                         .Where(d => d.IdOrdine == idOrdine)
                                         .ToListAsync();

            if (dettagli == null || !dettagli.Any())
            {
                return NotFound();
            }

            return Ok(dettagli);
        }

        // GET: api/DettagliOrdine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DettaglioOrdine>>> GetDettagliOrdine()
        {
            return await _context.DettagliOrdine.ToListAsync();
        }

        // GET: api/DettagliOrdine/{idOrdine}/{codArticolo}
        [HttpGet("{idOrdine}/{codArticolo}")]
        public async Task<ActionResult<DettaglioOrdine>> GetDettaglioOrdine(int idOrdine, string codArticolo)
        {
            var dettaglio = await _context.DettagliOrdine
                .FindAsync(idOrdine, codArticolo);

            if (dettaglio == null)
            {
                return NotFound();
            }

            return dettaglio;
        }

        //// POST: api/DettagliOrdine
        //[HttpPost]
        //public async Task<ActionResult<DettaglioOrdine>> PostDettaglioOrdine(DettaglioOrdine dettaglio)
        //{
        //    _context.DettagliOrdine.Add(dettaglio);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetDettaglioOrdine), new { idOrdine = dettaglio.IdOrdine, codArticolo = dettaglio.CodArticolo }, dettaglio);
        //}

        //// PUT: api/DettagliOrdine/{idOrdine}/{codArticolo}
        //[HttpPut("{idOrdine}/{codArticolo}")]
        //public async Task<IActionResult> PutDettaglioOrdine(int idOrdine, string codArticolo, DettaglioOrdine dettaglio)
        //{
        //    if (idOrdine != dettaglio.IdOrdine || codArticolo != dettaglio.CodArticolo)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dettaglio).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DettaglioOrdineExists(idOrdine, codArticolo))
        //        {
        //            return NotFound();
        //        }
        //        throw;
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/DettagliOrdine/{idOrdine}/{codArticolo}
        //[HttpDelete("{idOrdine}/{codArticolo}")]
        //public async Task<IActionResult> DeleteDettaglioOrdine(int idOrdine, string codArticolo)
        //{
        //    var dettaglio = await _context.DettagliOrdine.FindAsync(idOrdine, codArticolo);
        //    if (dettaglio == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DettagliOrdine.Remove(dettaglio);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool DettaglioOrdineExists(int idOrdine, string codArticolo)
        {
            return _context.DettagliOrdine.Any(e => e.IdOrdine == idOrdine && e.CodArticolo == codArticolo);
        }
    }
}