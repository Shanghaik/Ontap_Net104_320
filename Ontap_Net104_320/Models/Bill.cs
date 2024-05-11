namespace Ontap_Net104_320.Models
{
    public class Bill
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Username { get; set; }
        public int Status { get; set; }
        // Thể hiện quan hệ thông qua navigation
        public virtual Account Account { get; set; }    
        public virtual List<BillDetails> Details { get; set; }
    }
}
