using Microsoft.Extensions.Configuration;
using Ninject.Modules;
using Ninject;
using Karma.Business.DependencyResolvers.Ninject;
using Karma.Business.Abstract;
using Karma.Business.Concrete;
using Karma.DataAccess;
using Karma.DataAccess.Concrete.EntityFramework;
using Karma.DataAccess.Abstract;
using Karma.MvcUI.Services;

namespace Karma.MvcUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddDistributedMemoryCache();



            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(
                System.Text.Unicode.UnicodeRanges.All);
            });


            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductDal, EfProductDal>();

            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

            builder.Services.AddScoped<IImageService, ImageManager>();
            builder.Services.AddScoped<IImageDal, EfImageDal>();

            builder.Services.AddScoped<IBrandService, BrandManager>();
            builder.Services.AddScoped<IBrandDal, EfBrandDal>();

            builder.Services.AddScoped<ICommentService, CommentManager>();
            builder.Services.AddScoped<ICommentDal, EfCommentDal>();

            builder.Services.AddSingleton<ICartSessionService, CartSessionService>();
            builder.Services.AddSingleton<ICartService, CartService>();

            builder.Services.AddSingleton<ICouponService, CouponManager>();
            builder.Services.AddSingleton<ICouponDal, EfCouponDal>();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            builder.Services.AddControllers().AddJsonOptions(obj =>
            {
                obj.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                 name: "categoryRoute",
            pattern: "Kategori/{categoryName?}/",
            defaults: new { controller = "Kategori", action = "Index" });
            app.MapControllerRoute(
                name: "searchRoute",
           pattern: "Ara/{key?}/",
           defaults: new { controller = "Ara", action = "Index" });

            app.Run();
        }
    }
}