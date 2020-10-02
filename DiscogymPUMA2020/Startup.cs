using DiscogymPUMA2020.Models;
using DiscogymPUMA2020.Models.Interface;
using DiscogymPUMA2020.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiscogymPUMA2020
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
            services.AddDbContext<Context>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Puma; Trusted_Connection=True; ConnectRetryCount=1"));
            services.AddTransient<ICategoryRepo, CategoryRepo>();
            services.AddTransient<IExerciseGoalRepo, ExerciseGoalRepo>();
            services.AddTransient<IExerciseLevelRepo, ExerciseLevelRepo>();
            services.AddTransient<IExerciseRepo, ExerciseRepo>();
            services.AddTransient<IFavoriteExerciseRepo, FavoriteExerciseRepo>();
            services.AddTransient<ILogRepo, LogRepo>();
            services.AddTransient<IMoodRepo, MoodRepo>();
            services.AddTransient<IPlanRepo, PlanRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IWorkoutExerciseRepo, WorkoutExerciseRepo>();
            services.AddTransient<IWorkoutRepo, WorkoutRepo>();
            services.AddControllersWithViews();
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
