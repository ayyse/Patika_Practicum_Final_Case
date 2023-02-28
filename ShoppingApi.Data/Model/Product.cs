using ShoppingApi.Base.Model;

namespace ShoppingApi.Data.Model
{
    public class Product : BaseModel
    {
        public string Amount { get; set; }

        public int ShoppingListId { get; set; }
        public ShoppingList ShoppingLists { get; set; } // ürün hangi alışveriş listesine ait
    }
}
