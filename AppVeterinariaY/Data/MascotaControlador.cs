using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppVeterinariaY.Model;

namespace AppVeterinariaY.Data
{
    public class MascotaControlador
    {
        SQLiteAsyncConnection db;
        public MascotaControlador(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<MascotaModel>().Wait();
        }

        public Task<int> SaveMascotaAsync(MascotaModel user)
        {
            if (user.Idmascota == 0)
            {
                return db.InsertAsync(user);
            }
            else
            {
                return null;
            }
        }
        public Task<int> UpdateMascotaAsync(MascotaModel user)
        {
            if (user.Idmascota != 0)
            {
                return db.UpdateAsync(user);
            }
            else
            {
                return null;
            }

        }
        public Task<int> DeleteMascotaAsync(MascotaModel user)
        {
            return db.DeleteAsync(user);
        }

        // Recuperar todos los usuarios

        public Task<List<MascotaModel>> GetMascotaAsync()
        {
            return db.Table<MascotaModel>().ToListAsync();
        }
        //Recupera los usuarios por Id
        public Task<MascotaModel> GetMascotaByIdAsync(int idmasc)
        {
            return db.Table<MascotaModel>().Where(a => a.Idmascota == idmasc).FirstOrDefaultAsync();
        }

    }
}
