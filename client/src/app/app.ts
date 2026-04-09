import { Component, OnInit } from '@angular/core';
import { Header } from "./layout/header/header";
import { Shop } from "./features/shop/shop";

@Component({
  selector: 'app-root',
  imports: [Header, Shop],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  title = 'Skinet';
}
