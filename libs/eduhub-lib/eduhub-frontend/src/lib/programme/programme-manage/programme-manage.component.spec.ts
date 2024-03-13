import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProgrammeManageComponent } from './programme-manage.component';

describe('ProgrammeManageComponent', () => {
  let component: ProgrammeManageComponent;
  let fixture: ComponentFixture<ProgrammeManageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProgrammeManageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ProgrammeManageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
