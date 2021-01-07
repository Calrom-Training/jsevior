import { Component, OnInit } from '@angular/core';
import { User} from '../UserInputDetails';
import { UserMessages } from '../UserDetailsAndMessages';
import { LogOnService } from '../log-on.service';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  user : User = {Username:"Username", password:"Password", IsSuccess: true, UserId: 1};


  constructor(private logonService: LogOnService) {

  }

  postlogon(userdetails: User): Observable<UserMessages>{
    return this.logonService.PostLogOnAttempt(userdetails);
  }

  getlogon(userdetails: User): Observable<UserMessages>{
        return this.logonService.GetLogOnAttempt(userdetails);
  }


  ngOnInit(): void {
    let postbtn = document.getElementById("Loginwithpost");
    let getbtn = document.getElementById("Loginwithget");
    postbtn.addEventListener("click", (e:Event) => this.postlogon(this.user));
    getbtn.addEventListener("click", (e:Event) => this.getlogon(this.user));
  }

}
