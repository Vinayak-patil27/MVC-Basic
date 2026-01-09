using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;
using System.Reflection.Metadata.Ecma335;

namespace MVC_Basic.Areas.Master.Controllers
{
	[Area("Master")]
	public class UnitController : Controller
	{
		private static List<Unit> unitlist = new();
		public IActionResult Index()
		{
			return View(unitlist);
		}

		[HttpGet]
		public IActionResult UnitForm(int? id)
		{
			try
			{
				if (id == null || id == 0)
				{
					return View(new Unit());
				}
				else
				{
					var rec = unitlist.FirstOrDefault(x => x.UnitId == id);
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
		public IActionResult UnitForm(Unit unit)
		{
			if (!ModelState.IsValid)
			{
				return View(unit);
			}
				if (unit.UnitId == 0)
				{
					unit.UnitId = unitlist.Count + 1;
					unitlist.Add(unit);
				}
				else
				{
					var rec = unitlist.FirstOrDefault(x => x.UnitId == unit.UnitId);
					if (rec == null)
						return NotFound();
					rec.UnitName = unit.UnitName;
					rec.IsSubUnit = unit.IsSubUnit;
					rec.SubUnitId = unit.SubUnitId;
				}
			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				var record = unitlist.FirstOrDefault(x => x.UnitId == id);
				if (record == null)
					return NotFound();

				unitlist.Remove(record);
				return RedirectToAction("Index");
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

	}
}
