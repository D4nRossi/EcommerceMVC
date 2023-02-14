using EcommerceMVC.Context;
using EcommerceMVC.Models;
using EcommerceMVC.Repositories;
using EcommerceMVC.Repositories.Interfaces;
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
        //Serviços para acessar o HttpContext(valendo por todo tempo da aplicação)
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //Injeção de dependencia
        services.AddTransient<IProdutoRepository, ProdutoRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        //Habilitando o Cache
        services.AddMemoryCache();
        services.AddSession();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
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

        app.UseAuthorization();

        app.UseEndpoints(endpoints => {

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