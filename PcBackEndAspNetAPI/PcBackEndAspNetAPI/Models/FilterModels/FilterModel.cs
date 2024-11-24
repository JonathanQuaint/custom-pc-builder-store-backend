namespace PcBackEndAspNetAPI.Models.FilterModels
{
    public class FilterModel
    {
        public string Keyword { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string ComponentType { get; set; }
    }
}
