import { Component, inject, Input } from '@angular/core';
import { Product } from '../../../shared/models/product';
import { MatCard, MatCardContent, MatCardActions } from '@angular/material/card';
import { CurrencyPipe } from '@angular/common';
import { MatAnchor, MatButton } from "@angular/material/button";
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { CartService } from '../../../core/services/cart.service';

@Component({
  selector: 'app-product-item',
  imports: [
    MatCard,
    MatCardContent,
    CurrencyPipe,
    MatCardActions,
    MatAnchor,
    MatIcon,
    MatButton,
    RouterLink
],
  templateUrl: './product-item.html',
  styleUrl: './product-item.css',
})
export class ProductItem {
  @Input() product?: Product;
  cartService = inject(CartService);
}
