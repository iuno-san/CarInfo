using AutoMapper;
using CarInfo.Application.CarInfo;
using CarInfo.Application.CarInfo.Commands.CreateCarInfo;
using CarInfo.Application.CarInfo.Commands.EditCarInfo;
using CarInfo.Application.CarInfo.Queries.GetAllCarInfo;
using CarInfo.Application.CarInfo.Queries.GetCarInfoByEncodedName;
using CarInfo.MVC.Extensions;
using CarInfo.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace CarInfo
{
    public class CarInfoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CarInfoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var carInfo = await _mediator.Send(new GetAllCarInfoQueries());
            return View(carInfo);
        }

        [Route("CarInfo/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarInfoByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("CarInfo/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarInfoByEncodedNameQuery(encodedName));

            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditCarInfoCommand model = _mapper.Map<EditCarInfoCommand>(dto);

            return View(model);
        }

        [HttpPost]
		[Route("CarInfo/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarInfoCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Owner")]
        public IActionResult Create()
        {
            return View();

            /*if(User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity"});
            }*/
        }


        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create(CreateCarInfoCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }

            /*await _mediator.Send(command);*/

            this.SetNotification("success", $"Created car: {command.Name}");

            return RedirectToAction(nameof(Index));
        }
    }
}
