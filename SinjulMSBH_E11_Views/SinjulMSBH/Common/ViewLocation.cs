using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace SinjulMSBH_E11_Views.Features.Common
{
	public class FeaturesViewLocationExpander: IViewLocationExpander
	{
		public void PopulateValues ( ViewLocationExpanderContext context )
		{
			context.Values[ "customviewlocation" ] = nameof( FeaturesViewLocationExpander );
		}

		public IEnumerable<string> ExpandViewLocations (
			    ViewLocationExpanderContext context , IEnumerable<string> viewLocations )
		{
			var viewLocationFormats = new[]
			{
				"~/SinjulMSBH/{0}.cshtml",
				"~/SinjulMSBH/{1}/{0}.cshtml",
				"~/SinjulMSBH/Shared/{0}.cshtml"
			};
			return viewLocationFormats;
		}
	}

	public class CustomViewLocator: IViewLocationExpander
	{
		public void PopulateValues ( ViewLocationExpanderContext context )
		{ }

		public virtual IEnumerable<string> ExpandViewLocations ( ViewLocationExpanderContext context , IEnumerable<string> viewLocations )
		{
			//Replace folder view with CustomViews
			return viewLocations.Select( f => f.Replace( "/Views/" , "/SinjulMSBH/" ) );
		}
	}
}