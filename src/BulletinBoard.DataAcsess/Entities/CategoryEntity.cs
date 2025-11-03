using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletinBoard.DataAcsess.Entities;


[Table("categories")]
public class CategoryEntity : BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<CategoryAdvertisementEntity>? Advertisements { get; set; }
}