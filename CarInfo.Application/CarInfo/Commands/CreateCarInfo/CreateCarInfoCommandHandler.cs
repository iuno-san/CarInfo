using AutoMapper;
using CarInfo.Application.ApplicationUser;
using CarInfo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo.Commands.CreateCarInfo
{
    public class CreateCarInfoCommandHandler : IRequestHandler<CreateCarInfoCommand>
    {
        private readonly ICarInfoRepository _carInfoRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarInfoCommandHandler(ICarInfoRepository carInfoRepository, IMapper mapper, IUserContext userContext)
        {
            _carInfoRepository = carInfoRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateCarInfoCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if(currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }

            var carInfo = _mapper.Map<Domain.Entities.CarInfo>(request);
			carInfo.EncodeName();

			carInfo.CreatedById = currentUser.Id;

            await _carInfoRepository.Create(carInfo);

            return Unit.Value;
        }
    }
}
