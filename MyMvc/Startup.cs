using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace MyMvc
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton(typeof(HellowServer));
            services.AddSingleton(typeof(DataService));

            Assembly assembly = Assembly.Load(new AssemblyName("Services"));//拿到该类库的所有程序集
            //获得继承IServiceBase的类并且不是抽象类的类
            var serviceTypes = assembly.GetTypes().Where(a => typeof(IServiceBase).IsAssignableFrom(a)
            && !a.GetTypeInfo().IsAbstract);
            foreach (var serviceType in serviceTypes)
            {
                foreach (var intfType in serviceType.GetInterfaces())
                {
                    if (intfType.Name != "IServiceBase")
                    {
                        services.AddSingleton(intfType, serviceType);
                    }

                }
            }

            services.AddSingleton(typeof(MyActionFilte));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc(options =>
             {
                 var serviceProvider = services.BuildServiceProvider();
                 var filter = serviceProvider.GetService<MyActionFilte>();
                 options.Filters.Add(filter);

             }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
