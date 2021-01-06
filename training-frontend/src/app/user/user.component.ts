import { Component, OnInit } from '@angular/core';
import { UserInputDetails} from '../UserInputDetails';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  user : UserInputDetails ;

  constructor() { }

  ngOnInit(): void {
  }

}
