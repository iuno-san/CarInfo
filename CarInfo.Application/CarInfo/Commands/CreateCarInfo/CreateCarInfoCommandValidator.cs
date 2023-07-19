// Ignore Spelling: Validator Dto

using CarInfo.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.CarInfo.Commands.CreateCarInfo
{
    public class CreateCarInfoCommandValidator : AbstractValidator<CreateCarInfoCommand>
    {
        public CreateCarInfoCommandValidator(ICarInfoRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Your name is too short")
                .MaximumLength(20).WithMessage("Your name is too long")
                .Custom((value, context) =>
                {
                    var existingCarInfo = repository.GetByName(value).Result;
                    if (existingCarInfo != null)
                    {
                        context.AddFailure($"{value} has already been added to the car library");
                    }
                });


            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");


            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
