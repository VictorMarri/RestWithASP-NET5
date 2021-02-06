using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASPNETFive.Models.Context;
using RestWithASPNETFive.Repository;
using RestWithASPNETFive.Repository.Generic;
using RestWithASPNETFive.Repository.Implementations;
using RestWithASPNETFive.Services;
using RestWithASPNETFive.Services.Implementations;
using Serilog;
using System;
using System.Collections.Generic;

namespace RestWithASPNETFive
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _enviroment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _enviroment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Adicionando Versionamento de APIs
            services.AddApiVersioning();

            services.AddControllers();

            //Pegando string de conexão do banco diretamente do nosso AppSettings.Json. lê todas as propriedades, encontra nome igual que colocamos aqui e aplica o valor dado a ela
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MySQLContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            if (_enviroment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }


            //Injeção de Dependencia
            services.AddScoped<IPersonService, PersonServiceImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookService, BookServiceImplementation>();
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

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
    }
}
