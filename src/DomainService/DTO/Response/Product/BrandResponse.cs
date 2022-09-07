namespace DomaineService.Models.Response.Product
{
    public class BrandResponse
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
