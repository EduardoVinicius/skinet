import { Component, inject } from '@angular/core';
import { RouterLink } from "@angular/router";
import { MatButton } from "@angular/material/button";
import { MatFormField, MatLabel } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { CartService } from '../../../core/services/cart.service';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-order-summary',
  imports: [
    RouterLink,
    MatButton,
    MatFormField,
    MatLabel,
    MatInput,
    CurrencyPipe
  ],
  templateUrl: './order-summary.html',
  styleUrl: './order-summary.css',
})
export class OrderSummary {
  cartService = inject(CartService);
}
