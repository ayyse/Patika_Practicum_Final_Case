using ShoppingApi.Base.Model;

namespace ShoppingApi.Data.Model
{
    public class Category : BaseModel
    {

        public List<ShoppingList> ShoppingLists { get; set; } // bir kategorinin birden fazla listesi olabilir
    }
}
