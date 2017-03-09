using System.Collections.Generic;
using System.Linq;
using PropertyGuide.BusinessLayer;
using System.Threading.Tasks;

namespace PropertyGuide.DataLayer
{
    public class PropertyDatabaseAsync : AppDatabaseAsyncAsync, IPropertyDatabaseAsync
    {
        public PropertyDatabaseAsync(string path) : base(path)
        {
            //create the tables
            CreateTableAsync<Property>().Wait();
        }

        public Task<List<Property>> GetListBySellerIdAsync(int sellerId)
        {
            //Asynchronous SQLite.Net API takes care of the concurrency
            //lock (locker)
            //{
            return Table<Property>().Where(x => x.SellerId == sellerId)
                .OrderByDescending(x => x.DateModified ?? x.DateAdded).ToListAsync();
            //}
        }

        public Task<List<Property>> GetListByBuyerIdAsync(int buyerId)
        {
            //Asynchronous SQLite.Net API takes care of the concurrency
            //lock (locker)
            //{
            return Table<Property>().Where(x => x.BuyerId == buyerId)
                .OrderByDescending(x => x.DateModified ?? x.DateAdded).ToListAsync();
            //}
        }

        public Task<List<Property>> GetUnsoldListAsync()
        {
            //Asynchronous SQLite.Net API takes care of the concurrency
            //lock (locker)
            //{
            const string sql = @"SELECT p.ID, p.Name, p.Description, p.Sold, p.DateAdded, p.DateModified, p.SellerId, p.BuyerId 
                        FROM [Property] as p 
                        INNER JOIN [User] as u ON u.ID = p.SellerId
                        WHERE [Sold] = 0";

            return QueryAsync<Property>(sql);
            //}
        }
    }
}
