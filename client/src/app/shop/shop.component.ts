import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Pagination } from '../shared/model/pagination';
import { IProduct } from '../shared/model/product';
import { IProductImage } from '../shared/model/productImage';
import { IProductType } from '../shared/model/productType';
import { ShopParams } from '../shared/model/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;

  products: IProduct[] = [];
  productTypesLevel0: IProductType[] = [];
  productTypesLevel1: IProductType[] = [];
  // productImages: IProductImage[] = [];
  shopParams = new ShopParams() ;
  totalCount: number;
  sortOptions = [
    {name: '價格', value: 'orignalPrice'}, 
    {name: '商品名稱', value: 'title'}
  ]
  pagination = new Pagination();

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getProductTypesLeve0();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams, this.pagination).subscribe(response => {
      // const headers = response.headers.keys(); 取出物件中的key，{key:value}
      var xpaginationString = response.headers.get('x-pagination')!;
      this.pagination = JSON.parse(xpaginationString);
      // console.log(this.pagination);
      var data = response.body?.data!;
      this.products = data // 有可能為空值，加上!
    }, error => {
      console.log(error)
    });
  }

  getProductTypesLeve0() {
    this.shopService.getProductTypesLevel0().subscribe(response => {
      this.productTypesLevel0 = response.data;
    }, error => {
      console.log(error);
    });
  }

  getProductTypesLevel1ByParentId(parentId:string) {
    this.shopService.getProductTypesLevel1ByParentId(parentId).subscribe(response => {
      this.productTypesLevel1 = response.data;
    }, error => {
      console.log(error);
    });
    
    this.shopParams.productTypeId = parentId;
  }
  addItemToBasket() {
    
  }
  onProductTypeSelected(id: string) {
    this.shopParams.productTypeId=id;
    this.getProducts();

  }
  onPagerChange(event: any) {
    this.pagination.CurrentPage = event.page
    this.getProducts();
  }
  
  onSearch() {
    const params = this.shopParams;
    params.keyword = this.searchTerm.nativeElement.value;
    params.pageNumber = 1;
    this.shopParams = params;
    console.log(params)
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
