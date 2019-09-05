import { Component } from '@angular/core';
import { ConsultantsService } from './services/consultants.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'client';

  constructor() { }

  ngOnInit() {
  }
}

