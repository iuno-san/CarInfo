using CarInfo.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Infrastructure.Seeders
{
    public class CarInfoSeeder
    {
        private readonly CarInfoDbContext  _dbcontext;
        public CarInfoSeeder(CarInfoDbContext dbContext) 
        {
            _dbcontext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbcontext.Database.CanConnectAsync())
            {
                if(!_dbcontext.CarsInfos.Any())
                {
                    var Bmw_3 = new Domain.Entities.CarInfo()
                    {
                        Name = "Bmw e46",
                        Description = "Beautifull like new bmw e46 from 2002 year",
                        About = "Sprzedam BMW E46 disel autko śmiga Felgi aluminiowe odpala bezproblemowo",
                        ContactDetails = new()
                        {
                            PhoneNumber = "506219780",
                            City = "Kielce",
                            Address = "Widuchowska 88"
                        }
                    };
                    Bmw_3.EncodeName();

                    _dbcontext.CarsInfos.Add(Bmw_3);
                    await _dbcontext.SaveChangesAsync();
                }
            }
        }
    }
}
