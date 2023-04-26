using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppVeterinariaY.Model;

namespace AppVeterinariaY.Data
{
    public class OrdenControlador
    {
        SQLiteAsyncConnection db;
        public OrdenControlador(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<OrdenModel>().Wait();
        }

        public Task<int> SaveOrdenAsync(OrdenModel user)
        {
            if (user.Idorden == 0)
            {
                return db.InsertAsync(user);
            }
            else
            {
                return null;
            }
        }
        public Task<int> UpdateOrdenAsync(OrdenModel user)
        {
            if (user.Idorden != 0)
            {
                return db.UpdateAsync(user);
            }
            else
            {
                return null;
            }

        }
        public Task<int> DeleteOrdenAsync(OrdenModel user)
        {
            return db.DeleteAsync(user);
        }

        // Recuperar todos los usuarios

        public Task<List<OrdenModel>> GetOrdenAsync()
        {
            return db.Table<OrdenModel>().ToListAsync();
        }
        //Recupera los usuarios por Id
        public Task<OrdenModel> GetOrdenByIdAsync(int idord)
        {
            return db.Table<OrdenModel>().Where(a => a.Idorden == idord).FirstOrDefaultAsync();
        }
    }
}

