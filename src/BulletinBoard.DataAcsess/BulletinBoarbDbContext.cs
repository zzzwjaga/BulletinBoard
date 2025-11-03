using BulletinBoard.DataAcsess.Entities;
using Microsoft.EntityFrameworkCore;


namespace BulletinBoard.DataAcsess;

public class BulletinBoardDbContext  : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserMetaDataEntity>  UserMetaDatas { get; set; }
    public DbSet<AdvertisementEntity> Advertisements { get; set; }
    public DbSet<AdvertisementPictureEntity> AdvertisememtPictures { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CategoryAdvertisementEntity> CategoryAdvertisements { get; set; }
    public DbSet<LocalityEntity> Localities { get; set; }
    public DbSet<FavoritiesEntity> Favorities { get; set; }
    
    public BulletinBoardDbContext(DbContextOptions<BulletinBoardDbContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<LocalityEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<LocalityEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<CategoryEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<AdvertisementEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AdvertisementEntity>().HasIndex(x => x.ExternalId).IsUnique();
        //cвязь пользователь-объявление
        modelBuilder.Entity<AdvertisementEntity>().HasOne(x => x.User)
            .WithMany(x => x.Advertisements)
            .HasForeignKey(x => x.UserId);

        //связь объявление-место
        modelBuilder.Entity<AdvertisementEntity>().HasOne(x => x.Locality)
            .WithMany(x => x.Advertisements)
            .HasForeignKey(x => x.LocalityId);

        //связь избранное-пользователь и избранное-объявления
        modelBuilder.Entity<FavoritiesEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<FavoritiesEntity>().HasIndex(x => new { x.UserId, x.AdvertisementId }).IsUnique();
        modelBuilder.Entity<FavoritiesEntity>().HasOne(x => x.Advertisement)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.AdvertisementId);
        modelBuilder.Entity<FavoritiesEntity>().HasOne(x => x.User)
            .WithMany(x => x.Favorities)
            .HasForeignKey(x => x.UserId);

        //связь пользователь-метадата
        modelBuilder.Entity<UserMetaDataEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserMetaDataEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserMetaDataEntity>().HasOne(x => x.User)
            .WithMany(x => x.MetaDatas)
            .HasForeignKey(x => x.UserId);
        //связь-модератор-метадата
        modelBuilder.Entity<UserMetaDataEntity>().HasOne(x => x.Moderator)
            .WithMany(x => x.ModeratorActions)
            .HasForeignKey(x => x.ModeratorId);

        //связь объявление-картинки
        modelBuilder.Entity<AdvertisementPictureEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AdvertisementPictureEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<AdvertisementPictureEntity>()
            .HasOne(x => x.Advertisement)
            .WithMany(x => x.Pictures)
            .HasForeignKey(x => x.AdvertisementId);

        //связь объявление-категория
        modelBuilder.Entity<CategoryAdvertisementEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CategoryAdvertisementEntity>()
            .HasIndex(x => new { x.CategoryId, x.AdvertisementId }).IsUnique();
        modelBuilder.Entity<CategoryAdvertisementEntity>().HasOne(x => x.Advertisement)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.AdvertisementId);
        modelBuilder.Entity<CategoryAdvertisementEntity>().HasOne(x => x.CategoryEntity)
            .WithMany(x => x.Advertisements)
            .HasForeignKey(x => x.CategoryId);

        //огранничения столбцов для User
        modelBuilder.Entity<UserEntity>().Property(x => x.Email).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Username).IsUnique();
        modelBuilder.Entity<UserEntity>().Property(x => x.Username).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.PhoneNumber).IsUnique();
        modelBuilder.Entity<UserEntity>().Property(x => x.PhoneNumber).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<UserEntity>().Property(x => x.Role).HasConversion<string>().HasMaxLength(20).IsRequired();
        modelBuilder.Entity<UserEntity>().Property(x => x.RegistredAt).IsRequired().HasDefaultValueSql("NOW()");

        //ограничения столбуов для UserMetadata
        modelBuilder.Entity<UserMetaDataEntity>().Property(x => x.ActionDateTime).IsRequired()
            .HasDefaultValueSql("NOW()");
        modelBuilder.Entity<UserMetaDataEntity>().Property(x => x.ActionDescription).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<UserMetaDataEntity>().Property(x => x.ModeratorId).IsRequired();
        modelBuilder.Entity<UserMetaDataEntity>().Property(x => x.UserId).IsRequired();
        
        //ограничения столбцов для Locality
        modelBuilder.Entity<LocalityEntity>().Property(x=>x.LocalityName).IsRequired().HasMaxLength(200);
        
        //ограничения столбцов для AdvertisementPictures
        modelBuilder.Entity<AdvertisementPictureEntity>().Property(x=>x.AdvertisementId).IsRequired();
        modelBuilder.Entity<AdvertisementPictureEntity>().Property(x => x.FileExtension).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<AdvertisementPictureEntity>().Property(x => x.FileName).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<AdvertisementPictureEntity>().HasIndex(x=>x.FileName).IsUnique();
        modelBuilder.Entity<AdvertisementPictureEntity>().Property(x => x.Content).IsRequired();
        
        //ограничения столбцов для Advertisement
        modelBuilder.Entity<AdvertisementEntity>().Property(x=>x.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<AdvertisementEntity>().Property(x=>x.Description).IsRequired().HasMaxLength(1000);
        modelBuilder.Entity<AdvertisementEntity>().Property(x => x.Price).IsRequired();
        modelBuilder.Entity<AdvertisementEntity>().HasCheckConstraint("CK_Advertisement_Price", "\"Price\" >= 0");
        modelBuilder.Entity<AdvertisementEntity>().Property(x=>x.CreatedAt).IsRequired().HasDefaultValueSql("NOW()");
        modelBuilder.Entity<AdvertisementEntity>().Property(x=>x.Address).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<AdvertisementEntity>().Property(x=>x.LocalityId).IsRequired();
        modelBuilder.Entity<AdvertisementEntity>().Property(x=>x.UserId).IsRequired();
        modelBuilder.Entity<AdvertisementEntity>().Property(x=>x.Status).IsRequired();
        modelBuilder.Entity<AdvertisementEntity>().Property(x => x.Type).HasConversion<string>().HasMaxLength(20);
        modelBuilder.Entity<AdvertisementEntity>().Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
        
        //ограничение столбцов для Category
        modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<CategoryEntity>().Property(x => x.Name).IsRequired().HasMaxLength(100);

    }



}   