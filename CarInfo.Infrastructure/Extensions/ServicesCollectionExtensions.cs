using CarInfo.Domain.Interfaces;
using CarInfo.Infrastructure.Persistence;
using CarInfo.Infrastructure.Repository;
using CarInfo.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInfo.MVC.Services;

namespace CarInfo.Infrastructure.Extensions
{
    public static class ServicesCollectionExtensions
    {
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<CarInfoDbContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("CarInfo")));

			services.AddDefaultIdentity<IdentityUser>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<CarInfoDbContext>();

			services.AddScoped<CarInfoSeeder>();

			services.AddScoped<ICarInfoRepository, CarInfoRepository>();

			services.AddScoped<BrandService>();
		}
	}
}
