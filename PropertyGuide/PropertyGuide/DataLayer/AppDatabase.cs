using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace PropertyGuide.DataLayer
{
    public class AppDatabase : SQLiteConnection, IAppDatabase
    {        
        public AppDatabase(string path) : base(path)
        {

        }

        public List<T> GetAll<T>() where T : BusinessLayer.Contracts.IBusinessEntity, new()
        {
            //Asynchronous SQLite.Net API takes care of the concurrency
            //lock (locker)
            //{
            return Table<T>().ToList();
            //}
        }

        public T Get<T>(int id) where T : BusinessLayer.Contracts.IBusinessEntity, new()
        {
            //Asynchronous SQLite.Net API takes care of the concurrency
            //lock (locker)
            //{
            //return Table<T>().Where(x => x.ID == id).FirstOrDefaultAsync();
            //return QueryAsync<T>()

            var query = $"SELECT * from {typeof(T).Name} where Id ={id}";
            var items = Query<T>(query);
            return items.FirstOrDefault();
            //return Table<T>().FirstOrDefaultAsync();
            //}
        }

        public int Save<T>(T item) where T : BusinessLayer.Contracts.IBusinessEntity, new()
        {
            //Asynchronous SQLite.Net API takes care of the concurrency
            //lock (locker)
            //{
            if (item.ID != 0)
            {
                return Update(item);
                //return item.ID;
            }
            else
            {
                return Insert(item);
            }
            //}
        }

        public int Add<T>(T item) where T : BusinessLayer.Contracts.IBusinessEntity, new()
        {
            return Insert(item);
        }

        public int Delete<T>(int id) where T : BusinessLayer.Contracts.IBusinessEntity, new()
        {
            //Asynchronous SQLite.Net API takes care of the concurrency
            //lock (locker)
            //{
            return Delete(new T() { ID = id });
            //}
        }
    }
}