import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IAddressBook, IAddressListBook } from '../models/IAddressBook';
import { AddressBookService } from '../services/AddressBookService';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  addressBooks: IAddressListBook[] | undefined;
  errorOccured = false;
  constructor(private addressBookService: AddressBookService) { }

  ngOnInit() {
    this.errorOccured = false;
    this.addressBookService.getAddressBooks().pipe(catchError(err => {
      this.errorOccured = true;
      return of(null);
    })).subscribe(addresses => {
      if (addresses) {
        this.addressBooks = addresses;
      }
    })
  }


  title = 'addressbook.client';
}
