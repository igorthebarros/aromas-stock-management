import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private baseUrl = "https://localhost:5000/api";

  constructor(private http: HttpClient) { }

  list(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/Product`);
  }

  create(product: Product): Observable<Product>{
    return this.http.post<Product>(`${this.baseUrl}/Product/Create`, product);
  }
}
