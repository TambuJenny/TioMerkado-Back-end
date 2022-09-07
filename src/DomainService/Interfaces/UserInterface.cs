using DomainService.Models.Request;

namespace DomainService.Interface 
{
    public interface UserInterface 
    {
        Task Create (UserRequest body);

    }
}
