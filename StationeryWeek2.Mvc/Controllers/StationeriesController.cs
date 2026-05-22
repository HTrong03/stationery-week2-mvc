using Microsoft.AspNetCore.Mvc;
using StationeryWeek2.Mvc.Models;
using StationeryWeek2.Mvc.Services;
using StationeryWeek2.Mvc.ViewModels;

namespace StationeryWeek2.Mvc.Controllers;

public class StationeriesController : Controller
{
    private readonly StationeryService _service;

    public StationeriesController(StationeryService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var items = _service.GetAll()
            .Select(x => new StationeryListItemViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Category = x.Category,
                Brand = x.Brand,
                Price = x.Price,
                Quantity = x.Quantity,
                MinStock = x.MinStock
            })
            .ToList();

        return View(items);
    }

    public IActionResult Detail(int id)
    {
        var item = _service.GetById(id);

        if (item == null)
            return NotFound($"Không tìm thấy văn phòng phẩm  có id = {id}");

        var viewModel = new StationeryDetailViewModel
        {
            Id = item.Id,
            Code = item.Code,
            Name = item.Name,
            Category = item.Category,
            Brand = item.Brand,
            Price = item.Price,
            Quantity = item.Quantity,
            MinStock = item.MinStock,
            LastUpdatedAt = item.LastUpdatedAt
        };

        return View(viewModel);
    }

    public IActionResult Stats()
    {
        return View(_service.GetStats());
    }

    public IActionResult Welcome()
    {
        return Content("Welcome to Mini Stationery Store Catalog MVC");
    }

    public IActionResult StationeryJson()
    {
        return Json(_service.GetAll());
    }

    public IActionResult GoToList()
    {
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Force404()
    {
        return NotFound("404 Demo");
    }

    private static StationeryListItemViewModel ToListItemViewModel(Stationery item)
    {
        return new StationeryListItemViewModel
        {
            Id = item.Id,
            Code = item.Code,
            Name = item.Name,
            Category = item.Category,
            Brand = item.Brand,
            Price = item.Price,
            Quantity = item.Quantity,
            MinStock = item.MinStock
        };
    }

    private static StationeryDetailViewModel ToDetailViewModel(Stationery item)
    {
        return new StationeryDetailViewModel
        {
            Id = item.Id,
            Code = item.Code,
            Name = item.Name,
            Category = item.Category,
            Brand = item.Brand,
            Price = item.Price,
            Quantity = item.Quantity,
            MinStock = item.MinStock,
            LastUpdatedAt = item.LastUpdatedAt
        };
    }
}