using Microsoft.EntityFrameworkCore;
using WebApiSeyyedi.Data;
using WebApiSeyyedi.Infrastructure;
using WebApiSeyyedi.Infrastructure.RepositoryClasses;
using WebApiSeyyedi.Infrastructure.RepositoryInterfaces;
using WebApiSeyyedi.Services.ServiceClasses;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<DbContext, WEBAPIContext>(options => options.UseSqlServer(connectionString));

            ConfigurationHelper.InitConfig(configuration);


            //services.AddControllersWithViews();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBookDetailRepository, BookDetailRepository>();
            services.AddScoped<IBookDetailService, BookDetailService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //services.AddRazorPages();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endPoint =>
            {
                endPoint.MapControllers();
            });
        }
    }
}
