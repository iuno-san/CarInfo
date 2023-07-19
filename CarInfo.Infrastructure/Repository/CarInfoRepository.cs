using CarInfo.Application.CarInfo;
using CarInfo.Domain.Interfaces;
using CarInfo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Infrastructure.Repository
{
    internal class CarInfoRepository : ICarInfoRepository
    {
        private readonly CarInfoDbContext _dbContext;

        public CarInfoRepository(CarInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit() => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.CarInfo carInfo)
        {
            _dbContext.Add(carInfo);
            await _dbContext.SaveChangesAsync();
        }

		/*public Task Create2(Domain.Entities.CarInfo carInfo)
		{
            // #1 Not all paths return value
            // #2 await operator can be only used in async method
            return new Task(async () =>
            {
				_dbContext.Add(carInfo);
				await _dbContext.SaveChangesAsync();
			});
		}*/

		public async Task<IEnumerable<Domain.Entities.CarInfo>> GetAll()
           => await _dbContext.CarsInfos.ToListAsync();

        public async Task<Domain.Entities.CarInfo> GetByEncodedName(string encodedName)
            => await _dbContext.CarsInfos.FirstAsync(c => c.EncodedName == encodedName);
        

        public Task<Domain.Entities.CarInfo> GetByName(string name)
        => _dbContext.CarsInfos.FirstOrDefaultAsync
            (cw => cw.Name.ToLower() == name.ToLower());
    }
}
