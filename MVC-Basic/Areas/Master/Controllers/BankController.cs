using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;
using System.Reflection;

namespace MVC_Basic.Areas.Master.Controllers
{

	[Area("Master")]
	public class BankController : Controller
    {
        private static List<Bank> banks = new List<Bank>();
        public IActionResult Index()
        {
            return View(banks);
        }

        public IActionResult Insert(Bank bank)
        {
			if (!ModelState.IsValid)
				return View(bank);
            banks.Add(new Bank
            {
                BankId = banks.Count+1,
                Name = bank.Name,
                IFSCCode = bank.IFSCCode,
                Address = bank.Address,
                MICRCode = bank.MICRCode
            });
            return RedirectToAction("Index");
		}
    }
}
