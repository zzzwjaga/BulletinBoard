using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulletinBoard.DataAcsess.Entities;

[Table("categoriesOfAdvertisements")]
public class CategoryAdvertisementEntity : BaseEntity
{
    public int CategoryId { get; set; }
    public CategoryEntity CategoryEntity { get; set; }
    public int AdvertisementId { get; set; }
    public AdvertisementEntity Advertisement { get; set; }
}