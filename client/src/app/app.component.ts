import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { FooterComponent } from "./layout/footer/footer.component";
import { ShopComponent } from "./features/shop/shop.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent, ShopComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'SkiCommerce';
}
