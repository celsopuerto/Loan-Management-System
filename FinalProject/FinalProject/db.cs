using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class db
    {
        SQLiteAsyncConnection _database;
        public db(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<table>().Wait();
        }
        public Task<int> SaveAsync(table table)
        {
            return _database.InsertAsync(table);
        }
        public Task<int> UpdateAsync(table table)
        {
            return _database.UpdateAsync(table);
        }
        public Task<List<table>> GetAllAsync()
        {
            return _database.Table<table>().ToListAsync();
        }
        public Task<int> DeleteAsync(table table)
        {
            return _database.DeleteAsync(table);
        }
        public Task<table> SearchAsync(int meter)
        {
            return _database.Table<table>().Where(i => i.ReferenceNumber == meter).FirstOrDefaultAsync();
        }
    }
}
