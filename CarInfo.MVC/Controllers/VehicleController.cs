using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class VehicleController : Controller
{
    // Dane symulujące listę marek, modeli i wersji pojazdów
    private List<string> brands = new List<string> { "BMW", "Audi", "Mercedes" };
    private Dictionary<string, List<string>> models = new Dictionary<string, List<string>>
    {
        { "BMW", new List<string> { "X5", "X3", "3 Series" } },
        { "Audi", new List<string> { "A3", "A4", "Q5" } },
        { "Mercedes", new List<string> { "C-Class", "E-Class", "GLC" } }
    };
    private Dictionary<string, List<string>> versions = new Dictionary<string, List<string>>
    {
        { "BMW_X5", new List<string> { "xDrive40i", "xDrive30d", "M50i" } },
        { "BMW_X3", new List<string> { "xDrive30i", "xDrive20d", "M40i" } },
        { "BMW_3 Series", new List<string> { "320i", "330i", "M340i" } },
        // Podobnie dla pozostałych marek i modeli
    };

    // Akcja zwracająca listę marek pojazdów
    public IActionResult GetBrands()
    {
        return Json(brands);
    }

    // Akcja zwracająca listę modeli pojazdów dla danej marki
    public IActionResult GetModels(string brand)
    {
        if (models.ContainsKey(brand))
        {
            return Json(models[brand]);
        }
        return NotFound();
    }

    // Akcja zwracająca listę wersji pojazdów dla danej marki i modelu
    public IActionResult GetVersions(string brand, string model)
    {
        string key = $"{brand}_{model}";
        if (versions.ContainsKey(key))
        {
            return Json(versions[key]);
        }
        return NotFound();
    }
}