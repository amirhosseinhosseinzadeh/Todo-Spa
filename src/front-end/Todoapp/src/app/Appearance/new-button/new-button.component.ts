import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button'

@Component({
  selector: 'new-button',
  standalone: true,
  imports: [ButtonModule],
  template: `
    <p-button icon="pi pi-plus" size="large" [rounded]="true" />
  `,
})
export class NewButtonComponent {

}
