import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'http://20.106.184.241:5000';

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get(`${this.baseUrl}/api/products`);
  }

  buyProduct(product: any) {
    return this.http.post(`${this.baseUrl}/api/orders`, product);
  }
}
