import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarAddComponent } from './sidebar-add.component';

describe('SidebarAddComponent', () => {
  let component: SidebarAddComponent;
  let fixture: ComponentFixture<SidebarAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarAddComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SidebarAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
