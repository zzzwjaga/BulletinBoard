using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BulletinBoard.DataAcsess.Entities.Primitives;

namespace BulletinBoard.DataAcsess.Entities;


[Table("users")]
public class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime RegistredAt { get; set; }
    public Role Role { get; set; }
    
    public virtual ICollection<FavoritiesEntity>? Favorities { get; set; }
    public virtual ICollection<AdvertisementEntity>? Advertisements { get; set; }
    public virtual ICollection<UserMetaDataEntity>  MetaDatas { get; set; }
    public virtual ICollection<UserMetaDataEntity>? ModeratorActions {get;set;}
}