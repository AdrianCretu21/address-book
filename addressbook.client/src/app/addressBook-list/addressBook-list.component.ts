import { Component, Input, input } from "@angular/core";
import { IAddressBook, IAddressListBook } from "@models/IAddressBook";
import { AddressBookService } from "@services/AddressBookService";
import { AddressBookItemComponent } from "./addressBook-item.component/addressBook-item.component";
import { AddressBookItemDetailsComponent } from "./addressBook-item-details/addressBook-item-details";

@Component({
  selector: 'addressBook-list',
  standalone: true,
  templateUrl: 'addressBook-list.component.html',
  imports: [AddressBookItemComponent, AddressBookItemDetailsComponent]
})
export class AddressBookListComponent {
  @Input() addressBooks: IAddressListBook[] = [];
  selectedAddressBook: IAddressListBook | undefined;

  openDetails(address: IAddressListBook) {
    this.selectedAddressBook = address;
  }
}
