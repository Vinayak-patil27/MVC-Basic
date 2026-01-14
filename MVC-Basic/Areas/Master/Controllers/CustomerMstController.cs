using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;

namespace MVC_Basic.Areas.Master.Controllers
{
    [Area("Master")]
    public class CustomerMstController : Controller
    {
        private static List<CustMst> custlist = new();
        public IActionResult Index()
        {
            return View(custlist);
        }

        public IActionResult CombForm(int? id)
        {
            try
            {
                // if id=0 then Insert
                if (!id.HasValue || id <= 0)
                {
                    return View(new CustMst());
                }

                //if id>0 then edit
                var record = custlist.FirstOrDefault(x => x.CombId == id);
                if (record == null)
                {
                    return NotFound();
                }
                return View(record);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CombForm(CustMst Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Model);
                }

                if (Model.CombId == 0)
                {
                    Model.CombId = custlist.Count + 1;
                    custlist.Add(Model);
                }
                else
                {
                    var existing = custlist.FirstOrDefault(x => x.CombId == Model.CombId);
                    if (existing == null)
                        return NotFound();

                    existing.CombName = Model.CombName;
                    existing.Address = Model.Address;
                    existing.Mobno = Model.Mobno;
                    existing.Email = Model.Email;
                    existing.DOB = Model.DOB;
                    existing.GstNo = Model.GstNo;
                    existing.AddharNo = Model.AddharNo;
                    existing.Comm = Model.Comm;
                    existing.Phone = Model.Phone;
                    existing.iscust = Model.iscust;
                    existing.isDealer = Model.isDealer;
                    existing.isemployee = Model.isemployee;
                    existing.issupplier = Model.issupplier;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var record = custlist.FirstOrDefault(x => x.CombId == id);
                if (record == null)
                    return NotFound();

                custlist.Remove(record);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}