import { Directive, ElementRef, HostListener } from "@angular/core";
import { NgControl } from "@angular/forms";

@Directive({
  selector: '[uppercase]'
})
export class UpperCaseDirective{

  constructor(private el: ElementRef, private control : NgControl) {

  }

  @HostListener('input',['$event']) onEvent($event){
    console.log($event);
    let upper = this.el.nativeElement.value.toUpperCase();
    this.control.control.setValue(upper);

  }

}