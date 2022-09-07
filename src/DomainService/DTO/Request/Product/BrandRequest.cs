namespace DomaineService.Models.Request.Product
{
    public class BrandRequest
    {
        public string BrandName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
