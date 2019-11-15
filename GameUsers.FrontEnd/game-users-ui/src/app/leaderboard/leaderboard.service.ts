import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ApiBasePathService } from '../core/api-base-path.service';
import { LeaderboardEntry } from '../model/leaderboard-entry';


@Injectable({
    providedIn: 'root'
  })
  export class LeaderBoardService {
    private apiUrl: string;

    constructor(private http: HttpClient, basePathService: ApiBasePathService) {
        this.apiUrl = `${basePathService.getApiBasePath()}/${
            'leaderboard'
        }`;
    }

    getLeaderboard(): Observable<LeaderboardEntry []> {
        return this.http.get<LeaderboardEntry []>(this.apiUrl)
          .pipe(
            tap(data => console.log('All: ' + JSON.stringify(data))),
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
