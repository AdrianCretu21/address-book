import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddressBookService } from '@services/AddressBookService';
import { AddressBookListComponent } from './addressBook-list/addressBook-list.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, AddressBookListComponent
  ],
  providers: [AddressBookService],
  bootstrap: [AppComponent]
})
export class AppModule { }
