import { IProductImage } from "./productImage";
import { IProductType } from "./productType";

export interface IProduct {
    id: string
    title: string
    description: string
    originalPrice: number
    // rate: number
    status: number
    productType: IProductType
    coverImageUrl:string
    productImages: IProductImage[]
  }