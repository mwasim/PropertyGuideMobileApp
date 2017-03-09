using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Threading.Tasks;
using PropertyGuide.DataLayer.Contracts;

namespace PropertyGuide.DataLayer
{
	/// <summary>
	/// AppDatabase builds on SQLite.Net and represents a specific database, in our case, the Property DB.
	/// It contains methods for retrieval and persistance as well as db creation, all based on the 
	/// underlying ORM.
	/// 
	/// The advantage of using the asynchronous SQLite.Net API is that database operations are moved to background threads. 
	/// In addition, there's no need to write additional concurrency handling code because the API takes care of it.
	/// </summary>
	public class AppDatabaseAsyncAsync : SQLiteAsyncConnection, IAppDatabaseAsync
	{
		//protected static object locker = new object(); //no need for concurrency checks

		/// <summary>
		/// Initializes a new instance of the <see cref="Property.DataLayer.PropertyDatabase"/> AppDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public AppDatabaseAsyncAsync(string path) : base(path)
		{
			//create the tables
			//CreateTable<Property>();
		}

		public Task<List<T>> GetAllAsync<T>() where T : BusinessLayer.Contracts.IBusinessEntity, new()
		{
			//Asynchronous SQLite.Net API takes care of the concurrency
			//lock (locker)
			//{
			return Table<T>().ToListAsync();
			//}
		}

		public async Task<T> GetAsync<T>(int id) where T : BusinessLayer.Contracts.IBusinessEntity, new()
		{
			//Asynchronous SQLite.Net API takes care of the concurrency
			//lock (locker)
			//{
			//return Table<T>().Where(x => x.ID == id).FirstOrDefaultAsync();
			//return QueryAsync<T>()

			var query = $"SELECT * from {typeof(T).Name} where Id ={id}";
			var items = await QueryAsync<T>(query);
			return items.FirstOrDefault();
			//return Table<T>().FirstOrDefaultAsync();
			//}
		}

		public Task<int> SaveAsync<T>(T item) where T : BusinessLayer.Contracts.IBusinessEntity, new()
		{
			//Asynchronous SQLite.Net API takes care of the concurrency
			//lock (locker)
			//{
			if (item.ID != 0)
			{
				return UpdateAsync(item);
				//return item.ID;
			}
			else
			{
				return InsertAsync(item);
			}
			//}
		}

		public Task<int> AddAsync<T>(T item) where T : BusinessLayer.Contracts.IBusinessEntity, new()
		{
			return InsertAsync(item);
		}

		public Task<int> Delete<T>(int id) where T : BusinessLayer.Contracts.IBusinessEntity, new()
		{
			//Asynchronous SQLite.Net API takes care of the concurrency
			//lock (locker)
			//{
			return DeleteAsync(new T() { ID = id });
			//}
		}
	}
}
