import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MainPageComponent } from './main-page/main-page.component';
import { MessagesComponent } from './messages/messages.component';
import { UserComponent } from './user/user.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    MessagesComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
