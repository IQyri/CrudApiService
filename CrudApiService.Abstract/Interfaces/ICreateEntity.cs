namespace CrudApiService.Abstract.Interfaces
{
    /// <summary>
    /// Интерейс создания сущности типа T.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public interface ICreateEntity<T>
        where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Create(T model);
    }
}
