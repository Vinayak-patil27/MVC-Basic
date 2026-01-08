using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;
using System.Reflection;

namespace MVC_Basic.Areas.Master.Controllers
{
	[Area("Master")]
	public class ItemCompanyController : Controller
	{
		private static List<ItemCompany> companylist = new List<ItemCompany>();
		public IActionResult Index()
		{
			return View(companylist);
		}

		[HttpGet]
		public IActionResult ItemCompanyForm(int? id)
		{
			try
			{
				// if id=0 then Insert
				if (!id.HasValue || id <= 0)
				{
					return View(new ItemCompany());
				}

				//if id>0 then edit
				var record = companylist.FirstOrDefault(x => x.CompanyId == id);
				if (record == null)
				{
					return NotFound();
				}
				return View(record);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ItemCompanyForm(ItemCompany Model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return View(Model);
				}

				if (Model.CompanyId == 0)
				{
					Model.CompanyId = companylist.Count + 1;
					companylist.Add(Model);
				}
				else
				{
					var existing = companylist.FirstOrDefault(x => x.CompanyId == Model.CompanyId);
					if (existing == null)
						return NotFound();

					existing.CompanyName = Model.CompanyName;
					existing.CompanyDescription = Model.CompanyDescription;
				}
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			try
			{
				var record = companylist.FirstOrDefault(x => x.CompanyId == id);
				if (record == null)
					return NotFound();

				companylist.Remove(record);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
