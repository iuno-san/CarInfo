// Ignore Spelling: Dto

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo
{
    public class CarInfoDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? About { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public string? EncodedName { get; set; } = default!;
        public bool IsEditable { get; set; }
    }
}
