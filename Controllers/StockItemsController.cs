using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stocktakingApi.Dtos;
using stocktakingApi.Models;
using stocktakingApi.Models.Context;

namespace stocktakingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockItemsController : ControllerBase
    {
        public IEnumerable<StockItem> StaffStockTaken { get; set; } = new List<StockItem>();
        public IEnumerable<StockItem> StockItems { get; set;} = new List<StockItem>();
        private readonly ApplicationDbContext _db;
        public Staff Staff { get; set; } = new Staff();
        public StockItemsController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStaff(Staff staff)
        {
            await _db.Staffs.AddAsync(staff);
            await _db.SaveChangesAsync();
            return Ok(staff);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStockItems()
        {
            StockItems = await _db.StockItems.ToListAsync();
            return Ok(StockItems);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStockItem(int id)
        {
            if (id == 0) { return BadRequest(); }
            else
            {
                StockItem item = await _db.StockItems.FindAsync(id);
                return Ok(item);
            }
        }
        [Route("updatestock")]
        public async Task<IActionResult> UpdateStock(StockTaken stockTaken)
        {
            StockItems = await _db.StockItems.Where(k=>k.Name==stockTaken.itemName).ToListAsync();
            StockItem stockItem =StockItems.FirstOrDefault();
            stockItem.StaffId= stockTaken.StaffId;
            stockItem.StockAmount = stockItem.StockAmount;
            await _db.SaveChangesAsync();
            return Ok(stockItem);

        }
    }
}
