import
{
  MatAutocompleteModule,
  MatButtonModule,
  MatCardModule,
  MatChipsModule,
  MatDialogModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatPaginatorModule,
  MatSelectModule,
  MatRadioModule,
  MatSidenavModule,
  MatSortModule,
  MatTableModule,
  MatToolbarModule
}
from '@angular/material';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule, /* other http imports */ } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { from } from 'rxjs';
import { UsersService } from './services/users.service';
import { BaseService } from './services/base.service';

const appRoutes: Routes = [
  { path: '', component: UsersComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatAutocompleteModule,
  MatButtonModule,
  MatCardModule,
  MatChipsModule,
  MatDialogModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatPaginatorModule,
  MatSelectModule,
  MatRadioModule,
  MatSidenavModule,
  MatSortModule,
  MatTableModule,
  MatToolbarModule

  ],
  providers: [
    UsersService,
    BaseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

