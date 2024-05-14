using Microsoft.AspNetCore.Mvc;
using Ontap_Net104_320.Models;

namespace Ontap_Net104_320.Controllers
{
    public class CartController : Controller
    {
        AppDbContext _context;
        public CartController()
        {
            _context= new AppDbContext();
        }
        public IActionResult Index() // Lấy ra tất cả danh sách sản phẩm trong cart của 1 user đã login
        {
            // Kiểm tra login
            var check = HttpContext.Session.GetString("account"); // username đăng nhập vào nếu có
            if (String.IsNullOrEmpty(check)) return RedirectToAction("Login", "Account");
            else
            {
                var cartItems = _context.CartDetailss.Where(p=>p.Username == check);
                return View(cartItems); // Lưu ý là View này có đối tượng là CartDetails
            }
        }
    }
}
