using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BulletinBoard.DataAcsess.Entities;


[Table("advertisementPictures")]
public class AdvertisementPictureEntity : BaseEntity
{
    public string FileExtension { get; set; }
    public string FileName { get; set; }
    public byte[] Content { get; set; }
    
    public int AdvertisementId { get; set; }
    public AdvertisementEntity Advertisement { get; set; }
}