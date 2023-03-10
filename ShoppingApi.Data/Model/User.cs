using ShoppingApi.Base.Model;

namespace ShoppingApi.Data.Model
{
    public class User : BaseModel
    {
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime LastActivity { get; set; }

        public List<ShoppingList> ShoppingLists { get; set; }
    }
}
