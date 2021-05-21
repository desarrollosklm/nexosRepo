import { Injectable } from '@angular/core';
import { Editorial } from './editorial.model';
import { HttpClient } from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class EditorialService {

  constructor(private http: HttpClient,
    private toastr: ToastrService) { }

  readonly baseURL = 'https://localhost:44368/api/Editorial'

  formData:Editorial = new Editorial();
  list: Editorial[];

  postEditorial() {
    return this.http.post(this.baseURL, this.formData);
  }

  putEditorial() {
    return this.http.put(`${this.baseURL}/${this.formData.idEditorial}`, this.formData);
  }

  deleteEditorial(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
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
           this.list = res.body as Editorial[]
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
