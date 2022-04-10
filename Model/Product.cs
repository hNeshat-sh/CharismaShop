using System.ComponentModel.DataAnnotations.Schema;

namespace CharismaShop.Model
{
    public class Product : BaseEntity
    {
        [Column(TypeName = "nvarchar(300)")]
        public string Title { get; set; }
        
        
    }
}