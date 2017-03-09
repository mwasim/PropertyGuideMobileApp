using System.Collections.Generic;

namespace PropertyGuide.DataLayer
{
    public interface IAppDatabase
    {
        List<T> GetAll<T>() where T : BusinessLayer.Contracts.IBusinessEntity, new();
        T Get<T>(int id) where T : BusinessLayer.Contracts.IBusinessEntity, new();
        int Save<T>(T item) where T : BusinessLayer.Contracts.IBusinessEntity, new();
        int Add<T>(T item) where T : BusinessLayer.Contracts.IBusinessEntity, new();
        int Delete<T>(int id) where T : BusinessLayer.Contracts.IBusinessEntity, new();
        List<T> Query<T>(string query, params object[] args) where T : new();
        T ExecuteScalar<T>(string query, params object[] args);
    }
}