// Ignore Spelling: MVC

using CarInfo.Domain.Entities;

namespace CarInfo.MVC.Models
{
    public class CreateVehicleViewModel
    {
        public int SelectedYear { get; set; }
        public IEnumerable<int> AvailableYears { get; set; }
        public IEnumerable<BrandModel> AvailableBrands { get; set; }
        public int SelectedBrandId { get; set; }

        public CreateVehicleViewModel()
        {
            AvailableYears = Enumerable.Range(1900, 2023 - 1900 + 1).Reverse();
        }
    }
}

