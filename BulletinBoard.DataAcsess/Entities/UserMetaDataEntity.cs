using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulletinBoard.DataAcsess.Entities;


[Table("userMetadatas")]
public class UserMetaDataEntity : BaseEntity
{
    public DateTime actionDateTime { get; set; }
    public string actionDescription { get; set; }
    
    public int moderatorId { get; set; }
    public UserEntity moderator { get; set; }
    
    public int userId { get; set; }
    public UserEntity user { get; set; }
}

