namespace BlueIns.CourseMgt
{
    using System;
    using AutoMapper;
    using BlueIns.CourseMgt.BusinessService;
    using BlueIns.CourseMgt.DataAccessLayer.Abstractions.Repository;
    using BlueIns.CourseMgt.DataAccessLayer.Context;
    using BlueIns.CourseMgt.DataAccessLayer.Repository;
    using BlueIns.CourseMgt.DomainModel.Abstractions;
    using BlueIns.CourseMgt.Web.Mapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Start up</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MasterContext>(Opt => Opt.UseSqlServer(this.Configuration.GetConnectionString("StudentCourseReg")));
            services.AddTransient<IStudentDetailsProvider, StudentDetailsProvider>();
            services.AddTransient<IStudentDetailsRepository, StudentDetailsRepository>();
            services.AddTransient<ICourseDetailsProvider, CourseDetailsProvider>();
            services.AddTransient<ICourseDetailsRepository, CourseDetailsRepository>();
            services.AddTransient<IRegDetailsProvider, RegDetailsProvider>();
            services.AddTransient<IRegDetailsRepository, RegDetailsRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommonMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //// Cookie settings
            //services.ConfigureApplicationCookie(Opt =>
            //{
            //    Opt.Cookie.Name = "ToDoListWebAppCookie";
            //    Opt.LoginPath = "/Home/Index"; // User defined login path
            //    Opt.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            //});

            //services.AddIdentity<LoginViewModel, IdentityRole>(Opt =>
            //{
            //    //// User defined password policy settings.
            //    /////config.Password.RequiredLength = 4;
            //    Opt.Password.RequireDigit = false;
            //    Opt.Password.RequireNonAlphanumeric = false;
            //    Opt.Password.RequireUppercase = false;
            //})
                //.AddEntityFrameworkStores<MasterContext>()
                //.AddDefaultTokenProviders();

            //services.AddScoped<AppDBContext>();
            services.AddScoped<MasterContext>();

            services.AddControllersWithViews();
            services.AddAuthorization();
            services.AddSession();
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

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
