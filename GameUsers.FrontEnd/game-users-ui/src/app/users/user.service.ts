import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { User } from '../model/user';
import { ApiBasePathService } from '../core/api-base-path.service';


@Injectable({
    providedIn: 'root'
  })
  export class UserService {
    private readonly usersController: 'Users';
    private userUrl = 'api/users';
    private apiUrl: string;

    constructor(private http: HttpClient, basePathService: ApiBasePathService) {

        console.log(this.usersController);

        this.apiUrl = `${basePathService.getApiBasePath()}/${
            'users'
        }`;
    }

    getUsers(): Observable<User []> {
        return this.http.get<User []>(this.apiUrl)
          .pipe(
            tap(data => console.log('All: ' + JSON.stringify(data))),
            catchError(this.handleError)
          );
      }

      addUser(user: User) {

            const url = this.apiUrl + user.asPostString();

            return this.http.post(url, user.id);
      }

      updateUser(user: User) {
            const url = this.apiUrl + user.asPostString();
            return this.http.put(url, user.id);
      }

      getUser(id: number) {
        return this.http.get<User>(this.apiUrl + '/' + id)
          .pipe(
            tap(data => console.log('Result: ' + JSON.stringify(data))),
            catchError(this.handleError)
          );
      }

      private handleError(err: HttpErrorResponse) {
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
          errorMessage = `An error occurred: ${err.error.message}`;
        } else {
          errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
      }
  }
