﻿using System;
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
    public class EliteDatasController : ControllerBase
    {
        private readonly GlobalEliteContext _context;
        private readonly ILogger<EliteDatasController> _logger;
        private readonly IConfiguration _configuration;

        public EliteDatasController(GlobalEliteContext context, ILogger<EliteDatasController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        // GET: api/EliteDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EliteData>>> GetEliteDatas([FromQuery]int? pageIndex)
        {
            _logger.LogInformation("GetEliteDatas");
            var query = _context.EliteDatas.OrderBy(x => x.Id).AsNoTracking();
            return await PaginatedList<EliteData>.CreateAsync(query, pageIndex ?? 1, _configuration);
        }

        // GET: api/EliteDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EliteData>> GetEliteData(int id)
        {
            var eliteData = await _context.EliteDatas.FindAsync(id);

            if (eliteData == null)
            {
                return NotFound();
            }

            return eliteData;
        }

        // PUT: api/EliteDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEliteData(int id, EliteData eliteData)
        {
            if (id != eliteData.Id)
            {
                return BadRequest();
            }

            _context.Entry(eliteData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EliteDataExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/EliteDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EliteData>> PostEliteData(EliteData eliteData)
        {
            _context.EliteDatas.Add(eliteData);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetEliteData), new { id = eliteData.Id }, eliteData);
        }

        // DELETE: api/EliteDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEliteData(int id)
        {
            var eliteData = await _context.EliteDatas.FindAsync(id);
            if (eliteData == null)
            {
                return NotFound();
            }

            _context.EliteDatas.Remove(eliteData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EliteDataExists(int id)
        {
            return _context.EliteDatas.Any(e => e.Id == id);
        }
    }
}
