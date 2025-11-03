using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulletinBoard.DataAcsess.Entities;


[Table("userMetadatas")]
public class UserMetaDataEntity : BaseEntity
{
    public DateTime ActionDateTime { get; set; }
    public string ActionDescription { get; set; }
    
    public int ModeratorId { get; set; }
    public UserEntity Moderator { get; set; }
    
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}

