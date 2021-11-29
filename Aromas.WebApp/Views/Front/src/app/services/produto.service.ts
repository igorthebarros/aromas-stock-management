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

  GetProductByInStock(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/Product/GetProductByIsInStock/{isInStock}`);
  }

  create(product: Product): Observable<Product>{
    return this.http.post<Product>(`${this.baseUrl}/Product/Create`, product);
  }

  delete(id: number): Observable<Product> {
    return this.http.delete<Product>(`${this.baseUrl}/Product/Delete/${id}`);
  }

  searchId(id: string): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}/Product/${id}`);
  }
  
  update(product: Product): Observable<Product>{
    return this.http.put<Product>(`${this.baseUrl}/Product/Edit`, product);
  }
}
