namespace Ontap_Net104_320.Models
{
    public class BillDetails// Chứa thông tin về 1 sản phẩm trong hóa đơn có gì
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string BillId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Giá tại thời điểm mua/bán
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
