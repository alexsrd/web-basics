import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dog } from './dog';

@Injectable({
  providedIn: 'root'
})
export class DogService {

  constructor(private http: HttpClient) { }
  url: string = "api/dog";

  get(): Observable<Dog[]> {
    return this.http.get<Dog[]>(this.url);
  }

  create(dog) {
    return this.http.post(this.url+'/create', dog);
  }
}
