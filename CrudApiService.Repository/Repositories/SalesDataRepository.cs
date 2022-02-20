using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesDataRepository : BaseRepository<SalesData, DataBaseContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected SalesDataRepository(DataBaseContext context)
            : base(context)
        {
        }
    }
}
