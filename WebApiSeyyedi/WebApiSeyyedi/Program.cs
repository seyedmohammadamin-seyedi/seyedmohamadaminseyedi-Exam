using Microsoft.EntityFrameworkCore;
using WebApiSeyyedi;
using WebApiSeyyedi.Data;
using WebApiSeyyedi.Infrastructure;
using WebApiSeyyedi.Infrastructure.RepositoryClasses;
using WebApiSeyyedi.Infrastructure.RepositoryInterfaces;
using WebApiSeyyedi.Services.ServiceClasses;
using WebApiSeyyedi.Services.ServiceInterfaces;

internal class Program
{
    //public static void Main(string[] args)
    //{
    //    CreateHostBuilder(args).Build().Run();
    //}
    //public static IHostBuilder CreateHostBuilder(string[] args)
    //{
    //    return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
    //    {
    //        webBuilder.UseStartup<Startup>();
    //    });
    //}

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // add services to the container.

        builder.Services.AddControllers();
        // learn more about configuring swagger/openapi at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
        ConfigurationHelper.InitConfig(builder.Configuration);

        builder.Services.AddDbContext<DbContext, WEBAPIContext>(opt => { opt.UseSqlServer(cnn); });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
        builder.Services.AddScoped<ILibraryService, LibraryService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        builder.Services.AddScoped<IUserRoleService, UserRoleService>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IBookDetailRepository, BookDetailRepository>();
        builder.Services.AddScoped<IBookDetailService, BookDetailService>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
        builder.Services.AddScoped<IProvinceService, ProvinceService>();
        builder.Services.AddScoped<ICityRepository, CityRepository>();
        builder.Services.AddScoped<ICityService, CityService>();


        var app = builder.Build();

        // configure the http request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}