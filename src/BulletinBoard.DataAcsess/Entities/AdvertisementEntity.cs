using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BulletinBoard.DataAcsess.Entities.Primitives;
using Type = System.Type;

namespace BulletinBoard.DataAcsess.Entities;


[Table("advertisement")]
public class AdvertisementEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Address { get; set; }
    
    public AdvertisementType Type { get; set; }
    
    public Status Status { get; set; }
    
    public int LocalityId { get; set; }
    public LocalityEntity Locality { get; set; }
    
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    public virtual ICollection<CategoryAdvertisementEntity>? Categories { get; set; }
    public virtual ICollection<AdvertisementPictureEntity>? Pictures { get; set; }
    public virtual ICollection<FavoritiesEntity>? Users { get; set; }
}