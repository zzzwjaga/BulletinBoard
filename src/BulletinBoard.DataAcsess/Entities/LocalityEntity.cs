using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletinBoard.DataAcsess.Entities;

[Table("localities")]
public class LocalityEntity : BaseEntity
{
    public string LocalityName { get; set; }
    
    public virtual ICollection<AdvertisementEntity> Advertisements { get; set; }
}