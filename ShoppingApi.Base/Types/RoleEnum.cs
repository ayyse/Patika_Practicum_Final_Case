using System.ComponentModel;

namespace ShoppingApi.Base.Types
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.Viewer)]
        Viewer = 2
    }

    public class Role
    {
        public const string Admin = "Admin";
        public const string Viewer = "Viewer";
    }
}
