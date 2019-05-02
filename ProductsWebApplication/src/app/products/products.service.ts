import{Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ProductsService{

    productsUrl = 'http://localhost:5001/api/products'

    constructor(private http: HttpClient){ }

    public getProducts(){
        return this.http.get<any[]>(`${this.productsUrl}`);
    }
}