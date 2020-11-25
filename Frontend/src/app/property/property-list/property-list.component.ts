import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {

  properties: Array<any> = [
    {
    "Id" : 1,
    "Name" : "A House",
    "Type" : "House",
    "Price" : 12000
    },

    {
      "Id" : 2,
      "Name" : "B House",
      "Type" : "House",
      "Price" : 12000
    },

    {
      "Id" : 3,
      "Name" : "C House",
      "Type" : "House",
      "Price" : 12000
    },

    {
      "Id" : 4,
      "Name" : "D House",
      "Type" : "House",
      "Price" : 12000
    }
];

  constructor() { }

  ngOnInit(): void {
  }

}
