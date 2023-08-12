using System.Collections.Generic;
using CarInfo.Domain.Entities;

namespace CarInfo.MVC.Services
{
    public class BrandService
    {
        // Symulacja bazy danych, można podmienić na rzeczywiste zapytania do bazy
        private static readonly List<BrandModel> Brands = new List<BrandModel>
        {
            new BrandModel { Id = 1, Name = "BMW" },
            new BrandModel { Id = 2, Name = "Mercedes" },
            // ... inne marki
        };

        public List<BrandModel> GetBrandsByYear(int year)
        {
            // Przykładowa logika - zwracanie wszystkich marek
            return Brands;
        }
    }
}

