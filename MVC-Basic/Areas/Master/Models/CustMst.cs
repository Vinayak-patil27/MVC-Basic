namespace MVC_Basic.Areas.Master.Models
{
    public class CustMst
    {
        public int CombId { get ; set; }
        public string CombName { get; set; }
        public string? Address { get; set; }
        public string? Mobno { get; set; }
        public DateTime? DOB { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AddharNo { get; set; }
        public string? GstNo { get; set; }
        public double? Comm {  get; set; }
        public int iscust {  get; set; }
        public int issupplier { get; set; }
        public int isDealer { get; set; }
        public int isemployee { get; set; }
    }
}
