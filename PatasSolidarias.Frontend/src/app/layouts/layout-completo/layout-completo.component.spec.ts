import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutCompletoComponent } from './layout-completo.component';

describe('LayoutCompletoComponent', () => {
  let component: LayoutCompletoComponent;
  let fixture: ComponentFixture<LayoutCompletoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LayoutCompletoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LayoutCompletoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
