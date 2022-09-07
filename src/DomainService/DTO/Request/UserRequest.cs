using DomainService.Models.Enum;

namespace DomainService.Models.Request
 {
    public class UserRequest
    {
          public string FirstName {set;get;}
          public string LastName {set;get;}
          public string Email {set;get;}
          public string Password {set;get;}
          public string PhoneNumber {set;get;}
          public Roles Role {set;get;}
    }
 }
