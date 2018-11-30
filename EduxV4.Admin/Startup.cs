using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EduxV4.Admin.Services;
using EduxV4.Repo;
using EduxV4.Service;
using EduxV4.Data;
using Microsoft.AspNetCore.Http;
using static EduxV4.Service.CountryService;
using static EduxV4.Service.HomeworkService;

namespace EduxV4.Admin
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ICampusService, CampusService>();
            services.AddTransient<IActivityTypeService, ActivityTypeService>();
            services.AddTransient<IActivityNextStepService, ActivityNextStepService>();
            services.AddTransient<IActivityStatusService, ActivityStatusService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IActivitySourceService, ActivitySourceService > ();
            services.AddTransient<IFamilyService, FamilyService>();
            services.AddTransient<IOccupationService, OccupationService>();
            services.AddTransient<ICountyService, CountyService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IPositivenessService, PositivenessService>();
            services.AddTransient<ISchoolLevelService, SchoolLevelService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<ISchoolService, SchoolService>();
            services.AddTransient<IClassLevelService, ClassLevelService>();
            services.AddTransient<IHomeworkService, HomeworkService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseResourceService, CourseResourceService>();
            services.AddTransient<ICourseContentService, CourseContentService>();
            services.AddTransient<ISeasonService, SeasonService>();
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
