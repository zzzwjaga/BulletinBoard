namespace BulletinBoard.Service.Settings;

public class BulletinBoardSettingsReader
{
    public static BulletinBoardSettings Read(IConfiguration configuration)
    {
        return new BulletinBoardSettings()
        {
            BulletinBoardDbConnectionString =
                configuration.GetConnectionString("BulletinBoardDbContext")
        };
    }
}