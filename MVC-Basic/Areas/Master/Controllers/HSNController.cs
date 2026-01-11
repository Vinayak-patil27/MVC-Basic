using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;

namespace MVC_Basic.Areas.Master.Controllers
{
    [Area("Master")]
    public class HSNController : Controller
    {
        private static List<HSN> hsnlist = new();
        public IActionResult Index()
        {
            return View(hsnlist);
        }

        [HttpGet]
        public IActionResult HSNForm(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return View(new HSN());
                }
                else
                {
                    var rec = hsnlist.FirstOrDefault(x => x.HsnId == id);
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
        public IActionResult HSNForm(HSN hsn)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(hsn);
                }
                if (hsn.HsnId == 0)
                {
                    hsn.HsnId = hsnlist.Count + 1;
                    hsnlist.Add(hsn);
                }
                else
                {
                    var rec = hsnlist.FirstOrDefault(x => x.HsnId == hsn.HsnId);
                    if (rec == null)
                        return NotFound();
                    rec.HsnName = hsn.HsnName;
                    rec.TaxId = hsn.TaxId;
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var record = hsnlist.FirstOrDefault(x => x.HsnId == id);
                if (record == null)
                    return NotFound();

                hsnlist.Remove(record);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}