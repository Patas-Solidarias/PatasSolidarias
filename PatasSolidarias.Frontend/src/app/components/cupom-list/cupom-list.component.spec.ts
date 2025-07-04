import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CupomListComponent } from './cupom-list.component';

describe('CupomListComponent', () => {
  let component: CupomListComponent;
  let fixture: ComponentFixture<CupomListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CupomListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CupomListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
