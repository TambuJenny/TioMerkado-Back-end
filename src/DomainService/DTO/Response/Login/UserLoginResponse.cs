
namespace DomaineService.Models.Response.Login
{
    public class UserLoginResponse
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public IList<Guid> ShoppingCardIdSold { set; get; }
        public IList<Guid> ShoppingCardIdCart { set; get; }
        public IList<Guid> ShoppingCardIdOrdered{ set; get; }
    }
}
