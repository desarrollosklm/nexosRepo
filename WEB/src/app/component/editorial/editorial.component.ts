import { Component, OnInit } from '@angular/core';
import { EditorialService } from './editorial.service';
import { Editorial } from './editorial.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-editorial',
  templateUrl: './editorial.component.html',
  styles: []
})
export class EditorialComponent implements OnInit {

  constructor(public service: EditorialService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Editorial) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('¿Esta seguro de eliminar esta casa editorial?')) {
      this.service.deleteEditorial(id)
        .subscribe(
          res => {
            debugger
            this.service.refreshList();
            this.toastr.success("Eliminacion Extiosa", 'EDITORIAL');
          },
          err => {
            this.toastr.error(err.error, 'ERROR')
            console.log(err) 
          }
        )
    }
  }

}
