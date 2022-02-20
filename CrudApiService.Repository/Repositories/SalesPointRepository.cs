using CrudApiService.Abstract.Model;

namespace CrudApiService.Repository.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesPointRepository: BaseRepository<SalesPoint, DataBaseContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected SalesPointRepository(DataBaseContext context)
            : base(context)
        {
        }
    }
}
