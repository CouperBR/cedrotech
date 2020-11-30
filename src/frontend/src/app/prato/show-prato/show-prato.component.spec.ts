import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPratoComponent } from './show-prato.component';

describe('ShowPratoComponent', () => {
  let component: ShowPratoComponent;
  let fixture: ComponentFixture<ShowPratoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPratoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPratoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
