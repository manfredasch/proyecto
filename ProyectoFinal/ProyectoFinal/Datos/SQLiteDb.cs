using System;
using SQLite;

using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoFinal.Modelos;

namespace ProyectoFinal.Datos
{
    public abstract class SQLiteDb
    {
        private SQLiteAsyncConnection database;

        public SQLiteDb(string conexion)
        {
            database = new SQLiteAsyncConnection(conexion);

            database.CreateTableAsync<DatosPaises>().Wait();
        }

        public Task<List<DatosPaises>> ListAsync()
        {
            // SELECT
            return database.Table<DatosPaises>().ToListAsync();
        }

        public Task<int> InsertAsync(DatosPaises item)
        {
            // INSERT
            return database.InsertAsync(item);
        }

        public Task<int> DeleteAsync(DatosPaises item)
        {
            // DELETE
            return database.DeleteAsync(item);
        }

        public async Task DeleteAllAsync()
        {
            // DELETE * FROM [Countries]
            await database.DeleteAllAsync<DatosPaises>();
        }
    }
}
