using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace ClsAppNtier.Client.Controllers;

public class CategoryUnitOfWorkController : Controller
{
    private IUnitofWork _unitOfWork;

    public CategoryUnitOfWorkController(IUnitofWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var res = _unitOfWork.Categories.GetAll();
        return View(res);
    }

    [HttpGet]
    public IActionResult Create()
    {
        FillCategory();
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(Category model)
    {
        FillCategory();
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _unitOfWork.Categories.Add(model);
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var category = _unitOfWork.Categories.GetById(id);
        if (category == null) return NotFound();

        return View(category);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(Category model)
    {
        if (!ModelState.IsValid) return View(model);

        _unitOfWork.Categories.Update(model);
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Delete(int id)
    {
        var category = _unitOfWork.Categories.GetById(id);
        if (category == null) return NotFound();

        _unitOfWork.Categories.Delete(category);
        _unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }

    private void FillCategory()
    {
        var categories = _unitOfWork.Categories.GetAll();
        ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
    }
}
