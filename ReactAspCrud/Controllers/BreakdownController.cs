using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactAspCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakdownController : ControllerBase
    {
        private readonly BreakdownDBContext _breakdownDbContext;

        public BreakdownController(BreakdownDBContext breakdownDBContext)
        {
            _breakdownDbContext = breakdownDBContext;
        }

        [HttpGet]
        [Route("GetBreakdown")]
        public async Task<IEnumerable<Breakdown>> GetBreakdowns()
        {
            return await _breakdownDbContext.Breakdowns.ToListAsync();
        }

        [HttpPost]
        [Route("AddBreakdown")]
        public async Task<Breakdown> AddStudent(Breakdown objBreakdown)
        {
            _breakdownDbContext.Breakdowns.Add(objBreakdown);
            await _breakdownDbContext.SaveChangesAsync();
            return objBreakdown;
        }

        [HttpPatch]
        [Route("UpdateBreakdown/{BreakdownID}")]
        public async Task<Breakdown> UpdateBreakdown(Breakdown objBreakdown)
        {
            _breakdownDbContext.Entry(objBreakdown).State = EntityState.Modified;
            await _breakdownDbContext.SaveChangesAsync();
            return objBreakdown;
        }

        [HttpDelete]
        [Route("DeleteBreakdown/{BreakdownID}")]
        public bool DeleteBreakdown(string BreakdownID)
        {
            bool a = false;
            var breakdown = _breakdownDbContext.Breakdowns.Find(BreakdownID);
            if (breakdown != null)
            {
                a = true;
                _breakdownDbContext.Entry(breakdown).State = EntityState.Deleted;
                _breakdownDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;

        }
    }
}
