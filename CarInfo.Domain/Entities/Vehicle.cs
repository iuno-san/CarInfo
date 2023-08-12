using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Domain.Entities
{
    public class BrandModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Dodaj inne właściwości związane z modelem marki
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public BrandModel Brand { get; set; } // Zamiast string? Brand
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
