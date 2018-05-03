using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinjulMSBH_E11.Features.Filters;

namespace SinjulMSBH_E11.Features.Home
{
	//[ServiceFilter( typeof( SinjulMSBHFilterAttribute ) )]
	[ServiceFilter( typeof( StatisticAuthAttribute ) )]
	public class HomeController: Controller
	{
		public IActionResult Index ( ) => View( );

		public IActionResult Card ( ) => View( );

		public IActionResult Carousel ( ) => View( );

		public IActionResult Pagination ( ) => View( );
	}
}