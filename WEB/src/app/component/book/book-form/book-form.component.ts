import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Book } from 'src/app/component/book/book.model';
import { BookService } from 'src/app/component/book/book.service';
import { Author } from '../../author/author.model';
import { AuthorService } from '../../author/author.service';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styles: []
})
export class BookFormComponent implements OnInit {


  constructor(public service: BookService,
    private toastr: ToastrService) { }

    

  ngOnInit(): void {
    
  }

  onSubmit(form: NgForm) {
    
    if (this.service.formData.idBook == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postBook().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Registro Creado', 'BIBLIOTECA')
      },
      err => { 
        if(err.error.text == "Exitoso")
        {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Registro Creado', 'BIBLIOTECA')
        }else{
          this.toastr.error(err.error, 'ERROR')
          console.log(err); 
        }
      }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putBook().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Modificacion Exitosa', 'BIBLIOTECA')
      },
      err => { 
        if(err.error.text == "Exitoso")
        {
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Registro Modificado', 'BIBLIOTECA')
        }else{
          this.toastr.error(err.error, 'ERROR')
          console.log(err); 
        }
      }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Book();
  }

}
