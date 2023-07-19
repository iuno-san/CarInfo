using AutoMapper;
using CarInfo.Application.ApplicationUser;
using CarInfo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo.Commands.EditCarInfo
{
    public class EditCarInfoCommandHandler : IRequestHandler<EditCarInfoCommand>
    {
        private readonly ICarInfoRepository _carInfoRepository;
        private readonly IUserContext _userContext;

        public EditCarInfoCommandHandler(ICarInfoRepository repository, IUserContext userContext)
        {
            _carInfoRepository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditCarInfoCommand request, CancellationToken cancellationToken)
        {
            var carInfo = await _carInfoRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carInfo.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable) 
            {
                return Unit.Value;
            }

            carInfo.Description = request.Description;
            carInfo.About = request.About;

            carInfo.ContactDetails.Address = request.Address;
            carInfo.ContactDetails.City = request.City;
            carInfo.ContactDetails.PhoneNumber = request.PhoneNumber;

            await _carInfoRepository.Commit();

            return Unit.Value;
        }
    }
}
