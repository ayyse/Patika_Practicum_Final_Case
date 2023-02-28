using ShoppingApi.Base.Model;

namespace ShoppingApi.Data.Model
{
    public class ShoppingList : BaseModel
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; } = false; // checkbox default olarak işaretlenmeden geliyor
        public DateTime CreateDate { get; set; } // listenin oluşturma tarihi
        public DateTime CompleteDate { get; set; } // product alanındaki tüm ürünler checkbox true olunca tarih ata 

        public List<Product> Products { get; set; } // bir alışveriş listesinin birden fazla ürünü olabilir

        public int CategoryId { get; set; }
        public Category Categories { get; set; } // alışveriş listesi hangi kategoriye ait
    }
}
