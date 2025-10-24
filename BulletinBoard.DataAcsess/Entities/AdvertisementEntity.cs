using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletinBoard.DataAcsess.Entities;


[Table("advertisement")]
public class AdvertisementEntity : BaseEntity
{
    public string name { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }
    public DateTime createdAt { get; set; }
    public string address { get; set; }
    
    public int localityId { get; set; }
    public LocalityEntity locality { get; set; }
    
    public int userId { get; set; }
    public UserEntity user { get; set; }
    
    public virtual ICollection<CategoryAdvertisementEntity>? categories { get; set; }
    public virtual ICollection<AdvertisememtPictureEntity>? pictures { get; set; }
    public virtual ICollection<FavoritiesEntity>? users { get; set; }
}