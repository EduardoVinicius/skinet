import { Component, inject } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { CartItemComponent } from "./cart-item/cart-item";
import { OrderSummary } from "../../shared/components/order-summary/order-summary";

@Component({
  selector: 'app-cart',
  imports: [CartItemComponent, OrderSummary],
  templateUrl: './cart.html',
  styleUrl: './cart.css',
})
export class Cart {
  cartService = inject(CartService);
}
