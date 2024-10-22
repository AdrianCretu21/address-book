import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IAddressBook, IAddressListBook } from "../models/IAddressBook";

@Injectable()
export class AddressBookService {
  constructor(private httpClient: HttpClient) { }

  getAddressBooks() {
    return this.httpClient.get<IAddressListBook[]>('/api/AddressBook/GetAddresses');
  }
  getAddressBookDetails(id: number) {
    return this.httpClient.get<IAddressBook>(`/api/AddressBook/GetAddressBookDetails?id=${id}`);
  }
}
