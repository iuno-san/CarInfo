using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo.Queries.GetAllCarInfo
{
    public class GetAllCarInfoQueries : IRequest<IEnumerable<CarInfoDto>>
    {

    }
}
