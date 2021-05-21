import { Directive, ElementRef, HostListener } from "@angular/core";
import { NgControl } from "@angular/forms";

@Directive({
  selector: '[lowercase]'
})
export class LowerCaseDirective{

  constructor(private el: ElementRef, private control : NgControl) {

  }

  @HostListener('input',['$event']) onEvent($event){
    console.log($event);
    let lower = this.el.nativeElement.value.toLowerCase();
    this.control.control.setValue(lower);

  }

}