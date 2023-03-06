using ShoppingApi.Base.Dto;

namespace ShoppingApi.Dto.Dtos
{
    public class ShoppingListDto : BaseDto
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; } 
        public DateTime CompleteDate { get; set; } 

        public int CategoryId { get; set; }
        public string Category { get; set; }

        public int UserId { get; set; }
        public string User { get; set; }
    }
}
