import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminGetByIdCompComponent } from './admin-get-by-id-comp.component';

describe('AdminGetByIdCompComponent', () => {
  let component: AdminGetByIdCompComponent;
  let fixture: ComponentFixture<AdminGetByIdCompComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminGetByIdCompComponent]
    });
    fixture = TestBed.createComponent(AdminGetByIdCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
