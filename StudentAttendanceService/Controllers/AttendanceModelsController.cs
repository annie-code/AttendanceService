using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceService.Data;
using StudentAttendanceService.Models;

namespace StudentAttendanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceModelsController : ControllerBase
    {
        private readonly StudentAttendanceServiceContext _context;

        public AttendanceModelsController(StudentAttendanceServiceContext context)
        {
            _context = context;
        }

        // GET: api/AttendanceModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceModel>>> GetAttendanceModel()
        {
            return await _context.AttendanceModel.ToListAsync();
        }

        // GET: api/AttendanceModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceModel>> GetAttendanceModel(int id)
        {
            var attendanceModel = await _context.AttendanceModel.FindAsync(id);

            if (attendanceModel == null)
            {
                return NotFound();
            }

            return attendanceModel;
        }

        // PUT: api/AttendanceModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceModel(int id, AttendanceModel attendanceModel)
        {
            if (id != attendanceModel.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(attendanceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AttendanceModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AttendanceModel>> PostAttendanceModel(AttendanceModel attendanceModel)
        {
            _context.AttendanceModel.Add(attendanceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendanceModel", new { id = attendanceModel.StudentId }, attendanceModel);
        }

        // DELETE: api/AttendanceModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceModel(int id)
        {
            var attendanceModel = await _context.AttendanceModel.FindAsync(id);
            if (attendanceModel == null)
            {
                return NotFound();
            }

            _context.AttendanceModel.Remove(attendanceModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceModelExists(int id)
        {
            return _context.AttendanceModel.Any(e => e.StudentId == id);
        }
    }
}
