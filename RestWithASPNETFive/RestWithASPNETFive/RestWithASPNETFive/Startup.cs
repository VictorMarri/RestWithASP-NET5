using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASPNETFive.Models.Context;
using RestWithASPNETFive.Repository;
using RestWithASPNETFive.Repository.Implementations;
using RestWithASPNETFive.Services;
using RestWithASPNETFive.Services.Implementations;

namespace RestWithASPNETFive
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Adicionando Versionamento de APIs
            services.AddApiVersioning();

            services.AddControllers();
            //Pegando string de conexão do banco diretamente do nosso AppSettings.Json. lê todas as propriedades, encontra nome igual que colocamos aqui e aplica o valor dado a ela

            services.AddDbContext<MySQLContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            //Injeção de Dependencia
            services.AddScoped<IPersonService, PersonServiceImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
