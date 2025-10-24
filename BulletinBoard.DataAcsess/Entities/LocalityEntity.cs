using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletinBoard.DataAcsess.Entities;

[Table("localities")]
public class LocalityEntity : BaseEntity
{
    public string localityName { get; set; }
    
    public virtual ICollection<AdvertisementEntity> advertisements { get; set; }
}