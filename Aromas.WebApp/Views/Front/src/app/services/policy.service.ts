import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Policy } from '../models/policy';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

  private baseUrl = "https://localhost:5000/api";

  constructor(private http: HttpClient) { }
  
  list(): Observable<Policy[]>{
    return this.http.get<Policy[]>(`${this.baseUrl}/Policy`)
  }
  
  register(policy: Policy): Observable<Policy> {
    return this.http.post<Policy>(`${this.baseUrl}/Policy/Create`, policy);
  }

  delete(id: number): Observable<Policy> {
    return this.http.delete<Policy>(`${this.baseUrl}/Policy/Delete/${id}`);
  }

}
