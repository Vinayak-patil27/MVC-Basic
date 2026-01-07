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
        //public IActionResult Insert()
        //{
        //    return View(); 
        //}


        public IActionResult Insert(Bank bank)
        {
            if (!ModelState.IsValid)
                return View(bank);
            banks.Add(new Bank
            {
                BankId = banks.Count + 1,
                Name = bank.Name,
                IFSCCode = bank.IFSCCode,
                Address = bank.Address,
                MICRCode = bank.MICRCode
            });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var bank = banks.Where(x => x.BankId == id).FirstOrDefault();
                return View(bank);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Bank bank)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    banks.RemoveAt(bank.BankId);
                    banks.Add(bank);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(bank);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			var bank = banks.FirstOrDefault(x => x.BankId == id);
			if (bank == null)
				return NotFound();

			banks.Remove(bank);
			return RedirectToAction("Index");
		}

	}
}
