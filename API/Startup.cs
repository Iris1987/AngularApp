using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseEntities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repos;
using Services;
using Services.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Razor;
using API.Models;

namespace API
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
           
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            //services.AddMvc();
            //var mappingConfig = new MapperConfiguration(x =>
            //{
            //    x.AddProfile(new MappingProfile());
            //});
            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
            services.AddCors();
            services.AddAutoMapper();
            services.AddMvc();
            services.AddDbContext<MyContext>
            (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddTransient<IGeneric<Category>, CategoryRepo>();
            services.AddTransient<IGeneric<TranslationEngEst>, EngEstRepo>();
            services.AddTransient<IGeneric<LangEnglish>, EngRepo>();
            services.AddTransient<IGeneric<TranslationEngRus>, EngRusRepo>();
            services.AddTransient<IGeneric<LangEstonian>, EstRepo>();
            services.AddTransient<IGeneric<PartOfSpeech>, PartOfSpeechRepo>();
            services.AddTransient<IGeneric<TranslationRusEst>, RusEstRepo>();
            services.AddTransient<IGeneric<LangRussian>, RusRepo>();
            services.AddTransient<IGeneric<Subcategory>, SubcategoryRepo>();

            services.AddTransient<IGenericService<Category>, CategoryService>();
            services.AddTransient<IGenericService<Subcategory>, SubcategoryService>();
            services.AddTransient<IGenericService<PartOfSpeech>, PartOfSpeechService>();
            services.AddTransient<IGenericService<LangEnglish>, EngService>();
            services.AddTransient<IGenericService<LangEstonian>, EstService>();
            services.AddTransient<IGenericService<LangRussian>, RusService>();

            services.AddTransient<IGenericTranslate<TranslationEngEst>, EngEstService>();
            services.AddTransient<IGenericTranslate<TranslationEngRus>, EngRusService>();
            services.AddTransient<IGenericTranslate<TranslationRusEst>, RusEstService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

           

            app.UseStaticFiles();

            app.UseAuthentication();
            //app.UseCors("CorsPolicy");
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "LocalizedDefault",
            //        template: "{controller=EngEst}/{action=Index}/{id?}");


            //    //routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });//not sure, for 404 errors
            //});
        }
    }
}
