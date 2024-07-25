namespace stocktakingApi.Models
{
    public class StaffTask
    {
        public int StaffTasksId { get; set; }
        public Staff staff { get; set; }
        public  StockItem stockItem { get; set; }

    }
}
