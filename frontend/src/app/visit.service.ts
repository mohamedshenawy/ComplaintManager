import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VisitService {
  private apiUrl = 'http://localhost:5221/api/Visit';
  constructor(private http: HttpClient) {}

  searchVisitByCustomerPhoneNumber(phoneNumber:string){
    return this.http.get<any>(`${this.apiUrl}?phoneNumber=${phoneNumber}`)
  }
}
