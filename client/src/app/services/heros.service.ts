import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Hero } from '../model/hero';

@Injectable({
  providedIn: 'root',
})
export class HerosService {
  private baseUrl = environment.apiUrl;
  herosData: Hero[] = [];
  private heros = new ReplaySubject<Hero[]>(1);
  heros$ = this.heros.asObservable();

  loadHeros() {
    const url = this.baseUrl + 'heros';
    this.http.get<Hero[]>(url).subscribe((res) => {
      console.log(res);

      this.heros.next(res);
    });
  }
  loadHero() {}
  constructor(private http: HttpClient) {}
}
