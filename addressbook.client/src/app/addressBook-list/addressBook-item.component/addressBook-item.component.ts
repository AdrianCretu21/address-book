import { Component, Input, input, output } from "@angular/core";
import { IAddressBook, IAddressListBook } from "@models/IAddressBook";

@Component({
  selector: 'addressBook-item',
  standalone: true,
  templateUrl: 'addressBook-item.component.html',
  styleUrl: 'addressBook-item.component.css',
})
export class AddressBookItemComponent {
  @Input() address!: IAddressListBook;
}
