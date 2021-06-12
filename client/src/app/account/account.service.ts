import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUser } from '../shared/model/user';
import { map, tap } from 'rxjs/operators';
import { IResponse } from '../shared/model/response';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  loadCurrentUser(token: string) {
    if (token == null) {
      this.currentUserSource.next(null!);
      return of(null!);
    }

    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<IResponse<IUser>>(this.baseUrl + 'auth', {headers}).pipe(
      map(response => {
        if(response.data) {
          localStorage.setItem('token', response.data.token);
          this.currentUserSource.next(response.data);
          console.log('you next a data :' +response.data);
        }
      })
    )
  }

  login(values: any) {
    // let headers = new HttpHeaders();
    // headers = headers.set('Content-Type', 'application/json');
    // headers = headers.set('Accept', 'application/json');
    return this.http.post<IResponse<IUser>>(this.baseUrl + 'auth/login', values).pipe(
      map((response) => {
        if (response.data) {
          localStorage.setItem('token', response.data.token);
          this.currentUserSource.next(response.data);
          console.log('you next a data ↓');
          console.log(response);
        }
      })
    )
  }

  register(values: any) {
    return this.http.post<IResponse<IUser>>(this.baseUrl + 'auth/register', values).pipe(
      map((response) => {
        if (response.data) {
          localStorage.setItem('token', response.data.token);
          this.currentUserSource.next(response.data);
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null!);
    this.router.navigateByUrl('/');
  }

}
