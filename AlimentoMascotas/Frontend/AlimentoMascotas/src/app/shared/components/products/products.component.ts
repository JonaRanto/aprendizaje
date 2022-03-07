import { Component, OnInit } from '@angular/core';
import { API_INTERNAL_ROUTES, ERROR_CONST } from '@data/constants';
import { IApiAlimento, IApiResponse } from '@data/interfaces';
import { ApiService } from '@data/services';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: IApiAlimento[] = [];

  constructor(
    private apiService: ApiService,
  ) { }

  ngOnInit(): void {
    this.apiService.getList(API_INTERNAL_ROUTES.ALIMENTO.LISTAR, ERROR_CONST.ALIMENTO.DEFAULT_ERROR)
      .subscribe((r: IApiResponse) => {
        if (!r.error) {
          var alimentos: IApiAlimento[] = r.data;
          alimentos.forEach((alimento: IApiAlimento) => {
            if (alimento.especie === "Gato"){
              this.products.push(alimento);
            }
          })
        } else {
          console.log(r.message);
        }
      })
  }
}
