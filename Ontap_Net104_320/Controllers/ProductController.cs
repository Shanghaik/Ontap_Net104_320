using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ontap_Net104_320.Models;

namespace Ontap_Net104_320.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _context;
        public ProductController()
        {
            _context = new AppDbContext();
        }
        // GET: ProductController
        public ActionResult Index() // Lấy ra danh sách Sản phẩm
        {
            var allProducts = _context.Products.ToList();
            return View(allProducts);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(Guid id)
        {
            var product = _context.Products.Find(id); // Find là phương thức chỉ áp dụng cho PK
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            Product fakeData = new Product() // Tạo 1 chút thông tin để điền sẵn sang form create
            {
                Id = Guid.NewGuid(),
                Name = "Sản phẩm mẫu",
                Description = "Tươi ngon bổ rẻ",
                Price = new Random().Next(10000, 1000000), // random giá trị từ 10000 đến 1000000
                Status = 1
            };
            return View(fakeData);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                _context.Products.Add(product); _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Đã có lỗi gì đó khiến chúng tôi không thể thêm được hihi");
            }
        }
        public ActionResult Edit(Guid id)
        {
            // Lấy được thông tin cần sửa để điền lên form trước đã
            var editData = _context.Products.Find(id);
            return View(editData);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                var editData = _context.Products.Find(product.Id); // Tìm ra đối tượng cần sửa
                editData.Name = product.Name; editData.Description = product.Description;
                _context.Products.Update(editData);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Đâu phải lỗi lầm nào cũng sửa được đâu");
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var deleteData = _context.Products.Find(id);
            _context.Products.Remove(deleteData);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // Thêm sản phẩm vào giỏ hàng
        public IActionResult AddToCart(Guid id, int quantity)
        {
            // Check xem đã đăng nhập chưa? nếu chưa thì bắt Login
            var check = HttpContext.Session.GetString("account"); // username đăng nhập vào nếu có
            if (String.IsNullOrEmpty(check)) return RedirectToAction("Login", "Account");
            else
            {
                // Xem trong giỏ hàng ứng với user đó đã có sản phẩm với ad này hay chưa?
                var cartItem = _context.CartDetailss.FirstOrDefault(p => p.ProductId == id 
                && p.Username == check);
                if(cartItem == null)// Sản phẩm chưa hề nằm trong giỏ hàng => Tạo mới 1 cartDetails
                {
                    CartDetails cartDetails = new CartDetails() // Tạo mới 1 Cartdetails theo thông tin đã nhận
                    {
                        Id = Guid.NewGuid(), Username = check, ProductId = id, Quantity = quantity, Status = 1
                    };
                    _context.CartDetailss.Add(cartDetails); _context.SaveChanges(); // thêm vào DB
                }else
                {
                    cartItem.Quantity = cartItem.Quantity + quantity; // Cộng đồn số lượng (Chưa check quá tổng sp trong kho)
                    _context.CartDetailss.Update(cartItem); _context.SaveChanges();
                }
                return RedirectToAction("Index", "Product"); // Quay lại trang danh sách SP
            }
        }

    }
}
