import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Observer, ReplaySubject, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Hero, HeroCreate } from '../model/hero';

@Injectable({
  providedIn: 'root',
})
export class HerosService {
  private baseUrl = environment.apiUrl;
  private herosData: Hero[] = [];
  private heros = new ReplaySubject<Hero[]>(1);
  heros$ = this.heros.asObservable();

  loadHeros() {
    const url = this.baseUrl + 'heros';
    this.http.get<Hero[]>(url).subscribe((res) => {
      this.herosData = res;
      this.heros.next(this.herosData);
    });
  }
  addHero(hero: HeroCreate): Observable<void> {
    const url = this.baseUrl + 'heros';
    return this.http.post<Hero>(url, hero).pipe(
      map((res) => {
        if (res) {
          this.herosData.push(res);
          this.herosData = this.herosData.sort(
            (a, b) => a.curetPower - b.curetPower
          );
          this.heros.next(this.herosData);
        }
      })
    );
  }

  trainHero(heroId: string): void {
    const url = this.baseUrl + 'heros/' + heroId;
    this.http.post<number>(url, {}).subscribe((res: number) => {
      const hero = this.herosData.find((x) => x.id === heroId);
      if (hero) {
        hero.curetPower = res;
        hero.trainedTodayTimes++;
        if (!hero.firstTraining) {
          hero.firstTraining = new Date();
        }
        this.herosData = this.herosData.sort(
          (a, b) => a.curetPower - b.curetPower
        );
        this.heros.next(this.herosData);
      }
    });
  }
  loadHero(): void {}
  constructor(private http: HttpClient) {}
}
