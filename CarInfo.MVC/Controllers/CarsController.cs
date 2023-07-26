// Ignore Spelling: MVC

using Microsoft.AspNetCore.Mvc;

namespace CarInfo.MVC.Controllers
{
	public class CarsController : Controller
	{
		public IActionResult Index()
		{
			// Ta akcja wyświetla stronę główną z wyborem marek
			return View();
		}

		public IActionResult Mercedes()
		{
			return View();
		}

		public IActionResult BMW()
		{
			return View();
		}
        public IActionResult Audi()
        {
            return View();
        }

        public IActionResult Citroen()
        {
            return View();
        }
        public IActionResult Fiat()
        {
            return View();
        }

        public IActionResult Ford()
        {
            return View();
        }
        public IActionResult Hyundai()
        {
            return View();
        }

        public IActionResult Mazda()
        {
            return View();
        }
        public IActionResult Opel()
        {
            return View();
        }

        public IActionResult Peugeot()
        {
            return View();
        }
        public IActionResult Renault()
        {
            return View();
        }

        public IActionResult Seat()
        {
            return View();
        }
        public IActionResult Toyota()
        {
            return View();
        }

        public IActionResult Volkswagen()
        {
            return View();
        }
        public IActionResult Volvo()
        {
            return View();
        }

    }
}
