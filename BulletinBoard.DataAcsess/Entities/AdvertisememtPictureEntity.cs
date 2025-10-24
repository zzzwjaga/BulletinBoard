using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BulletinBoard.DataAcsess.Entities;


[Table("advertisementPictures")]
public class AdvertisememtPictureEntity : BaseEntity
{
    public string fileExtension { get; set; }
    public string fileName { get; set; }
    public byte[] content { get; set; }
    
    public int advertisementId { get; set; }
    public AdvertisementEntity advertisement { get; set; }
}