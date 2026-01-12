using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;

namespace MVC_Basic.Areas.Master.Controllers
{
	[Area("Master")]
	public class SplitGSTController : Controller
	{
		private static List<SplitGST> gstlist = new();
		public IActionResult Index()
		{
			return View(gstlist);
		}

		[HttpGet]
		public IActionResult SplitGstForm(int? id)
		{
			try
			{
				if (id == null || id == 0)
				{
					return View(new SplitGST());
				}
				else
				{
					var rec = gstlist.FirstOrDefault(x => x.GSTId == id);
					if (rec != null)
					{
						return NotFound();
					}
					return View(rec);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		public IActionResult SplitGstForm(SplitGST splitgst) 
		{
			try
			{
				if(!ModelState.IsValid)
				{
					return View();
				}
				if (splitgst.GSTId == 0)
				{
					splitgst.GSTId = gstlist.Count + 1;
					gstlist.Add(splitgst);
				}
				else
				{
					var rec = gstlist.FirstOrDefault(x => x.GSTId == splitgst.GSTId);
					if (rec != null)
					{
						return NotFound();
					}
					rec.TaxId = splitgst.TaxId;
					rec.cgst = splitgst.cgst;
					rec.sgst = splitgst.sgst;
					rec.igst = splitgst.igst;
					rec.ValideDate = splitgst.ValideDate;
					gstlist.Add(rec);
				}
				return RedirectToAction("Index");
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				var rec = gstlist.FirstOrDefault(x => x.GSTId == id);
				if(rec==null)
				{
					return NotFound();
				}
				gstlist.Remove(rec);
				return RedirectToAction("Index");
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
