import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {UserInputDetails} from './UserInputDetails';
import {UserDetailsAndMessages} from './UserDetailsAndMessages';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LogOnService {
  private url = 'localhost:44388/Database'
  httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

  GetLogOnAttempt(user: UserInputDetails): Observable<UserDetailsAndMessages>{
    const geturl = `${this.url}?/username=${user.username}&password=${user.password}`
    return this.http.get<UserDetailsAndMessages>(geturl)
    .pipe(
      catchError(this.handleError<UserDetailsAndMessages>('GetLogOnAttempt'))
    );
  }

  PostLogOnAttempt(user: UserInputDetails): Observable<UserDetailsAndMessages>{
    user.IsSuccess = true;
    user.UserId = 1;
    return this.http.post<UserInputDetails>(this.url, user, this.httpOptions).pipe(
      catchError(this.handleError<UserDetailsAndMessages>('PostLogOnAttempt'))
    );
  }
  private handleError<T>(operation = 'operation', result?: T) {
   return (error: any): Observable<T> => {
   console.error(error);
   return of(result as T);
   };
 }

  constructor(private http: HttpClient) { }
}
