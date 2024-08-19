using GamesStudio.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var ConnectionString = builder.Configuration.GetConnectionString("CS")
                  ?? throw new InvalidOperationException("No connection string was found");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(ConnectionString));


        builder.Services.AddScoped<ICategoriesService, CategoriesService>();
        builder.Services.AddScoped<IDevicesService, DevicesServices>();
        builder.Services.AddScoped<IGamesService, GamesServices>();



        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}