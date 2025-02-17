import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllUsersCompComponent } from './get-all-users-comp.component';

describe('GetAllUsersCompComponent', () => {
  let component: GetAllUsersCompComponent;
  let fixture: ComponentFixture<GetAllUsersCompComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetAllUsersCompComponent]
    });
    fixture = TestBed.createComponent(GetAllUsersCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
