using MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using ENTITIES.DbModels;
using ENTITIES.DbConn;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL
{
    public class BookDAL
    {
        public async Task<ResponseMODEL> InsertAsync(Book model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Books.Add(model);
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Libro registrado");
            }
            catch(Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle",ex.Message,ex);
            }
        }

        public async Task<ResponseMODEL> UpdateAsync(Book model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Entry(model).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Libro modificado");
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
                    var result = await db.Books.ToListAsync();
                    return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Consulta exitosa a la tabla \"Libros\"", null,result);
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
                    var result = await db.Books.FindAsync(id);
                    return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Consulta exitosa a la tabla \"Libros\"", null, result);
                }
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> DeleteAsync(Book model)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Books.Remove(model);
                    await db.SaveChangesAsync();
                }

                return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Libro eliminado");
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> GetByIdEditorialAsync(int id)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    var result = await db.Books
                        .Where(i => i.IdEditorial == id)
                        .ToListAsync();
                    return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Consulta exitosa a la tabla \"Libros\"", null, result);
                }
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> GetByIdAuthorAsync(int id)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    var result = await db.Books
                        .Where(i => i.IdAuthor == id)
                        .ToListAsync();
                    return ResponseMODEL.Instance(true, "Transaccion Exitosa", "Consulta exitosa a la tabla \"Libros\"", null, result);
                }
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion. Ver detalle", ex.Message, ex);
            }
        }

    }
}
