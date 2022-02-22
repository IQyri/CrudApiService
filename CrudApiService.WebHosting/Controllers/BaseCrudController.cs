using System.Linq;
using CrudApiService.Abstract.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiService.WebHosting.Controllers
{
    /// <summary>
    /// Базовый CRUD контроллер.
    /// </summary>
    /// <typeparam name="T">Тип репозитория модели типа T2</typeparam>
    /// <typeparam name="T2">Тип модели</typeparam>
    public abstract class BaseCrudController<T, T2> : Controller
        where T : IRepository<T2>, ICreateEntity<T2>
        where T2 : class

    {
        /// <summary>
        /// Инстанс репозиотрия модели типа T2.
        /// </summary>
        protected readonly IRepository<T2> _repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиотрий модели типа T2.</param>
        protected BaseCrudController(IRepository<T2> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получение всех данных модели.
        /// </summary>
        /// <returns>IActionResult со списком всех моделей.</returns>
        [HttpGet(nameof(Read))]
        public virtual IActionResult Read()
        {
            return new JsonResult(_repository.GetAll().ToList());
        }

        /// <summary>
        /// Добавить модели типа Т2 в бж.
        /// </summary>
        /// <param name="model">Модель данных.</param>
        /// <returns>Id добавленной модели.</returns>
        [HttpPost(nameof(Create))]
        public virtual IActionResult Create(T2 model)
        {
           var id =  (_repository as ICreateEntity<T2>)!.Create(model);
            return new JsonResult(new
            {
                Id = id
            });
        }

        /// <summary>
        /// Обновить запись в бд модели.
        /// </summary>
        /// <param name="model">Модель данных.</param>
        /// <returns>Ок</returns>
        [HttpPatch(nameof(Update))]
        public IActionResult Update(T2 model)
        {
            _repository.Update(model);
            return Ok();
        }

        /// <summary>
        ///  Удалить запись с заданным идентификатором из бд.
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>ОК</returns>
        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
