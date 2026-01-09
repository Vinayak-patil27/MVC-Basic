namespace MVC_Basic.Areas.Master.Models
{
    public class Item
    {
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ItemGroupCode { get; set; }
        public int ItemCompanyCode { get; set; }
        public int UnitCode { get; set; }
        public string Barcode { get; set; }
        public double MRP { get; set; }
        public double Rate { get; set; }
        public int HSCCode { get; set; }
        public int TaxID { get; set; }
        public string Description { get; set; }
        
    }
}
