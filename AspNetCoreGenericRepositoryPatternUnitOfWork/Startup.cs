using AspNetCoreGenericRepositoryPatternUnitOfWork.AutoMapper;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Business;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Data;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Entities;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Helper.Extensions;
using AspNetCoreRateLimit;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebNewsApi.Helpers.Filter;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork
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
            services.AddControllers(options => options.Filters.Add<ValidateModelAttribute>());

            //Context
            services.AddSingleton<EFContext>(); // EfUserGroupDal Testler Ýçin, Repository uymayan tablolar için kullanýyorum

            //IOC
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserGroupService, UserGroupManager>();
            services.AddScoped<IUserGroupDal, EfUserGroupDal>();

            //AutoMapper
            services.AddSingleton(new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); }).CreateMapper());

            //Compression
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Fastest);
            services.AddResponseCompression();

            // needed to load configuration from appsettings.json
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            // inject counter and rules stores
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIpRateLimiting();

            app.UseResponseCompression();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
