using System.ComponentModel.DataAnnotations.Schema;

namespace CharismaShop.Model
{
    public class Customer : BaseEntity
    {
        [Column(TypeName = "nvarchar(300)")]
        public string Name { get; set; }
    }
}