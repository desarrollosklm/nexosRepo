import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';

import { BookComponent } from './component/book/book.component';
import { BookFormComponent } from './component/book/book-form/book-form.component';

import { EditorialComponent } from './component/editorial/editorial.component';
import { EditorialFormComponent } from './component/editorial/editoria-form/editorial-form.component';

import { AuthorComponent } from './component/author/author.component';
import { AuthorFormComponent } from './component/author/author-form/author-form.component';

import { HttpClientModule } from '@angular/common/http';

import { APP_ROUTING  } from "./app.routes";
import { NavbarComponent } from './component/navbar/navbar.component';

import {DatePipe} from '@angular/common';
import { HomeComponent } from './component/home/home.component';

import { UpperCaseDirective } from './directive/uppercase.directive';
import { LowerCaseDirective } from './directive/lowercase.directive';

@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    BookFormComponent,
    EditorialComponent,
    EditorialFormComponent,
    AuthorComponent,
    AuthorFormComponent,
    NavbarComponent,
    HomeComponent,
    UpperCaseDirective,
    LowerCaseDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    APP_ROUTING
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
  
    
})
export class AppModule { }
