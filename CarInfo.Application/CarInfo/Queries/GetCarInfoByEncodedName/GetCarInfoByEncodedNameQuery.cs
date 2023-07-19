using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo.Queries.GetCarInfoByEncodedName
{
    public class GetCarInfoByEncodedNameQuery : IRequest<CarInfoDto>
    {
        public string EncodedName { get; set; }

        public GetCarInfoByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
