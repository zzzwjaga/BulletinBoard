using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulletinBoard.DataAcsess.Entities;


[Table("users")]
public class UserEntity : BaseEntity
{
    public string username { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }
    public DateTime registredAt { get; set; }
    public string Role { get; set; }
    
    public virtual ICollection<FavoritiesEntity>? favorities { get; set; }
    public virtual ICollection<AdvertisementEntity>? advertisements { get; set; }
    public virtual ICollection<UserMetaDataEntity>  metaDatas { get; set; }
    public virtual ICollection<UserMetaDataEntity>? moderatorAction {get;set;}
}