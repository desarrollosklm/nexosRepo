import { Injectable } from '@angular/core';
import { Book } from './book.model';
import { HttpClient } from "@angular/common/http";
import { Author } from '../author/author.model';
import { Editorial } from '../editorial/editorial.model';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient,
    private toastr: ToastrService) { }

  readonly baseURL = 'https://localhost:44368/api/Book'
  readonly baseURLAuthor = 'https://localhost:44368/api/Author'
  readonly baseURLEditorial = 'https://localhost:44368/api/Editorial'

  formData:Book = new Book();
  list: Book[];
  listAuthor: Author[];
  listEditorial: Editorial[];
  
  postBook() {
    return this.http.post(this.baseURL, this.formData);
  }

  putBook() {
    return this.http.put(`${this.baseURL}/${this.formData.idBook}`, this.formData);
  }

  deleteBook(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
  getListAuthor() {
    this.http.get(this.baseURLAuthor)
      .toPromise()
      .then(res =>this.listAuthor = res as Author[]);
  }

  getListEditorial() {
    this.http.get(this.baseURLEditorial)
      .toPromise()
      .then(res =>this.listEditorial = res as Editorial[]);
  }


  async refreshList() {
    this.list = undefined;
    try
    {
      const response = await this.http.get(this.baseURL, { observe: 'response' }).toPromise()
      .then(
        res => 
        {
         if(res.status == 204)
         {
          this.toastr.info("La petición se ha completado con éxito pero su respuesta no tiene ningún contenido", 'SIN CONTENIDO')
         }

         if(res.status == 200)
         {
           this.list = res.body as Book[]
         }
        });
    }catch(error)
    {
      if(error.status == 500)
      {
        this.toastr.error("Error Interno del Servidor", 'ERROR')
      }else{
        this.toastr.error(error.errror, 'ERROR')
      }
      console.log(error) 
    }
  }

}
