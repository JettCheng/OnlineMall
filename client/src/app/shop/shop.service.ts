import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IResponse } from '../shared/model/response';
import { IProductType } from '../shared/model/productType';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { IProduct } from '../shared/model/product';
import { ShopParams } from '../shared/model/shopParams';
import { Pagination } from '../shared/model/pagination';



@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'http://localhost:5000/api';
  productTypes : IProductType[] = [];
  productTypeSelected = '';
  // shopParams = new ShopParams();

  constructor(private http: HttpClient) { }

  getProducts (shopParams: ShopParams, pagination: Pagination): Observable<HttpResponse<IResponse<Array<IProduct>>>> {
    var url = this.baseUrl+"/products/items?";

    let params = new HttpParams();

    if (shopParams.productTypeId !== '') {
      params = params.append('productTypeId', shopParams.productTypeId)
    }

    if (shopParams.keyword !== '')
    {
      params = params.append('keyword', shopParams.keyword)
    }

    params = params.append('orderBy', shopParams.sort);
    params = params.append('pageNumber', pagination.CurrentPage.toString());
    params = params.append('pageSize', pagination.PageSize.toString());

    
    return this.http.get<IResponse<Array<IProduct>>>(url, {observe: 'response', params});
  }

  getProduct(id: string) {
    return this.http.get<IResponse<IProduct>>(this.baseUrl + '/products/' + id);
  }

  getProductTypesLevel0() {
    return this.http.get<IResponse<Array<IProductType>>>(this.baseUrl + '/products/producttypes/0');
  }
  getProductTypesLevel1ByParentId(parentId:string) {
    return this.http.get<IResponse<Array<IProductType>>>(this.baseUrl+'/products/'+parentId+'/1');
  }
}
