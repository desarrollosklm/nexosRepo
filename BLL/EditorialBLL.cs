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
    public class EditorialBLL
    {
        private BookDAL bookDAL = new BookDAL();
        private EditorialDAL editorialDAL = new EditorialDAL();
        
        public async Task<ResponseMODEL> InsertAsync(EditorialMODEL model)
        {
            try
            {
                Editorial modelDAL = new Editorial();
                modelDAL.Email = model.Email;
                modelDAL.CorrespondenceAddress = model.CorrespondenceAddress;
                modelDAL.Phone = model.Phone;
                modelDAL.Name = model.Name;
                modelDAL.MaximumBooksRegistered = model.MaximumBooksRegistered;
                modelDAL.IdEditorial = model.IdEditorial;

                return await editorialDAL.InsertAsync(modelDAL);
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Controlado", "Se controlo un error en la aplicacion.", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> UpdateAsync(EditorialMODEL model)
        {
            try
            {
                Editorial modelDAL = new Editorial();
                modelDAL.Email = model.Email;
                modelDAL.CorrespondenceAddress = model.CorrespondenceAddress;
                modelDAL.Phone = model.Phone;
                modelDAL.Name = model.Name;
                modelDAL.MaximumBooksRegistered = model.MaximumBooksRegistered;
                modelDAL.IdEditorial = model.IdEditorial;

                return await editorialDAL.UpdateAsync(modelDAL);
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
                var resultProcess = await editorialDAL.GetAllAsync();
                if (resultProcess.IsApproved)
                {
                    List<Editorial> result = (List<Editorial>)resultProcess.ObjectResult;
                    if (result.Count == 0)
                    {
                        return ResponseMODEL.Instance(true, "Consulta Exitosa", "Lista Vacia", "La tabla \"Editorial\" esta vacia", result);
                    }
                    else
                    {
                        var resultList = result.Select(i => new EditorialMODEL
                        {
                            Email = i.Email,
                            CorrespondenceAddress = i.CorrespondenceAddress,
                            Phone = i.Phone,
                            Name = i.Name,
                            MaximumBooksRegistered = i.MaximumBooksRegistered,
                            IdEditorial = i.IdEditorial
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
                var resultProcess = await editorialDAL.GetAsync(id);
                if (resultProcess.IsApproved)
                {
                    Editorial result = (Editorial)resultProcess.ObjectResult;
                    if (result == null)
                    {
                        return ResponseMODEL.Instance(true, "Consulta Exitosa", "Sin resultados", "No existen coincidencias con para esta consulta", result);
                    }
                    else
                    {
                        EditorialMODEL resultObject = new EditorialMODEL
                        {
                            Email = result.Email,
                            CorrespondenceAddress = result.CorrespondenceAddress,
                            Phone = result.Phone,
                            Name = result.Name,
                            MaximumBooksRegistered = result.MaximumBooksRegistered,
                            IdEditorial = result.IdEditorial
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
                var resultProcess = await editorialDAL.GetAsync(id);
                var validateBooks = await bookDAL.GetByIdEditorialAsync(id);

                if(!validateBooks.IsApproved)
                {
                    return resultProcess;
                }

                if(((List<Book>)validateBooks.ObjectResult).Count > 0)
                {
                    return ResponseMODEL.Instance(false, "Transaccion Rechazada", "Editorial con libros activos", "No puede eliminar una editorial si tiene libros activos");
                }

                if (resultProcess.IsApproved)
                {
                    if ((Editorial)resultProcess.ObjectResult != null)
                    {
                        return await editorialDAL.DeleteAsync((Editorial)resultProcess.ObjectResult);
                    }
                    else
                    {
                        return ResponseMODEL.Instance(false, "Transaccion Rechazada", "No es posible eliminar la editorial", "No existe una editorial que coincida con el codigo enviado");
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
