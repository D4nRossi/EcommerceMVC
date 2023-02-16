using EcommerceMVC.Context;
using EcommerceMVC.Models;
using EcommerceMVC.Repositories;
using EcommerceMVC.Repositories.Interfaces;
using EcommerceMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC;
public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
        services.AddControllersWithViews();
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        //Serviço da autenticação e autorização Identity
        services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        //Serviços para acessar o HttpContext(valendo por todo tempo da aplicação)
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //Injeção de dependencia
        services.AddTransient<IProdutoRepository, ProdutoRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
        //Habilitando o Cache
        services.AddMemoryCache();
        services.AddSession();

        //Sobrescrever senha do Identity
        services.Configure<IdentityOptions>(options => {
            //Default
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 4;
            options.Password.RequiredUniqueChars = 0;
        });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial) {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        } else {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        //Ativando o session
        app.UseSession();

        //Ativando autenticação e autorização
        app.UseAuthentication();
        app.UseAuthorization();

        //Criando as roles
        seedUserRoleInitial.SeedRoles();
        //Criando os users
        seedUserRoleInitial.SeedUsers();

        app.UseEndpoints(endpoints => {

            //Endpoint das Areas
            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Admin}/{action=Index}/{Id?}");

            //Endpoint dos produtos filtrados
            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Produto/{action}/{categoria?}",
                defaults: new { Controller = "Produto", Action = "List" });

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

    }
}