using System.ComponentModel.DataAnnotations;

namespace Ontap_Net104_320.Models
{
    public class Account
    {
        // Data Anotation Validation được sử dụng để thực hiện validate dữ liệu ngay ở model
        [Required] // Bắt buộc phải có
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Độ dài phải nằm trong khoảng 6-256 kí tự")]
        public string Username { get; set; }
        [Required] // Bắt buộc phải có
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Độ dài phải nằm trong khoảng 6-256 kí tự")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Email không đúng định dạng example@xxx.yyy")]
        public string Email { get; set; }
        [RegularExpression("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$", 
            ErrorMessage = "Số điện thoại phải đúng định dạng xxx-xxx-xxxx")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual List<Bill> Bills { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
