using EquipmentMainteneanceTracker.Data;
using EquipmentMainteneanceTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMainteneanceTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/equipment - get all equipment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipment = await _context.Equipment.ToListAsync();
            return Ok(equipment);
        }

        // GET api/equipment/1 - get one piece of equipment by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null) return NotFound();
            return Ok(equipment);
        }

        // POST api/equipment - add new equipment
        [HttpPost]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = equipment.Id }, equipment);
        }

        // PUT api/equipment/1 - update existing equipment
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Equipment updated)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null) return NotFound();

            equipment.Name = updated.Name;
            equipment.Location = updated.Location;
            equipment.Status = updated.Status;
            equipment.LastMaintenanceDate = updated.LastMaintenanceDate;
            equipment.NextMaintenanceDate = updated.NextMaintenanceDate;
            equipment.Notes = updated.Notes;

            await _context.SaveChangesAsync();
            return Ok(equipment);
        }

        // DELETE api/equipment/1 - delete equipment
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null) return NotFound();

            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET api/equipment/overdue - get equipment overdue for maintenance
        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdue()
        {
            var overdue = await _context.Equipment
                .Where(e => e.NextMaintenanceDate < DateTime.Now)
                .ToListAsync();
            return Ok(overdue);
        }
    }
}