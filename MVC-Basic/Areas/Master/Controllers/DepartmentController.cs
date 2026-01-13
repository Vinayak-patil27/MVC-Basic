using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;

namespace MVC_Basic.Areas.Master.Controllers
{
	[Area("Master")]
	public class DepartmentController : Controller
	{
		private static List<DeptMst> deptlist = new();
		public IActionResult Index()
		{
			return View(deptlist);
		}

		[HttpGet]
		public IActionResult DeptForm(int? id)
		{
			try
			{
				if (id == null || id == 0)
				{
					return View(new DeptMst());
				}
				else
				{
					var rec = deptlist.FirstOrDefault(x => x.DeptCode == id);
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
		public IActionResult DeptForm(DeptMst dept)
		{
			if (!ModelState.IsValid)
			{
				return View(dept);
			}
			if (dept.DeptCode == 0)
			{
				dept.DeptCode = deptlist.Count + 1;
				deptlist.Add(dept);
			}
			else
			{
				var rec = deptlist.FirstOrDefault(x => x.DeptCode == dept.DeptCode);
				if (rec == null)
					return NotFound();
				rec.DeptName = dept.DeptName;
				rec.DeptAddress = dept.DeptAddress;
				rec.MobileNo = dept.MobileNo;
				rec.GSTNo = dept.GSTNo;
			}
			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				var record = deptlist.FirstOrDefault(x => x.DeptCode == id);
				if (record == null)
					return NotFound();

				deptlist.Remove(record);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
