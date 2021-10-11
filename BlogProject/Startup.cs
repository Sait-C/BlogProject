using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject
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
            services.AddControllersWithViews();

            services.AddSession();

            //Proje seviyesinde authorize
            services.AddMvc(config =>
            {
                //guven, politika
                //simdi sen bana burda bir tane
                //authorization policy builder isimli sinifi newleyip
                //buna bagli olarak authenticate zorunlu kilan method yazmam gerekiyor
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser() //sisteme login olmasi
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            //pathFormat:hata kýsmýnda hangi sayfaya yonlendirilecek
            //Bunun bir sorgu almasi gerekiyor, hata kodu icin bir code degeri yazilacak
            //ve bu deger parametreden gelecek {0} ama bu null gelebilir o yuzden
            //basina soru isareti ekliyoruz
            //code isminin controller tarafýndaki parametre ile ayni isimde olmasi gerekiyor
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();   

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
