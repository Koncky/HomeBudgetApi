using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBudgetApi.Data;
using HomeBudgetApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FeesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET api/fees
        [HttpGet]
        public ActionResult<IEnumerable<Fee>> Get()
        {
            //Include - loading relationship data from another entity
            List<Fee> fees = _context.Fee.Include(x => x.Payments).ToList();

            return fees;
        }

        // GET api/fees/5
        [HttpGet("{id}")]
        public ActionResult<Fee> Get(int id)
        {
            return _context.Fee.Where(f => f.Id == id)?.Include(i => i.Payments).First();
        }

        // POST api/fees
        [HttpPost]
        public ActionResult<Fee> Post([FromBody] Fee fee)
        {
            if(fee == null)
            {
                return BadRequest();
            }

            _context.Add<Fee>(fee);
            _context.SaveChanges();

            return fee;
        }

        // PUT api/fees/5
        [HttpPut("{id}")]
        public ActionResult<Fee> Put(int id, [FromBody] Fee fee)
        {
            if(id != fee.Id)
            {
                return BadRequest();
            }

            _context.Update<Fee>(fee);
            _context.SaveChanges();

            return fee;
        }

        // DELETE api/fees/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Fee feeToRemove = _context.Fee.FirstOrDefault(f => f.Id == id);

            if(feeToRemove != null)
            {
                _context.Remove<Fee>(feeToRemove);
                _context.SaveChanges();
            }
        }
    }
}
