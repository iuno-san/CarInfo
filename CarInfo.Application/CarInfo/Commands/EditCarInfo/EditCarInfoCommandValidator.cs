// Ignore Spelling: Validator

using CarInfo.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo.Commands.EditCarInfo
{
    public class EditCarInfoCommandValidator : AbstractValidator<EditCarInfoCommand>
    {
        public EditCarInfoCommandValidator(ICarInfoRepository repository)
        {

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");


            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
