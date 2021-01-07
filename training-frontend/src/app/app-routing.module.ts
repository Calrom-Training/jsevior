import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
import { MainpageComponent} from './mainpage/mainpage.component';
import { MessagesComponent} from './messages/messages.component';


const routes: Routes = [
  { path: 'user', component: UserComponent },
  { path: 'main', component: MainpageComponent },
  { path: '', redirectTo:'/main', pathMatch:'full'},
  { path: 'message', component: MessagesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
