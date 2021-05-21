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
    public class AuthorDAL
    {
        public async Task<ResponseMODEL> InsertAsync(Author model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Authors.Add(model);
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Autor registrado");
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> UpdateAsync(Author model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Entry(model).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Autor modificado");
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
                    var result = await db.Authors.ToListAsync();
                    return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Consulta exitosa a la tabla \"Autor\"", null, result);
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
                    var result = await db.Authors.FindAsync(id);
                    return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Consulta exitosa a la tabla \"Autor\"", null, result);
                }
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> DeleteAsync(Author model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Authors.Remove(model);
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Autor eliminado");
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }
    }
}
