using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletinBoard.DataAcsess.Entities;

[Table("favorities")]
public class FavoritiesEntity : BaseEntity
{
    public int UserId { get; set; }
    public int AdvertisementId { get; set; }
    public AdvertisementEntity advertisement { get; set; }
    public UserEntity user { get; set; }
}