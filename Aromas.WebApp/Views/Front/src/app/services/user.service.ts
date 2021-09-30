import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = "http://localhost:5000/api";

  constructor(private http: HttpClient) { }

  register(user: User): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}/User/Create`, user);
  } 

  list(): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseUrl}/User`);
  }

  delete(_id: string): Observable<User[]> {
    return this.http.delete<User[]>(`${this.baseUrl}/User/Delete/${_id}`);
  }
}
