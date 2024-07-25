using System.ComponentModel.DataAnnotations;

namespace stocktakingApi.Models
{
    public class StockItem
    {

        public int StockItemId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double StockAmount { get; set; }

    }
}
