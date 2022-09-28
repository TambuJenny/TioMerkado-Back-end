namespace DomainService.Models.Product
{
    public class BrandModel
    {
        public Guid Id { get; set; } = new Guid();
        public string BrandName { get; set; }
        public string ImgUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
