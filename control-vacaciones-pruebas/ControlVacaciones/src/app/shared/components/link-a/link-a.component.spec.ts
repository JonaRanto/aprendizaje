import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LinkAComponent } from './link-a.component';

describe('LinkAComponent', () => {
  let component: LinkAComponent;
  let fixture: ComponentFixture<LinkAComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LinkAComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LinkAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
