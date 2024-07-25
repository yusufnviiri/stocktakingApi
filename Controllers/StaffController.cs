using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stocktakingApi.Models;
using stocktakingApi.Models.Context;

namespace stocktakingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Staff> Staffs { get; set; }=new List<Staff>();
        public IEnumerable<StockItem> StaffStockTaken { get; set; } = new List<StockItem>();
        public StockItem StockItem { get; set; } = new StockItem();
        public Staff Staff { get; set; } = new Staff();
        public StaffController(ApplicationDbContext db)
        {
            _db = db; 
        }
        [HttpPost]
        public async Task<IActionResult> CreateSTockItem(StockItem item)
        {
            await _db.StockItems.AddAsync(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            Staffs = await _db.Staffs.ToListAsync();
            return Ok(Staffs);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            if (id == 0) { return BadRequest(); }
            else
            {
                Staff = await _db.Staffs.FindAsync(id);
                return Ok(Staff);
            }
        }
        [HttpGet]
        [Route("staffcount/{id}")]
        public async Task<IActionResult> CountByStaff(int id)
        {
            Staff = await _db.Staffs.FindAsync(id);

        var  StaffStockTaken = await _db.StaffTasks.ToListAsync();
            return Ok(StaffStockTaken);
        }


    }
}
