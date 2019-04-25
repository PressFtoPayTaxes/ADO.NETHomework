using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensions
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T item);
        void Update(T item);
        void Delete(Guid id);
        List<T> Select();
    }
}
