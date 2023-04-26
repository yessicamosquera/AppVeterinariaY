using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppVeterinariaY.Model;

namespace AppVeterinariaY.Data
{
    public class UsuariosControlador
    {
        SQLiteAsyncConnection db;
        public UsuariosControlador(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<UsuariosModel>().Wait();
        }

        public UsuariosControlador()
        { }

        public Task<int> SaveUserAsync(UsuariosModel user)
        {
            if (user.Idcedula == 0)
            {
                return db.InsertAsync(user);
            }
            else
            {
                return null;
            }
        }
        public Task<int> UpdateUserAsync(UsuariosModel user)
        {
            if (user.Idcedula != 0)
            {
                return db.UpdateAsync(user);
            }
            else
            {
                return null;
            }

        }
        public Task<int> DeleteUserAsync(UsuariosModel user)
        {
            return db.DeleteAsync(user);
        }



        public Task<List<UsuariosModel>> GetUserAsync()
        {
            return db.Table<UsuariosModel>().ToListAsync();
        }
        public async Task<UsuariosModel> GetUserAsync(string Usuario, string Contraseña)
        {
            return await db.Table<UsuariosModel>()
                                .Where(u => u.Usuario == Usuario && u.Contraseña == Contraseña)
                                .FirstOrDefaultAsync();
        }
        //Recupera los usuarios por Id
        public Task<UsuariosModel> GetUserByIdAsync(int idUser)
        {
            return db.Table<UsuariosModel>().Where(a => a.Idcedula == idUser).FirstOrDefaultAsync();
        }
    }


}

