import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '@mcloots/ui';
import { initFlowbite } from 'flowbite';

@Component({
  standalone: true,
  imports: [RouterModule, NavbarComponent],
  selector: 'mcloots-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title = 'it-bachelors-thomasmore-geel';

  ngOnInit(): void {
    initFlowbite();
  }
}
