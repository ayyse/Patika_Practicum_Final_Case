using ShoppingApi.Base.Dto;

namespace ShoppingApi.Dto.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Amount { get; set; }
        public int ShoppingListId { get; set; }
        public string ShoppingList { get; set; }
    }
}
