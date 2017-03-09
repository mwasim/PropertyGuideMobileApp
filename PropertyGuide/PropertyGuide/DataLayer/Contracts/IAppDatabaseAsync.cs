using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;

namespace PropertyGuide.DataLayer.Contracts
{
    public interface IAppDatabaseAsync
    {
        Task<List<T>> GetAllAsync<T>() where T : BusinessLayer.Contracts.IBusinessEntity, new();
        Task<T> GetAsync<T>(int id) where T : BusinessLayer.Contracts.IBusinessEntity, new();
        Task<int> AddAsync<T>(T item) where T : BusinessLayer.Contracts.IBusinessEntity, new();
        Task<int> SaveAsync<T>(T item) where T : BusinessLayer.Contracts.IBusinessEntity, new();
        Task<int> Delete<T>(int id) where T : BusinessLayer.Contracts.IBusinessEntity, new();

        Task<CreateTablesResult> CreateTableAsync<T> ()
            where T : new ();

        Task<CreateTablesResult> CreateTablesAsync<T, T2> ()
            where T : new ()
            where T2 : new ();

        Task<CreateTablesResult> CreateTablesAsync<T, T2, T3> ()
            where T : new ()
            where T2 : new ()
            where T3 : new ();

        Task<CreateTablesResult> CreateTablesAsync<T, T2, T3, T4> ()
            where T : new ()
            where T2 : new ()
            where T3 : new ()
            where T4 : new ();

        Task<CreateTablesResult> CreateTablesAsync<T, T2, T3, T4, T5> ()
            where T : new ()
            where T2 : new ()
            where T3 : new ()
            where T4 : new ()
            where T5 : new ();

        Task<CreateTablesResult> CreateTablesAsync (params Type[] types);

        Task<int> DropTableAsync<T> ()
            where T : new ();

        Task<int> InsertAsync (object item);
        Task<int> UpdateAsync (object item);
        Task<int> DeleteAsync (object item);

        Task<T> GetAsync<T>(object pk)
            where T : new();

        Task<T> FindAsync<T> (object pk)
            where T : new ();

        Task<T> GetAsync<T> (Expression<Func<T, bool>> predicate)
            where T : new();

        Task<T> FindAsync<T> (Expression<Func<T, bool>> predicate)
            where T : new ();

        Task<int> ExecuteAsync (string query, params object[] args);
        Task<int> InsertAllAsync (IEnumerable items);
        Task<int> UpdateAllAsync (IEnumerable items);
        Task RunInTransactionAsync (Action<SQLiteAsyncConnection> action);
        Task RunInTransactionAsync(Action<SQLiteConnection> action);

        AsyncTableQuery<T> Table<T> ()
            where T : new ();

        Task<T> ExecuteScalarAsync<T> (string sql, params object[] args);

        Task<List<T>> QueryAsync<T> (string sql, params object[] args)
            where T : new ();
    }
}