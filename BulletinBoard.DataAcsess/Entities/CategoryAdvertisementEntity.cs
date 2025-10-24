using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulletinBoard.DataAcsess.Entities;

[Table("categoriesOfAdvertisements")]
public class CategoryAdvertisementEntity : BaseEntity
{
    public int categoryId { get; set; }
    public CategoryEntity category { get; set; }
    public int advertisementId { get; set; }
    public AdvertisementEntity advertisement { get; set; }
}