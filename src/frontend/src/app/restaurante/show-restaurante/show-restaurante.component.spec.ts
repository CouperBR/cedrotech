import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowRestauranteComponent } from './show-restaurante.component';

describe('ShowRestauranteComponent', () => {
  let component: ShowRestauranteComponent;
  let fixture: ComponentFixture<ShowRestauranteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowRestauranteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowRestauranteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
