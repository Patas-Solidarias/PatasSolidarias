import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardOngListComponent } from './card-ong-list.component';

describe('CardOngListComponent', () => {
  let component: CardOngListComponent;
  let fixture: ComponentFixture<CardOngListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardOngListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardOngListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
