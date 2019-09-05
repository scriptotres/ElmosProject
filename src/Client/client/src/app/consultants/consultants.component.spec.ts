import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConusltantsComponent } from './conusltants.component';

describe('ConusltantsComponent', () => {
  let component: ConusltantsComponent;
  let fixture: ComponentFixture<ConusltantsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConusltantsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConusltantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
