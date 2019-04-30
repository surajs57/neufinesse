using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NeuFinesse.Data.DataManager;
using NeuFinesse.Data.Model;
using NeuFinesse.Data.Repository;

namespace NeuFinesse
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)

        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NeuFinesseContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("NeuFinesseDB")));
            services.AddScoped<IUserRepository<Data.Model.User>, UserDataManager>();
            services.AddScoped<IDataRepository<Data.Model.Interest>, InterestDataManager>();
            services.AddScoped<IUserRepository<Data.Model.UserInterest>, UserInterestDataManager>();
            services.AddScoped<IUserRepository<Data.Model.SellerDetail>, SellerDetailDataManager>();
            services.AddScoped<IDataRepository<Data.Model.Item>, ItemDataManager>();
            services.AddScoped<IUserRepository<Data.Model.Cart>, CartDataManager>();
            services.AddScoped<IUserRepository<Data.Model.WishList>, WishListDataManager>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}