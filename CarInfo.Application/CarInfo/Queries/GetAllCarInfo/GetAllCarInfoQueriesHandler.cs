using AutoMapper;
using CarInfo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo.Queries.GetAllCarInfo
{
    internal class GetAllCarInfoQueriesHandler : IRequestHandler<GetAllCarInfoQueries, IEnumerable<CarInfoDto>>
    {
        private readonly ICarInfoRepository _carInfoRepository;
        private readonly IMapper _mapper;

        public GetAllCarInfoQueriesHandler(ICarInfoRepository carInfoRepository, IMapper mapper)
        {
            _carInfoRepository = carInfoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarInfoDto>> Handle(GetAllCarInfoQueries request, CancellationToken cancellationToken)
        {
            var carInfos = await _carInfoRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarInfoDto>>(carInfos);

            return dtos;
        }
    }
}
