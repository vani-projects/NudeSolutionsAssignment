import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Item} from '../models/item.model'
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  constructor(private http: HttpClient) { }

  postItem(item: Item): Observable<Item> {
    return this.http.post<Item>('https://localhost:44399/api/items',item);  
  }
  
  DeleteItem(id): Observable<{}> {
    return this.http.delete('https://localhost:44399/api/items/' + id);
  }
}
