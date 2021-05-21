import { Component, OnInit } from '@angular/core';
import { BookService } from './book.service';
import { Book } from './book.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styles: []
})
export class BookComponent implements OnInit {

  constructor(public service: BookService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.service.getListAuthor();
    this.service.getListEditorial();
  }

  populateForm(selectedRecord: Book) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('¿Esta seguro de eliminar este ejemplar?')) {
      this.service.deleteBook(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.success("Eliminacion Extiosa", 'BIBLIOTECA');
          },
          err => { 
            this.toastr.error(err, 'ERROR')
            console.log(err) 
          }
        )
    }
  }

}
