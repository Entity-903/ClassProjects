namespace Routing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Privacy}/{id?}");

			app.MapControllerRoute(
				name: "DefaultCow",
				pattern: "/{id:int}",
				defaults: new { controller = "Home", action = "DefaultCow" });

			app.MapControllerRoute(
				name: "EatLessCow",
				pattern: "/EatMoreChicken",
				defaults: new { controller = "Home", action = "EatLessYouCow" });

			app.MapControllerRoute(
				name: "TheCowInQuestion",
				pattern: "/{id:int}/{name}",
				defaults: new { controller = "Home", action = "TheCowInQuestion" });

			app.MapControllerRoute(
				name: "CowConvention",
				pattern: "/AllCows/Gallery/{id:int}",
				defaults: new { controller = "Home", action = "CowConvention" });

			app.MapControllerRoute(
				name: "CowConventionDoxxed",
				pattern: "/AllCows/Gallery/{id1:int}/Page{id2:int}",
				defaults: new { controller = "Home", action = "CowConventionDoxxed" });

			app.MapControllerRoute(
				name: "CowvertOperation",
				pattern: "/AllCows/Gallery/{id1:int}/{id2:int}",
				defaults: new { controller = "Home", action = "CowvertOperation" });

			// Catch all error route to Error cshtml view
			app.MapControllerRoute(
				name: "Context",
				pattern: "{*any}",
				defaults: new { controller = "Home", action = "Index" });

			app.Run();
		}
	}
}