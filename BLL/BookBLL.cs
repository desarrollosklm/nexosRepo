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
    public class BookBLL
    {
        private BookDAL bookDAL = new BookDAL();
        private EditorialDAL editorialDAL = new EditorialDAL();
        private AuthorDAL authorDAL = new AuthorDAL();
        public async Task<ResponseMODEL> InsertAsync(BookMODEL model)
        {
            try
            {
                var validateEditorial = await editorialDAL.GetAsync(model.IdEditorial);
                if (!validateEditorial.IsApproved)
                {
                    return validateEditorial;
                }

                Editorial editorial = (Editorial)validateEditorial.ObjectResult;

                if (editorial == null)
                {
                    return ResponseMODEL.Instance(false, "Transaction declined", "La editorial no está registrada", "Transaccion rechazada por regla de negocio");
                }

                var validateAuthor = await authorDAL.GetAsync(model.IdAuthor);
                if (!validateAuthor.IsApproved)
                {
                    return validateAuthor;
                }

                Author author = (Author)validateAuthor.ObjectResult;
                if (author == null)
                {
                    return ResponseMODEL.Instance(false, "Transaction declined", "El autor no está registrado", "Transaccion rechazada por regla de negocio");
                }

                var limit = editorial.MaximumBooksRegistered;
                var validateBooksEditorial = await bookDAL.GetByIdEditorialAsync(model.IdEditorial);
                if (validateBooksEditorial.IsApproved)
                {
                    List<Book> booksEditorial = (List<Book>)validateBooksEditorial.ObjectResult;
                    if (booksEditorial.Count < limit || limit == -1)
                    {
                        Book modelDAL = new Book();
                        modelDAL.Tittle = model.Tittle;
                        modelDAL.Year = model.Year;
                        modelDAL.NumberPages = model.NumberPages;
                        modelDAL.Gender = model.Gender;
                        modelDAL.IdAuthor = model.IdAuthor;
                        modelDAL.IdEditorial = model.IdEditorial;

                        return await bookDAL.InsertAsync(modelDAL);
                    }
                    else
                    {
                        return ResponseMODEL.Instance(false, "Transaction declined", "No es posible registrar el libro, se alcanzó el máximo permitido", "Transaccion rechazada por regla de negocio");
                    }
                }
                else
                {
                    return validateBooksEditorial;
                }
            }
            catch (Exception ex)
            {
                return ResponseMODEL.Instance(false, "Error Transaction", "Unregistered Book", ex.Message, ex);
            }
        }

        public async Task<ResponseMODEL> UpdateAsync(BookMODEL model)
        {
            try
            {
                var validateEditorial = await editorialDAL.GetAsync(model.IdEditorial);
                if (!validateEditorial.IsApproved)
                {
                    return validateEditorial;
                }

                Editorial editorial = (Editorial)validateEditorial.ObjectResult;

                if (editorial == null)
                {
                    return ResponseMODEL.Instance(false, "Transaccion Rechazada", "La editorial no está registrada", "Transaccion rechazada por regla de negocio");
                }

                var validateAuthor = await authorDAL.GetAsync(model.IdAuthor);
                if (!validateAuthor.IsApproved)
                {
                    return validateAuthor;
                }

                Author author = (Author)validateAuthor.ObjectResult;
                if (author == null)
                {
                    return ResponseMODEL.Instance(false, "Transaccion Rechazada", "El autor no está registrado", "Transaccion rechazada por regla de negocio");
                }

                var limit = editorial.MaximumBooksRegistered;
                var validateBooksEditorial = await bookDAL.GetByIdEditorialAsync(model.IdEditorial);
                if (validateBooksEditorial.IsApproved)
                {
                    List<Book> booksEditorial = (List<Book>)validateBooksEditorial.ObjectResult;
                    if (booksEditorial.Count < limit || limit == -1)
                    {
                        Book modelDAL = new Book();
                        modelDAL.IdBook = model.IdBook;
                        modelDAL.Tittle = model.Tittle;
                        modelDAL.Year = model.Year;
                        modelDAL.NumberPages = model.NumberPages;
                        modelDAL.Gender = model.Gender;
                        modelDAL.IdAuthor = model.IdAuthor;
                        modelDAL.IdEditorial = model.IdEditorial;

                        return await bookDAL.UpdateAsync(modelDAL);
                    }
                    else
                    {
                        return ResponseMODEL.Instance(false, "Transaccion Rechazada", "No es posible modificar el libro, se alcanzó el máximo permitido", "Transaccion rechazada por regla de negocio");
                    }
                }
                else
                {
                    return validateBooksEditorial;
                }
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
                var resultProcess = await bookDAL.GetAllAsync();
                if (resultProcess.IsApproved)
                {
                    List<Book> result = (List<Book>)resultProcess.ObjectResult;
                    if (result.Count == 0)
                    {
                        return ResponseMODEL.Instance(true, "Consulta Exitosa", "Lista Vacia", "La tabla \"Libros\" esta vacia", result);
                    }
                    else
                    {
                        var resultList = result.Select(i => new BookMODEL
                            {
                                IdBook = i.IdBook,
                                Gender = i.Gender,
                                IdAuthor = i.IdAuthor,
                                IdEditorial = i.IdEditorial,
                                NumberPages = i.NumberPages,
                                Tittle = i.Tittle,
                                Year = i.Year
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
                var resultProcess = await bookDAL.GetAsync(id);
                if (resultProcess.IsApproved)
                {
                    Book result = (Book)resultProcess.ObjectResult;
                    if (result == null)
                    {
                        return ResponseMODEL.Instance(true, "Consulta Exitosa", "Sin resultados", "No existen coincidencias con para esta consulta", result);
                    }
                    else
                    {
                        BookMODEL resultObject = new BookMODEL {
                            IdBook = result.IdBook,
                            Gender = result.Gender,
                            IdAuthor = result.IdAuthor,
                            IdEditorial = result.IdEditorial,
                            NumberPages = result.NumberPages,
                            Tittle = result.Tittle,
                            Year = result.Year
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
                var resultProcess = await bookDAL.GetAsync(id);
                if(resultProcess.IsApproved)
                {
                    if((Book)resultProcess.ObjectResult != null)
                    {
                        return await bookDAL.DeleteAsync((Book)resultProcess.ObjectResult);
                    }
                    else
                    {
                        return ResponseMODEL.Instance(false, "Transaccion Rechazada", "No es posible eliminar el libro", "No existe un libro que coincida con el codigo enviado");
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
