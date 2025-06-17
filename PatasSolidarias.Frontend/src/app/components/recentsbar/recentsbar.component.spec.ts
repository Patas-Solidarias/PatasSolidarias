import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentsbarComponent } from './recentsbar.component';

describe('RecentsbarComponent', () => {
  let component: RecentsbarComponent;
  let fixture: ComponentFixture<RecentsbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecentsbarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecentsbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
