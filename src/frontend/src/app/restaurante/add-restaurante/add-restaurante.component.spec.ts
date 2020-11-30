import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRestauranteComponent } from './add-restaurante.component';

describe('AddRestauranteComponent', () => {
  let component: AddRestauranteComponent;
  let fixture: ComponentFixture<AddRestauranteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRestauranteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRestauranteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should defined", () => {
    expect(component.id).toBeDefined();
  });

  it("should defined", () => {
    expect(component.id).toBeDefined();
  });
});
