using System.Linq;

using Microsoft.AspNetCore.Mvc;

using SinjulMSBH_E11.Data;

namespace SinjulMSBH_E11.Features.ViewComponents
{
	public class StatisticViewComponent: ViewComponent
	{
		private readonly SinjulMSBHDbContext context;

		public StatisticViewComponent ( SinjulMSBHDbContext context ) => this.context=context;

		public IViewComponentResult Invoke (/* [FromServices] SinjulMSBHDbContext context */)
		{
			var Items =  context.SinjulMSBH.SingleOrDefault(a=>a.Id.Equals(1)).Statistic;
			return View( Items );
		}
	}
}