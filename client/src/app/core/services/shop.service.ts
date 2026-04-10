import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';
import { ShopParameters } from '../../shared/models/shopParameters';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  private http = inject(HttpClient);
  types: string[] = [];
  brands: string[] = [];

  getProducts(shopParameters: ShopParameters) {
    let params = new HttpParams();

    if (shopParameters.brands.length > 0) {
      params = params.append('brands', shopParameters.brands.join(','));
    }

    if (shopParameters.types.length > 0) {
      params = params.append('types', shopParameters.types.join(','));
    }

    if (shopParameters.sort) {
      params = params.append('sort', shopParameters.sort);
    }

    if (shopParameters.search) {
      params = params.append('search', shopParameters.search);
    }

    params = params.append('pageSize', shopParameters.pageSize);
    params = params.append('pageIndex', shopParameters.pageIndex);
    
    return this.http.get<Pagination<Product>>(this.baseUrl + 'products', {params});
  }

  getProduct(id: number) {
    return this.http.get<Product>(this.baseUrl + 'products/' + id);
  }

  getBrands() {
    if (this.brands.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'products/brands').subscribe({
      next: response => this.brands = response
    });
  }

  getTypes() {
    if (this.types.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'products/types').subscribe({
      next: response => this.types = response
    });
  }
}
