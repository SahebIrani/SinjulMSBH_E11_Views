using System.Linq;

using SinjulMSBH_E11.Data;

namespace SinjulMSBH_E11.Features.Home
{
	public interface IIndexService
	{
		IndexViewModel AddView ( );
	}

	public class IndexService: IIndexService
	{
		private readonly SinjulMSBHDbContext db;

		public IndexService ( SinjulMSBHDbContext db )
		{
			this.db=db;
		}

		public IndexViewModel AddView ( )
		{
			var get = db.SinjulMSBH;
			if ( get == null || get.Count( ).Equals( 0 ) )
			{
				db.SinjulMSBH.Add( new SinjulMSBH { Id = 1 , Statistic = 1000 } );
				db.SaveChanges( );
			}
			else
			{
				var plus = get.SingleOrDefault( a => a.Id.Equals(1) );
				plus.Statistic++;
				db.SinjulMSBH.Update( plus );
				db.SaveChanges( );
			}

			return new IndexViewModel { Statistic =  get.FirstOrDefault( ).Statistic };
		}
	}
}