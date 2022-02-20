using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesRepository : BaseRepository<Sale, DataBaseContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected SalesRepository(DataBaseContext context)
            : base(context)
        {
        }
    }
}
