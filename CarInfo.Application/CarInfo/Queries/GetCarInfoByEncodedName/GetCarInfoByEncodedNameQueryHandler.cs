using AutoMapper;
using CarInfo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo.Queries.GetCarInfoByEncodedName
{
    public class GetCarInfoByEncodedNameQueryHandler : IRequestHandler<GetCarInfoByEncodedNameQuery, CarInfoDto>
    {
        private readonly ICarInfoRepository _carInfoRepository;
        private readonly IMapper _mapper;

        public GetCarInfoByEncodedNameQueryHandler(ICarInfoRepository carInfoRepository, IMapper mapper)
        {
            _carInfoRepository = carInfoRepository;
            _mapper = mapper;
        }

        public async Task<CarInfoDto> Handle(GetCarInfoByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carInfo = await _carInfoRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<CarInfoDto>(carInfo);

            return dto;
        }
    }
}
