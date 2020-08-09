import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TextMatcherComponent } from './text-matcher.component';

describe('TextMatcherComponent', () =>
{
  let component: TextMatcherComponent;
  let fixture: ComponentFixture<TextMatcherComponent>;

  beforeEach(async(() =>
  {
    TestBed.configureTestingModule({
      declarations: [TextMatcherComponent]
    })
      .compileComponents();
  }));

  beforeEach(() =>
  {
    fixture = TestBed.createComponent(TextMatcherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should display a title', async(() =>
  {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Counter');
  }));

  it('should start with count 0, then increments by 1 when clicked', async(() =>
  {
    const countElement = fixture.nativeElement.querySelector('strong');
    expect(countElement.textContent).toEqual('0');

    const incrementButton = fixture.nativeElement.querySelector('button');
    incrementButton.click();
    fixture.detectChanges();
    expect(countElement.textContent).toEqual('1');
  }));
});
