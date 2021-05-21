using MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using ENTITIES.DbModels;
using ENTITIES.DbConn;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EditorialDAL
    {
        public async Task<ResponseMODEL> InsertAsync(Editorial model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Editorials.Add(model);
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Editorial registrada");
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> UpdateAsync(Editorial model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Entry(model).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Editorial modificada");
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> GetAllAsync()
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    var result = await db.Editorials.ToListAsync();
                    return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Consulta exitosa a la tabla \"Editorial\"", null, result);
                }
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> GetAsync(int id)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    var result = await db.Editorials.FindAsync(id);
                    return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Consulta exitosa a la tabla \"Editorial\"", null, result);
                }
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> DeleteAsync(Editorial model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Editorials.Remove(model);
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Editorial eliminada");
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }
        


    }
}
