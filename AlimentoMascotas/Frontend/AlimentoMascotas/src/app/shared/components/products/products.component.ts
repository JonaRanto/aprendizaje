import { Component, OnInit } from '@angular/core';
import { API_INTERNAL_ROUTES, ERROR_CONST, IMAGES_ROUTES } from '@data/constants';
import { IApiAlimento, IApiResponse } from '@data/interfaces';
import { AlimentoService } from '@data/services';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: IApiAlimento[] = [];

  constructor(
    private alimentoService: AlimentoService,
  ) { }

  ngOnInit(): void {
    this.alimentoService.getAlimentos(API_INTERNAL_ROUTES.ALIMENTO.LISTAR, ERROR_CONST.ALIMENTO.DEFAULT_ERROR)
      .subscribe((r: IApiResponse) => {
        if (!r.error) {
          var alimentos: IApiAlimento[] = r.data;
          alimentos.forEach((alimento: IApiAlimento) => {
            this.products.push(alimento);
          })
        } else {
          console.log(r.message);
        }
      })
  }

  imageRouteGenerator(key: string, path: string): string {
    var img = IMAGES_ROUTES.CONTENT.LINK + path + '/';
    var extension = IMAGES_ROUTES.CONTENT.EXTENSION;
    var link = img + key.toString().toLowerCase() + extension;
    return link;
  }
}
