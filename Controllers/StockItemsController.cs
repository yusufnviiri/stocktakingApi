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
        public async Task<IActionResult> CreateStockItem(StockItem item)
        {
            await _db.StockItems.AddAsync(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        [HttpPost("setCount")]
        public async Task<IActionResult> SetCount(StockItem item)
        {
          var itemInDb =  await _db.StockItems.FindAsync(item.StockItemId);
            itemInDb.StockAmount = item.StockAmount;
            await _db.SaveChangesAsync();
            return Ok(item);
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
        [HttpPost]
        [Route("updatestock")]
        public async Task<IActionResult> UpdateStock(StockTaken stockTaken)
        {
            Staff staff = await _db.Staffs.FindAsync(stockTaken.StaffId);
            StaffTask staffTask = new StaffTask();
            StockItems = await _db.StockItems.Where(k=>k.Name==stockTaken.itemName).ToListAsync();
            StockItem stockItem =StockItems.FirstOrDefault();
            StockItem stockItemInDb = await _db.StockItems.FindAsync(stockItem.StockItemId);
            stockItemInDb.StockAmount = stockItemInDb.StockAmount+ stockTaken.stockAmount;
            await _db.SaveChangesAsync();
            staffTask.staff=staff;
            staffTask.stockItem = stockItemInDb;
            await _db.StaffTasks.AddAsync(staffTask);
            await _db.SaveChangesAsync();
            return Ok(stockItem);

        }
    }
}
