namespace Ontap_Net104_320.Models
{
    public class Cart
    {
        public string Username { get; set; }
        public int Status { get; set; }
        // Quan hệ
        public virtual List<CartDetails> Details { get; set; }  
        public Account Account { get; set; }
    }
}
