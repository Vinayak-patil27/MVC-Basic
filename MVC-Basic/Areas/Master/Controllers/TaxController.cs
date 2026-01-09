using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;

namespace MVC_Basic.Areas.Master.Controllers
{
    [Area("Master")]
	public class TaxController : Controller
	{
		private static List<Tax> taxlist = new();
		public IActionResult Index()
		{
			return View(taxlist);
		}

        [HttpGet]
        public IActionResult TaxForm(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return View(new Tax());
                }
                else
                {
                    var rec = taxlist.FirstOrDefault(x => x.TaxId == id);
                    if (rec == null)
                    {
                        return NotFound();
                    }
                    return View(rec);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult TaxForm(Tax tax)
        {
            if (!ModelState.IsValid)
            {
                return View(tax);
            }
            if (tax.TaxId == 0)
            {
                tax.TaxId = taxlist.Count + 1;
                taxlist.Add(tax);
            }
            else
            {
                var rec = taxlist.FirstOrDefault(x => x.TaxId == tax.TaxId);
                if (rec == null)
                    return NotFound();
                rec.Name = tax.Name;
                rec.Value = tax.Value;
                rec.Show = tax.Show;
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var record = taxlist.FirstOrDefault(x => x.TaxId == id);
                if (record == null)
                    return NotFound();

                taxlist.Remove(record);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
