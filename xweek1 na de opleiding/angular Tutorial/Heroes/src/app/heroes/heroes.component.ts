import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { HeroService } from '../hero.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.scss']
})

export class HeroesComponent implements OnInit {
  
 
heroes:Hero[];

selectedHero: Hero;

  constructor( private heroesService:HeroService) { 

  }

  getHeroes():void{
    this.heroesService.getHeroes().subscribe(iets=>this.heroes=iets); //asynchroon laden omdat het een remote server is
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.heroesService.addHero({ name } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }
  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroesService.deleteHero(hero).subscribe();
  }
  ngOnInit() {
    this.getHeroes();
    console.log(this.heroes);
  }

}


