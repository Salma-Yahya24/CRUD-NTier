using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace ClsAppNtier.Client.Controllers;

public class ProductUnitOfWorkController : Controller
{
    private readonly IUnitofWork _unitOfWork;

    public ProductUnitOfWorkController(IUnitofWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

   
    public IActionResult Index()
    {
        var products = _unitOfWork.Products.GetAll()
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                CategoryName = p.CategoryId.HasValue
                    ? _unitOfWork.Categories.GetById(p.CategoryId.Value)?.CategoryName
                    : "Unknown"
            }).ToList();

        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        FillCategories(); // تحميل قائمة الفئات
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            FillCategories();
            return View(model);
        }

        var category = _unitOfWork.Categories.GetAll()
            .FirstOrDefault(c => c.CategoryName == model.CategoryName);

        if (category == null)
        {
            ModelState.AddModelError("CategoryName", "Selected category does not exist.");
            FillCategories();
            return View(model);
        }

        var product = new Product
        {
            ProductName = model.ProductName,
            Price = model.Price ?? 0,
            CategoryId = category.Id
        };

        _unitOfWork.Products.Add(product);
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var product = _unitOfWork.Products.GetById(id);
        if (product == null) return NotFound();

        var category = product.CategoryId.HasValue
            ? _unitOfWork.Categories.GetById(product.CategoryId.Value)
            : null;

        var model = new ProductViewModel
        {
            Id = product.Id,
            ProductName = product.ProductName,
            Price = product.Price,
            CategoryName = category?.CategoryName
        };

        FillCategories(); 
        return View(model);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            FillCategories();
            return View(model);
        }

        var product = _unitOfWork.Products.GetById(model.Id.Value);
        if (product == null) return NotFound();

        var category = _unitOfWork.Categories.GetAll()
            .FirstOrDefault(c => c.CategoryName == model.CategoryName);

        if (category == null)
        {
            ModelState.AddModelError("CategoryName", "Selected category does not exist.");
            FillCategories();
            return View(model);
        }

        product.ProductName = model.ProductName;
        product.Price = model.Price ?? 0;
        product.CategoryId = category.Id;

        _unitOfWork.Products.Update(product);
        _unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }

    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Delete(int id)
    {
        var product = _unitOfWork.Products.GetById(id);
        if (product == null) return NotFound();

        _unitOfWork.Products.Delete(product);
        _unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }

    
    private void FillCategories()
    {
        var categories = _unitOfWork.Categories.GetAll();
        ViewBag.Categories = new SelectList(categories, "CategoryName", "CategoryName");
    }
}
