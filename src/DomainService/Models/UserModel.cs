using DomainService.Models.Enum;

namespace DomainService.Models
{
    public class UserModel
    {
        public Guid Id { set; get; } = new Guid();
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string ImageURL { set; get; }
        public string PhoneNumber { set; get; }
        public Roles Role { set; get; }

        public DateTime DateCreate { set; get; } = DateTime.Now;
        public DateTime DateUpdate { set; get; } = DateTime.Now;
    }
}
