import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Ipropertybase } from 'src/app/model/ipropertybase';

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.css']
})
export class PropertyCardComponent implements OnInit {

  @Input() property: Ipropertybase;
  @Input() hideIcons: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
