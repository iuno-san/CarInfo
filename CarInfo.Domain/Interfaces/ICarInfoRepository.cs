using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Domain.Interfaces
{
    public interface ICarInfoRepository
    {
        Task Create(Domain.Entities.CarInfo carInfo);
        Task<Domain.Entities.CarInfo?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.CarInfo>> GetAll();
        Task<Domain.Entities.CarInfo> GetByEncodedName(string encodedName);
        Task<List<string>> GetBrandsAsync();
        Task<List<string>> GetModelsAsync(string brand);
        Task<List<string>> GetVersionsAsync(string brand, string model);
        Task Commit();
    }
}
