using KUSYS.Core.Entity;

namespace KUSYS.Core.Contracts.DTOs
{
    public class UserDTO : DTOBase<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}