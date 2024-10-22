import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { IAddressBook, IAddressListBook } from "../../../models/IAddressBook";
import { LeafletModule } from '@asymmetrik/ngx-leaflet';
import { latLng, tileLayer, marker, icon, Icon  } from "leaflet";
import * as L from "leaflet";
import { AddressBookService } from "@services/AddressBookService";
import { catchError, of } from "rxjs";

@Component({
  selector: 'addressBook-item-details',
  standalone: true,
  templateUrl: 'addressBook-item-details.html',
  styleUrl: 'addressBook-item-details.css',
  imports: [LeafletModule],
  providers: [AddressBookService]
})
export class AddressBookItemDetailsComponent implements OnInit {
  @Input() selectedAddress!: IAddressListBook;
  @Output() visibilityChange = new EventEmitter();
  
  currentData: IAddressBook | undefined;
  errorOccured = false;

  locationLayer: any[] = [];
  map!: L.Map;
  options = {
    layers: [
      tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 18, attribution: '...' })
    ],
    zoom: 8,
    center: latLng(46.879966, -121.726909)
  };

  constructor(private addressBookService: AddressBookService) { }

  onMapReady(map: L.Map) {
    this.map = map;
  }
  ngOnInit() {
    this.addressBookService.getAddressBookDetails(this.selectedAddress.id).pipe(catchError(err => {
      this.errorOccured = true;
      return of(null);
    })).subscribe(res => {
      if (res) {
        this.currentData = res;
        this.map.panTo(latLng(this.currentData.locationLat, this.currentData.locationLon));
        this.locationLayer = [
          marker([this.currentData.locationLat, this.currentData.locationLon], {
            icon: icon({
              ...Icon.Default.prototype.options,
              iconUrl: 'images/marker-icon.png',
              iconRetinaUrl: 'images/marker-icon-2x.png',
              shadowUrl: 'images/marker-shadow.png'
            })
          })
        ];
      }
    });
    
  }
  closeModal() {
    this.visibilityChange.emit();
  }
}
