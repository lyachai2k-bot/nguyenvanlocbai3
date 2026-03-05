using Microsoft.AspNetCore.Mvc;
using nguyenvanlocbai3.Models;

namespace nguyenvanlocbai3.Controllers
{
    public class ProductController : Controller
    {
        // Giả lập "cơ sở dữ liệu trong bộ nhớ"
        private static List<Product> _products = new List<Product>
{
new Product { Id = 1, Name = "Chung", Price = 1500, Description =
"Powerful laptop" },
new Product { Id = 2, Name = "Bong", Price = 25, Description =
"Wireless mouse" },
new Product { Id = 3, Name = "Cong", Price = 50, Description =
"Mechanical keyboard" }
};
        public IActionResult Index()
        {
            return View(_products);
        }
        // --- Action Details ---
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }
        // --- GET: Create Form ---
        public IActionResult Create()
        {
            
            return View();
        }
        // --- POST: Xử lý form gửi về ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product newProduct)
        {
            newProduct.Id = _products.Max(p => p.Id) + 1; // Sinh ID mới
            _products.Add(newProduct); // Thêm vào danh sách
            return RedirectToAction(nameof(Index));
        }
        // --- GET: Hiển thị form sửa sản phẩm ---
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }
        // --- POST: Nhận dữ liệu sau khi sửa ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id ==
            updatedProduct.Id);
            if (product == null)
                return NotFound();
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            return RedirectToAction(nameof(Index));
        }
        // --- GET: Hiển thị xác nhận xóa ---
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // --- POST: Xác nhận xóa ---
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
