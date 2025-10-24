using BulletinBoard.DataAcsess.Entities;
using Microsoft.EntityFrameworkCore;


namespace BulletinBoard.DataAcsess;

public class BulletinBoardDbContext  : DbContext
{
    public DbSet<UserEntity> users { get; set; }
    public DbSet<UserMetaDataEntity>  userMetaDatas { get; set; }
    public DbSet<AdvertisementEntity> advertisements { get; set; }
    public DbSet<AdvertisememtPictureEntity> advertisememtPictures { get; set; }
    public DbSet<CategoryEntity> categories { get; set; }
    public DbSet<CategoryAdvertisementEntity> categoryAdvertisements { get; set; }
    public DbSet<LocalityEntity> localities { get; set; }
    public DbSet<FavoritiesEntity> favorities { get; set; }
    
    public BulletinBoardDbContext(DbContextOptions<BulletinBoardDbContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdvertisementEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AdvertisementEntity>().HasIndex(x => x.ExternalId).IsUnique();
        //cвязь пользователь-объявление
        modelBuilder.Entity<AdvertisementEntity>().HasOne(x => x.user)
            .WithMany(x => x.advertisements)
            .HasForeignKey(x => x.userId);
        
        //связь объявление-место
        modelBuilder.Entity<AdvertisementEntity>().HasOne(x=>x.locality)
            .WithMany(x=>x.advertisements)
            .HasForeignKey(x => x.localityId);
        
        //связь избранное-пользователь и избранное-объявления
        modelBuilder.Entity<FavoritiesEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<FavoritiesEntity>().HasIndex(x => new { x.UserId, x.AdvertisementId }).IsUnique();
        modelBuilder.Entity<FavoritiesEntity>().HasOne(x => x.advertisement)
            .WithMany(x => x.users)
            .HasForeignKey(x => x.AdvertisementId);
        modelBuilder.Entity<FavoritiesEntity>().HasOne(x=>x.user)
            .WithMany(x=>x.favorities)
            .HasForeignKey(x => x.UserId);
            
        //связь пользователь-метадата
        modelBuilder.Entity<UserMetaDataEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserMetaDataEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserMetaDataEntity>().HasOne(x => x.user)
            .WithMany(x=>x.metaDatas)
            .HasForeignKey(x => x.userId);
        //связь-модератор-метадата
        modelBuilder.Entity<UserMetaDataEntity>().HasOne(x => x.moderator)
            .WithMany(x=>x.moderatorAction)
            .HasForeignKey(x => x.moderatorId);
        
        //связь объявление-картинки
        modelBuilder.Entity<AdvertisememtPictureEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AdvertisememtPictureEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<AdvertisememtPictureEntity>()
            .HasOne(x => x.advertisement)
            .WithMany(x => x.pictures)
            .HasForeignKey(x => x.advertisementId);
        
        //связь объявление-категория
        modelBuilder.Entity<CategoryAdvertisementEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CategoryAdvertisementEntity>().HasIndex(x => new { x.categoryId, x.advertisementId }).IsUnique();
        modelBuilder.Entity<CategoryAdvertisementEntity>().HasOne(x=>x.advertisement)
            .WithMany(x=>x.categories)
            .HasForeignKey(x => x.advertisementId);
        modelBuilder.Entity<CategoryAdvertisementEntity>().HasOne(x => x.category)
            .WithMany(x => x.advertisements)
            .HasForeignKey(x => x.categoryId);
    }
}   