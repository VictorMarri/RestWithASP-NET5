using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestWithASPNETFive.Models.Context;
using RestWithASPNETFive.Repository.Generic;
using RestWithASPNETFive.Services;
using RestWithASPNETFive.Services.Implementations;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

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

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "Victor Rest API with dotnet 5",
                        Version = "v1",
                        Description = "API RESTful Developed by Victor Marri",
                        Contact  =new OpenApiContact 
                        {
                            Name = "Victor Marri",
                            Url = new Uri("https://github.com/VictorMarri")
                        }
                    });
            });

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml").ToString());
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json").ToString());
            })
                .AddXmlSerializerFormatters();

            //Pegando string de conexão do banco diretamente do nosso AppSettings.Json. lê todas as propriedades, encontra nome igual que colocamos aqui e aplica o valor dado a ela
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MySQLContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            if (_enviroment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }


            //Injeção de Dependencia
            services.AddScoped<IPersonService, PersonServiceImplementation>();

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

            app.UseCors();

            app.UseSwagger(); //Responsavel por Gerar o JSON com a documentação

            //Responsavel por gerar uma pagina HTML pra acessar a documentação
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                    "API RESTful Developed by Victor Marri - V1");
            });

            //COnfiguração da Swagger Page
            var option = new RewriteOptions();
            option.AddRedirect("^$","swagger");
            app.UseRewriter(option);

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
