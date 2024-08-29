using CooperativaCreditoAPI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configurar o DbContext para usar um banco de dados in-memory
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("CooperativaCreditoDB"));

        // Registrar os repositórios
        services.AddScoped<IRepository<Correntista>, CorrentistaRepository>();
        services.AddScoped<IRepository<Conta>, ContaRepository>();

        // Adicionar serviços para controllers
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        services.AddScoped<CorrentistaService>(); // Sem interface
        services.AddScoped<ContaService>();       // Sem interface
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        DbInitializer.Initialize(context);

    }
}
