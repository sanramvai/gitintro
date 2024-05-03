namespace Bethanypieshop.Models
{
    public class Catigory
    {
        public int CatigoryId { get; set; }
        public string CatigoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Pie>? Pies { get; set; }
    }
}
