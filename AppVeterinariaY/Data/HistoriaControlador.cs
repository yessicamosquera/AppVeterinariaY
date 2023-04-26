using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppVeterinariaY.Model;

namespace AppVeterinariaY.Data
{
    public class HistoriaControlador
    {
        SQLiteAsyncConnection dbh;
        public HistoriaControlador(string dbPath)
        {
            dbh = new SQLiteAsyncConnection(dbPath);
            dbh.CreateTableAsync<HistoriaClinicaModel>().Wait();
            var tabla = dbh.Table<HistoriaClinicaModel>();
        }

        public Task<int> SaveHistoriaAsync(HistoriaClinicaModel Hist)
        {
            if (Hist.Idhistoria == 0)
            {
                return dbh.InsertAsync(Hist);
            }
            else
            {
                return null;
            }
        }
        public Task<int> UpdateHistoriaAsync(HistoriaClinicaModel Hist)
        {
            if (Hist.Idhistoria != 0)
            {
                return dbh.UpdateAsync(Hist);
            }
            else
            {
                return null;
            }

        }
        public Task<int> DeleteHistoriaAsync(HistoriaClinicaModel Hist)
        {
            return dbh.DeleteAsync(Hist);
        }

        // Recuperar todos los usuarios

        public Task<List<HistoriaClinicaModel>> GetHistoriaAsync()
        {
            return dbh.Table<HistoriaClinicaModel>().ToListAsync();
        }
        //Recupera los usuarios por Id
        public Task<HistoriaClinicaModel> GetHistoriaByIdAsync(int idhist)
        {
            return dbh.Table<HistoriaClinicaModel>().Where(a => a.Idhistoria == idhist).FirstOrDefaultAsync();
        }
    }
}
