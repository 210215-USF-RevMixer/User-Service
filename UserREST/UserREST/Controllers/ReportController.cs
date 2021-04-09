using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBL;
using UserModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserREST.Controllers
{
    /// <summary>
    /// API for Reports
    /// </summary>
    
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IUserBL _userBL;
        public ReportController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        // GET: api/<ReportController>
        [HttpGet]
        public async Task<IActionResult> GetReportsAsync()
        {
            return Ok(await _userBL.GetAllReportsAsync());
        }

        // GET api/<ReportController>/5
        [HttpGet("{Id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetReportByIdAsync(int Id)
        {
            var report = await _userBL.GetReportByIdAsync(Id);
            if (report == null) return NotFound();
            return Ok(report);
        }

        // POST api/<ReportController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddReportAsync([FromBody] Report report)
        {
            try
            {
                await _userBL.AddReportAsync(report);
                return CreatedAtAction("AddReportAsync", report);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<ReportController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateReportAsync(int Id, [FromBody] Report report)
        {
            try
            {
                await _userBL.UpdateReportAsync(report);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteReportAsync(int Id)
        {
            try
            {
                await _userBL.DeleteReportAsync(await _userBL.GetReportByIdAsync(Id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
