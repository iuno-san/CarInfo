/*using CarInfo.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

public class VehicleController : Controller
{
    private readonly CarInfoDbContext _context;

    public VehicleController(CarInfoDbContext context)
    {
        _context = context;
    }

    // Action to display the view for creating advertisements with dynamic forms
    public IActionResult Create()
    {
        var brands = _context.Vehicles.Select(v => v.Brand).Distinct().ToList();
        return View(brands);
    }

    // Action to handle AJAX request and return models for a given brand
    [HttpGet]
    public IActionResult GetModels(string brand)
    {
        var models = _context.Vehicles.Where(v => v.Brand == brand).Select(v => v.Model).Distinct().ToList();
        return Json(models);
    }

    // Action to handle AJAX request and return versions for a given brand and model
    [HttpGet]
    public IActionResult GetVersions(string brand, string model)
    {
        var versions = _context.Vehicles.Where(v => v.Brand == brand && v.Model == model).Select(v => v.Version).Distinct().ToList();
        return Json(versions);
    }
}*/
