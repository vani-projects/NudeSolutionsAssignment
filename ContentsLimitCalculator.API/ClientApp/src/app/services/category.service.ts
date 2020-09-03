import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category} from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private http: HttpClient) { }

  getCategories():Observable<Category[]> {
    return this.http.get<Category[]>('https://localhost:44399/api/categories');
  }

  getCategoryById(categoryId: number): Observable<Category> {
    return this.http.get<Category>('https://localhost:44399/api/categories/' + categoryId);
  }
}
