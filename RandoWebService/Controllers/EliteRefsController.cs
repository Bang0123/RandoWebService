using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RandoWebService.Data;
using RandoWebService.Data.Models;
using RandoWebService.Lib;

namespace RandoWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EliteRefsController : ControllerBase
    {
        private readonly GlobalEliteContext _context;
        private readonly ILogger<EliteRefsController> _logger;
        private readonly IConfiguration _configuration;

        public EliteRefsController(GlobalEliteContext context, ILogger<EliteRefsController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        // GET: api/EliteRefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EliteRef>>> GetEliteRefs([FromQuery] int? pageIndex)
        {
            _logger.LogInformation("GetEliteRefs");
            var query = _context.EliteRefs.OrderBy(x => x.Id).AsNoTracking();
            return await PaginatedList<EliteRef>.CreateAsync(query, pageIndex ?? 1, _configuration);
        }

        // GET: api/EliteRefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EliteRef>> GetEliteRef(int id)
        {
            var eliteRef = await _context.EliteRefs.FindAsync(id);

            if (eliteRef == null)
            {
                return NotFound();
            }

            return eliteRef;
        }

        // PUT: api/EliteRefs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEliteRef(int id, EliteRef eliteRef)
        {
            if (id != eliteRef.Id)
            {
                return BadRequest();
            }

            _context.Entry(eliteRef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EliteRefExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/EliteRefs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EliteRef>> PostEliteRef(EliteRef eliteRef)
        {
            _context.EliteRefs.Add(eliteRef);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEliteRef", new { id = eliteRef.Id }, eliteRef);
        }

        // DELETE: api/EliteRefs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEliteRef(int id)
        {
            var eliteRef = await _context.EliteRefs.FindAsync(id);
            if (eliteRef == null)
            {
                return NotFound();
            }

            _context.EliteRefs.Remove(eliteRef);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EliteRefExists(int id)
        {
            return _context.EliteRefs.Any(e => e.Id == id);
        }
    }
}
