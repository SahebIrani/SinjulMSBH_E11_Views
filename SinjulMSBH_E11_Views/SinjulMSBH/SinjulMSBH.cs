using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SinjulMSBH_E11.Data;
using SinjulMSBH_E11.Features.Filters;
using SinjulMSBH_E11.Features.Home;
using SinjulMSBH_E11_Views.Features.Common;

namespace SinjulMSBH_E11_Views
{
	public class SinjulMSBH
	{
		public void ConfigureServices ( IServiceCollection services )
		{
			services.AddDbContext<SinjulMSBHDbContext>( options =>
				  options.UseInMemoryDatabase( "SinjulMSBH" )
			);

			services.AddSingleton<IActionContextAccessor , ActionContextAccessor>( );
			services.AddTransient<IIndexService , IndexService>( );
			services.AddScoped<StatisticAuthAttribute>( );

			services.Configure<RazorViewEngineOptions>( options =>
			{
				options.ViewLocationExpanders.Add( new FeaturesViewLocationExpander( ) );
				options.ViewLocationExpanders.Add( new CustomViewLocator( ) );
			} );

			//var builder = services.AddMvcCore();
			//builder.AddViews( );

			services.AddMvc( );
		}

		public void Configure ( IApplicationBuilder app , IHostingEnvironment env )
		{
			if ( env.IsDevelopment( ) )
			{
				app.UseDeveloperExceptionPage( );
				ServeFromDirectory( app , env , "SinjulMSBH/Content" );
			}

			app.UseMvcWithDefaultRoute( );
		}

		public void ServeFromDirectory ( IApplicationBuilder app , IHostingEnvironment env , string path )
		{
			app.UseStaticFiles( new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider( Path.Combine( env.ContentRootPath , path ) ) ,
				RequestPath = "/" + path
			} );
		}
	}

	public class Program
	{
		public static void Main ( string[ ] args )
		{
			BuildWebHost( args ).Run( );
		}

		public static IWebHost BuildWebHost ( string[ ] args ) =>
		    WebHost.CreateDefaultBuilder( args )
			  .UseStartup<SinjulMSBH>( )
			  .Build( );
	}
}