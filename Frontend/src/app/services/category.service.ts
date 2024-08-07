import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { SubCategory } from '../models/subcategory';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private apiUrl = 'http://localhost:5050/api/category';

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  getSubCategories(categoryName: string): Observable<SubCategory[]> {
    return this.http.get<SubCategory[]>(`${this.apiUrl}/${categoryName}/SubCategories`);
  }
}
