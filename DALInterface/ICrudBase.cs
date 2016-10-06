using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace DALInterface
{
    public interface ICrudBase<TU> where TU:BaseEntity
    {
        T Insert<T>(T entity);
        int Insert(TU entity);
        bool Delete<T>(T entity);
        bool Delete(TU entity);
        int DeleteAll(TU entity);
        bool Update<T>(T entity);
        bool Update(TU entity);
        T Select<T>(T entity);
        TU Select(TU entity);
        List<T> SelectList<T>(T entity);
        List<TU> SelectList(TU entity);
        bool TruncateTable<T>();
        bool TruncateTable();
        int Insert<T>(List<T> entitList);
        int Insert(List<TU> entitList);
        TU SelectLast();
        T SelectLast<T>() where T : new();

    }
}
