using Challenge.Data;
using Challenge.Repositories.Enderecos;
using Challenge.Repositories.PreferenciaViagem;
using Challenge.Repositories.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<FIAPDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAP"));

            });

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IPreferenciaViagemRepository, PreferenciaViagemRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
