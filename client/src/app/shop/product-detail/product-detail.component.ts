import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/model/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
product: IProduct;
quantity: number = 1;
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.loadProduct();
  }
  
  loadProduct() {
    this.shopService.getProduct('e7fc3b52-9811-42bb-9180-5f92b75b90a2').subscribe(response => {
      this.product = response.data;
    }, error => {
      console.log(error);
      console.log("product-detail error");
    });
  }
  decrementQuantity() {

  }

  incrementQuantity() {

  }

  addItemToBasket() {

  }

}
