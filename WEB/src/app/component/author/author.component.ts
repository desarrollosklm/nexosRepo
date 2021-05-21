import { Component, OnInit } from '@angular/core';
import { AuthorService } from './author.service';
import { Author } from './author.model';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styles: []
})
export class AuthorComponent implements OnInit {

  constructor(public service: AuthorService,
    private toastr: ToastrService,
    private datePipe: DatePipe) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Author) {
    this.service.formData = Object.assign({}, selectedRecord);
    this.service.formData.birthDate = this.datePipe.transform(this.service.formData.birthDate,"yyyy-MM-dd");
    
  }

  onDelete(id: number) {
    if (confirm('¿Esta seguro de eliminar este autor?')) {
      this.service.deleteAuthor(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.success("Eliminacion Extiosa", 'AUTOR');
          },
          err => { 
            this.toastr.error(err.error, 'ERROR')
            console.log(err) 
          }
        )
    }
  }

}
