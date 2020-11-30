import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPratoComponent } from './add-prato.component';

describe('AddPratoComponent', () => {
  let component: AddPratoComponent;
  let fixture: ComponentFixture<AddPratoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPratoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPratoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
