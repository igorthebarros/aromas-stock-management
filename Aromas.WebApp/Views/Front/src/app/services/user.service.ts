import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = "https://localhost:5000/api";

  constructor(private http: HttpClient) { }

  register(user: User): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}/User/Create`, user);
  } 

  list(): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseUrl}/User`);
  }

  delete(id: number): Observable<User[]> {
    return this.http.delete<User[]>(`${this.baseUrl}/User/Delete/${id}`);
  }

  searchId(id: number): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseUrl}/User/${id}`);
  }
  
  update(user: User): Observable<User> {
    return this.http.put<User>(`${this.baseUrl}/User/Edit`, user);
  }
}
