import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = "http://localhost:5001/";

  constructor(private http: HttpClient) { }

  register(user: User): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}user/create`, user);
  } 

  list(): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseUrl}user`);
  }

  delete(_id: string): Observable<User[]> {
    return this.http.delete<User[]>(`${this.baseUrl}delete/${_id}`);
  }
}
