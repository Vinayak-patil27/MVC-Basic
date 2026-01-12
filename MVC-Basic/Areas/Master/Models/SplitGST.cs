namespace MVC_Basic.Areas.Master.Models
{
	public class SplitGST
	{
		public int GSTId { get; set; }
		public int TaxId { get; set; }
		public DateTime ValideDate { get; set; }
		public double? cgst { get; set; }
		public double? sgst { get; set; }
		public double? igst { get; set; }
	}
}
