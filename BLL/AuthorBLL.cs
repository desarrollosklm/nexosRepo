using DAL;
using ENTITIES.DbConn;
using ENTITIES.DbModels;
using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthorBLL
    {
        private BookDAL bookDAL = new BookDAL();
        private AuthorDAL authorDAL = new AuthorDAL();

        public async Task<ResponseMODEL> InsertAsync(AuthorMODEL model)
        {
            try
            {
                Author modelDAL = new Author();
                modelDAL.Email = model.Email;
                modelDAL.BirthDate = model.BirthDate;
                modelDAL.CityOrigin = model.CityOrigin;
                modelDAL.FullName = model.FullName;
                modelDAL.IdAuthor = model.IdAuthor;

                return await authorDAL.InsertAsync(modelDAL);
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion.", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> UpdateAsync(AuthorMODEL model)
        {
            try
            {
                Author modelDAL = new Author();
                modelDAL.Email = model.Email;
                modelDAL.BirthDate = model.BirthDate;
                modelDAL.CityOrigin = model.CityOrigin;
                modelDAL.FullName = model.FullName;
                modelDAL.IdAuthor = model.IdAuthor;

                return await authorDAL.UpdateAsync(modelDAL);
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion.", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> GetAllAsync()
        {
            try
            {
                var resultProcess = await authorDAL.GetAllAsync();
                if (resultProcess.IsApproved)
                {
                    List<Author> result = (List<Author>)resultProcess.ObjectResult;
                    if (result.Count == 0)
                    {
                        return ResponseMODEL.Instance(true, "Consulta Exitosa", "Lista Vacia", "La tabla \"Autor\" esta vacia", result);
                    }
                    else
                    {
                        var resultList = result.Select(i => new AuthorMODEL
                        {
                            Email = i.Email,
                            BirthDate = i.BirthDate,
                            CityOrigin = i.CityOrigin,
                            FullName = i.FullName,
                            IdAuthor = i.IdAuthor
                        }
                        ).ToList();

                        resultProcess.ObjectResult = null;
                        resultProcess.ObjectResult = resultList;
                    }
                }


                return resultProcess;
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion.", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> GetAsync(int id)
        {
            try
            {
                var resultProcess = await authorDAL.GetAsync(id);
                if (resultProcess.IsApproved)
                {
                    Author result = (Author)resultProcess.ObjectResult;
                    if (result == null)
                    {
                        return ResponseMODEL.Instance(true, "Consulta Exitosa", "Sin resultados", "No existen coincidencias con para esta consulta", result);
                    }
                    else
                    {
                        AuthorMODEL resultObject = new AuthorMODEL
                        {
                            Email = result.Email,
                            BirthDate = result.BirthDate,
                            CityOrigin = result.CityOrigin,
                            FullName = result.FullName,
                            IdAuthor = result.IdAuthor
                        };

                        resultProcess.ObjectResult = null;
                        resultProcess.ObjectResult = resultObject;
                    }
                }

                return resultProcess;
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion.", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> DeleteAsync(int id)
        {
            try
            {
                var resultProcess = await authorDAL.GetAsync(id);
                var validateBooks = await bookDAL.GetByIdAuthorAsync(id);

                if (!validateBooks.IsApproved)
                {
                    return resultProcess;
                }

                if (((List<Book>)validateBooks.ObjectResult).Count > 0)
                {
                    return ResponseMODEL.Instance(false, "Transaccion Rechazada", "Autor con libros activos", "No puede eliminar un autor si tiene libros activos");
                }

                if (resultProcess.IsApproved)
                {
                    if ((Author)resultProcess.ObjectResult != null)
                    {
                        return await authorDAL.DeleteAsync((Author)resultProcess.ObjectResult);
                    }
                    else
                    {
                        return ResponseMODEL.Instance(false, "Transaccion Rechazada", "No es posible eliminar el autor", "No existe un autor que coincida con el codigo enviado");
                    }
                }
                else
                {
                    return resultProcess;
                }

            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion.", ex.Message, ex);
            }
        }
    }
}
