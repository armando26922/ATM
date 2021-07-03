using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_CORE.Repository.Interface
{
    public interface IRepository<TEntitiy> : IDisposable where TEntitiy : class
    {
        ///
        /// Encuentra un objeto por la expresión indicada
        ///
        ///
        Task<TEntitiy> Find(int id);

        ///
        /// Crea un nuevo objeto en la base de datos
        ///
        ///Nuevo objeto a crear
        TEntitiy Create(TEntitiy t);

        ///
        /// Borra objetos de la base de datos en base a una expresión de filtrado
        ///
        ///
        int Delete(int id);

        ///
        /// Actualiza los cambios del objeto en la base de datos
        ///
        ///Objeto a actualizar
        int Update(TEntitiy t);
    }
}
