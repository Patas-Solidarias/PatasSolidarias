import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardOngComponent } from './card-ong.component';

describe('CardOngComponent', () => {
  let component: CardOngComponent;
  let fixture: ComponentFixture<CardOngComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardOngComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardOngComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
