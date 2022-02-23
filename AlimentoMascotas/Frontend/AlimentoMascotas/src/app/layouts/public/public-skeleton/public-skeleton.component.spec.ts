import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicSkeletonComponent } from './public-skeleton.component';

describe('PublicSkeletonComponent', () => {
  let component: PublicSkeletonComponent;
  let fixture: ComponentFixture<PublicSkeletonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublicSkeletonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PublicSkeletonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
