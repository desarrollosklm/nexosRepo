import { Component } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { BookComponent  } from "./component/book/book.component";
import { AuthorComponent  } from "./component/author/author.component";
import { EditorialComponent  } from "./component/editorial/editorial.component";
import { HomeComponent  } from "./component/home/home.component";

const APP_ROUTES: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'book', component: BookComponent },
    { path: 'autor', component: AuthorComponent },
    { path: 'editorial', component: EditorialComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);
