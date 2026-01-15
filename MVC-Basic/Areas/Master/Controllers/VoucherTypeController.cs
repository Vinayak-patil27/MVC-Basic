using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;

namespace MVC_Basic.Areas.Master.Controllers
{
    [Area("Master")]
    public class VoucherTypeController : Controller
    {
        private static List<VoucherType> voucherlist = new();
        public IActionResult Index()
        {
            return View(voucherlist);
        }

        [HttpGet]
        public IActionResult VoucherTypeForm(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return View(new VoucherType());
                }
                else
                {
                    var rec = voucherlist.FirstOrDefault(x => x.VoucherId == id);
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
        public IActionResult VoucherTypeForm(VoucherType voucher)
        {
            if (!ModelState.IsValid)
            {
                return View(voucher);
            }
            if (voucher.VoucherId == 0)
            {
                voucher.VoucherId = voucherlist.Count + 1;
                voucherlist.Add(voucher);
            }
            else
            {
                var rec = voucherlist.FirstOrDefault(x => x.VoucherId == voucher.VoucherId);
                if (rec == null)
                    return NotFound();
                rec.VoucherName = voucher.VoucherName;
                rec.VoucherShName = voucher.VoucherShName;
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var record = voucherlist.FirstOrDefault(x => x.VoucherId == id);
                if (record == null)
                    return NotFound();

                voucherlist.Remove(record);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
