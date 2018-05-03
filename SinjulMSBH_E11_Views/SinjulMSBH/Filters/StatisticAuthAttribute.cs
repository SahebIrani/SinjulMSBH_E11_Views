using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SinjulMSBH_E11.Features.Home;

namespace SinjulMSBH_E11.Features.Filters
{
	public class SinjulMSBHFilterAttribute: TypeFilterAttribute
	{
		public SinjulMSBHFilterAttribute ( ) : base( typeof( StatisticAuthAttribute ) )
		{
		}
	}

	public class StatisticAuthAttribute: IAuthorizationFilter
	{
		public void OnAuthorization ( AuthorizationFilterContext context )
		{
			var Result =  context.HttpContext.RequestServices.GetService<IIndexService>( ).AddView( ).Statistic;
			context.HttpContext.Request.Headers.Add( "Result" , Result.ToString( ) );
		}
	}
}