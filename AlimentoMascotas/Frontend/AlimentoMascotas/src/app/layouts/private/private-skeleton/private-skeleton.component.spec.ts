import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateSkeletonComponent } from './private-skeleton.component';

describe('PrivateSkeletonComponent', () => {
  let component: PrivateSkeletonComponent;
  let fixture: ComponentFixture<PrivateSkeletonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrivateSkeletonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrivateSkeletonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
