using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WEBAPI.Data;
using WEBAPI.Model;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdiniController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdiniController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ordini/{id}/dettagli
        [HttpGet("{id}/dettagli")]
        public async Task<ActionResult<Ordine>> GetOrdineConDettagli(int id)
        {
            var ordine = await _context.Ordini
                .Include(o => o.DettagliOrdine) // Carica i dettagli tramite la relazione
                .FirstOrDefaultAsync(o => o.Id == id);

            if (ordine == null)
            {
                return NotFound();
            }

            return Ok(ordine);
        }

        [HttpGet("GetOrdini")]
        public async Task<ActionResult<IEnumerable<Ordine>>> GetFilterOrdini(
            [FromQuery] string? dataMaggioreCreazione,
            [FromQuery] string? dataMaggioreSpedizione,
            [FromQuery] string? dataMinoreCreazione,
            [FromQuery] string? dataMinoreSpedizione,
            [FromQuery] int? tipo,
            [FromQuery] int? magazzino,
            [FromQuery] int? stato,
            [FromQuery] int? id)
        {
            var query = _context.Ordini.AsQueryable();

            if (id.HasValue)
                query = query.Where(o => o.Id == id.Value);

            // Gestire il formato della data esplicitamente da stringa a DateTime
            if (DateTime.TryParseExact(dataMaggioreCreazione, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDataMagCreazione))
                query = query.Where(o => o.DataInserimento.Date >= parsedDataMagCreazione.Date);

            if (DateTime.TryParseExact(dataMinoreCreazione, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDataMinCreazione))
                query = query.Where(o => o.DataInserimento.Date <= parsedDataMinCreazione.AddDays(1).Date);

            if (DateTime.TryParseExact(dataMaggioreSpedizione, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDataMagSpedizione))
                query = query.Where(o => o.DataSpedizione.HasValue && o.DataSpedizione.Value.Date >= parsedDataMagSpedizione.Date);

            if (DateTime.TryParseExact(dataMinoreSpedizione, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDataMinSpedizione))
                query = query.Where(o => o.DataSpedizione.HasValue && o.DataSpedizione.Value.Date <= parsedDataMinSpedizione.AddDays(1).Date);

            if (tipo.HasValue)
                query = query.Where(o => o.Tipo == tipo);

            if (magazzino.HasValue)
                query = query.Where(o => o.Magazzino == (magazzino));

            if (stato.HasValue)
                query = query.Where(o => o.Stato == stato);

            var ordini = await query.ToListAsync();
            return Ok(ordini);
        }

        // GET: api/ordini
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordine>>> GetOrdini()
        {
            return await _context.Ordini.ToListAsync();
        }

        // GET: api/ordini/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordine>> GetOrdine(int id)
        {
            var ordine = await _context.Ordini.FindAsync(id);
            if (ordine == null)
            {
                return NotFound();
            }
            return ordine;
        }

        //// POST: api/ordini
        //[HttpPost]
        //public async Task<ActionResult<Ordine>> PostOrdine(Ordine ordine)
        //{
        //    _context.Ordini.Add(ordine);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetOrdine), new { id = ordine.Id }, ordine);
        //}

        //// PUT: api/ordini/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrdine(int id, Ordine ordine)
        //{
        //    if (id != ordine.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ordine).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //// DELETE: api/ordini/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrdine(int id)
        //{
        //    var ordine = await _context.Ordini.FindAsync(id);
        //    if (ordine == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Ordini.Remove(ordine);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
