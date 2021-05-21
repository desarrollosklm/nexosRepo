import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Editorial } from '../editorial.model';
import { EditorialService } from '../editorial.service';

@Component({
  selector: 'app-editorial-form',
  templateUrl: './editorial-form.component.html',
  styles: []
})
export class EditorialFormComponent implements OnInit {

  constructor(public service: EditorialService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    
    if (this.service.formData.idEditorial == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postEditorial().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Registro Creado', 'EDITORIAL')
      },
      err => { 
        this.toastr.error('Error Creando Registro', 'ERROR')
        console.log(err); 
      }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putEditorial().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Modificacion Exitosa', 'EDITORIAL')
      },
      err => { 
        this.toastr.error('Error Modificando Registro', 'ERROR')
        console.log(err); 
      }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Editorial();
  }

}
