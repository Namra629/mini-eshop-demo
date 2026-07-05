import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = '/api';

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get(`${this.baseUrl}/products`);
  }

  buyProduct(product: any) {
    return this.http.post(`${this.baseUrl}/orders`, {
      productId: product.id,
      quantity: 1
    });
  }
}
