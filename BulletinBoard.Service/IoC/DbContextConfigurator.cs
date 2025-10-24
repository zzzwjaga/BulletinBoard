using BulletinBoard.DataAcsess;
using BulletinBoard.Service.Settings;
using Microsoft.EntityFrameworkCore;


namespace BulletinBoard.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, BulletinBoardSettings settings)
    {
        services.AddDbContextFactory<BulletinBoardDbContext>(
            options => { options.UseNpgsql(settings.BulletinBoardDbConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BulletinBoardDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
    }
}