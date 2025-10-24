using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletinBoard.DataAcsess.Entities;


[Table("categories")]
public class CategoryEntity : BaseEntity
{
    public string name { get; set; }
    
    public virtual ICollection<CategoryAdvertisementEntity>? advertisements { get; set; }
}