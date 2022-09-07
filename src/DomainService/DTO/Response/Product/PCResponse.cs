using DomainService.Models.Product;
using DomainService.Models;

namespace DomaineService.Models.Response.Product
{
    public class PcResponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Images { get; set; }
        public BrandModel BrandId { get; set; }
        public int Ram { get; set; }
        public int HardDisk { get; set; }
        public float ProcessorSpeed { get; set; }
        public string Failure { get; set; }
        public string Description { get; set; }
        public double FirtPrice { get; set; }
        public double LastPrice { get; set; }
        public UserModel UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
