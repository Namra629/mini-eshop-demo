import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from './api.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {

  api = inject(ApiService);
  products: any[] = [];

  loadProducts() {
    this.api.getProducts().subscribe((res: any) => {
      this.products = res;
    });
  }

  buyProduct(product: any) {
  this.api.buyProduct(product).subscribe({
    next: (res) => {
      console.log('Order success:', res);
      alert(`Order placed for ${product.name}`);
    },
    error: (err) => {
      console.error('Order failed:', err);
      alert('Order failed!');
    }
  });
}
}
