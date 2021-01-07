import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {User} from './UserInputDetails';
import {UserMessages} from './UserDetailsAndMessages';
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

  GetLogOnAttempt(user: User): Observable<UserMessages>{
    const geturl = `${this.url}?/username=${user.Username}&password=${user.password}`
    return this.http.get<UserMessages>(geturl)
    .pipe(
      catchError(this.handleError<UserMessages>('GetLogOnAttempt'))
    );
  }

  PostLogOnAttempt(user: User): Observable<UserMessages>{
    user.IsSuccess = true;
    user.UserId = 1;
    return this.http.post<User>(this.url, user, this.httpOptions).pipe(
      catchError(this.handleError<UserMessages>('PostLogOnAttempt'))
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
