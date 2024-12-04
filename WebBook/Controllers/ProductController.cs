using Book.DataAcess.Data;
using Book.DataAcess.Repository;
using Book.DataAcess.Repository.IRepository;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebBook.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
     public IActionResult Create(Product obj)
        {

            if (ModelState.IsValid){
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
            }
            return View();
                
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == Id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
            }
            return View();

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == Id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Product");

        }
    }
}