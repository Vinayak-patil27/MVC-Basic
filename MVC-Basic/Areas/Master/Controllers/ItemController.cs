using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace MVC_Basic.Areas.Master.Controllers
{
    [Area("Master")]
    public class ItemController : Controller
    {
        private static List<Item> itemlist = new();
        public IActionResult Index()
        {
            return View(itemlist);
        }

        public IActionResult ItemForm(int? id)
        {
            try
            {
				// if id=0 then Insert
				if (!id.HasValue || id <= 0)
				{
					return View(new Item());
				}

				//if id>0 then edit
				var record = itemlist.FirstOrDefault(x => x.ItemCode == id);
				if (record == null)
				{
					return NotFound();
				}
				return View(record);
			}
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult ItemForm(Item Model)
        {
            try
            {
				if (!ModelState.IsValid)
				{
					return View(Model);
				}

				if (Model.ItemCode == 0)
				{
					Model.ItemCode = itemlist.Count + 1;
					itemlist.Add(Model);
				}
				else
				{
					var existing = itemlist.FirstOrDefault(x => x.ItemCode == Model.ItemCode);
					if (existing == null)
						return NotFound();

					existing.ItemName = Model.ItemName;
					existing.ItemGroupCode = Model.ItemGroupCode;
					existing.ItemCompanyCode = Model.ItemCompanyCode;
					existing.UnitCode = Model.UnitCode;
					existing.MRP = Model.MRP;
					existing.Rate = Model.Rate;
					existing.Barcode = Model.Barcode;
					existing.TaxID = Model.TaxID;
					existing.Description = Model.Description;
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
                var record = itemlist.FirstOrDefault(x => x.ItemCode == id);
                if (record == null)
                    return NotFound();

                itemlist.Remove(record);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
