import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomephotosComponent } from './homephotos.component';

describe('HomephotosComponent', () => {
  let component: HomephotosComponent;
  let fixture: ComponentFixture<HomephotosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomephotosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomephotosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
