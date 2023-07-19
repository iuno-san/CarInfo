using AutoMapper;
using CarInfo.Application.ApplicationUser;
using CarInfo.Application.CarInfo.Commands.CreateCarInfo;
using CarInfo.Application.Mapping;
/*using CarInfo.Application.Services;*/
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(CreateCarInfoCommand));

			services.AddScoped(provider => new MapperConfiguration(cfg =>
			{
				var scope = provider.CreateScope();
				var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
				cfg.AddProfile(new CarInfoMappingProfile(userContext));
			}).CreateMapper()
			);

			services.AddValidatorsFromAssemblyContaining<CreateCarInfoCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
