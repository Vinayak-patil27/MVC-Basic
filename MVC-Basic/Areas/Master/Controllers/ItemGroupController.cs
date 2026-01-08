using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Areas.Master.Models;

namespace MVC_Basic.Areas.Master.Controllers
{
	[Area("Master")]
	public class ItemGroupController : Controller
	{
		private static List<ItemGroup> itemGroupslist = new List<ItemGroup>(){new ItemGroup()
		{
			ItemGroupCode = 1,
			ItemGroupName = "New Group",
			ItemGroupDescription = "Description"
		} };
		public IActionResult Index()
		{
			return View(itemGroupslist);
		}

		[HttpGet]
		public IActionResult ItemGroupForm(int? id)
		{
			if (id == null || id == 0)
			{
				// INSERT
				return View(new ItemGroup());
			}

			// EDIT
			var itemGroup = itemGroupslist.FirstOrDefault(x => x.ItemGroupCode == id);
			if (itemGroup == null)
				return NotFound();

			return View(itemGroup);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ItemGroupForm(ItemGroup model)
		{
			if (!ModelState.IsValid)
				return View(model);

			if (model.ItemGroupCode == 0)
			{
				// INSERT
				model.ItemGroupCode = itemGroupslist.Count + 1;
				itemGroupslist.Add(model);
			}
			else
			{
				// UPDATE
				var existing = itemGroupslist.FirstOrDefault(x => x.ItemGroupCode == model.ItemGroupCode);
				if (existing == null)
					return NotFound();

				existing.ItemGroupName = model.ItemGroupName;
				existing.ItemGroupDescription = model.ItemGroupDescription;
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			var record = itemGroupslist.FirstOrDefault(x => x.ItemGroupCode == id);
			if (record == null)
				return NotFound();

			itemGroupslist.Remove(record);
			return RedirectToAction("Index");
		}
	}
}
