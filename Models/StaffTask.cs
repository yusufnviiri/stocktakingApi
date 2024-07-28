namespace stocktakingApi.Models
{
    public class StaffTask
    {
        public int StaffTaskId { get; set; }
        public Staff staff { get; set; }
        public int StaffId { get; set; }
        public  StockItem stockItem { get; set; }
        public int StockItemId { get; set; }

    }
}
