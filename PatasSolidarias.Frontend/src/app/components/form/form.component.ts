import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-form',
  imports: [],
  template: `<p>form works!</p>`,
  styleUrl: './form.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FormComponent { }
