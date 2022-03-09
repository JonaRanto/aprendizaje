import { Component, OnInit } from '@angular/core';
import { API_INTERNAL_ROUTES, ERROR_CONST, IMAGES_ROUTES } from '@data/constants';
import { IApiAlimento, IApiAnalitico, IApiIngrediente, IApiResponse } from '@data/interfaces';
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
    });
  }

  orderDescIngrediente(list: IApiIngrediente[]): IApiIngrediente[] {
    var result: IApiIngrediente[] = [];
    result = list.sort((a: IApiIngrediente, b: IApiIngrediente) => {
      return b.quantityPer - a.quantityPer;
    });
    return result;
  }

  orderDescAnalitico(list: IApiAnalitico[]): IApiAnalitico[] {
    var result: IApiAnalitico[] = [];
    result = list.sort((a: IApiAnalitico, b: IApiAnalitico) => {
      return (b.quantityPer + (b.quantityGra/1000)) - (a.quantityPer + (a.quantityGra/1000));
    });
    return result;
  }

  getQuantityIngrediente(ingrediente: IApiIngrediente): string {
    if (ingrediente.quantityPer != 0) {
      return ingrediente.name + " " + ingrediente.quantityPer + "%";
    }
    else {
      return ingrediente.name;
    }
  }

  getQuantityAnalitico(analitico: IApiAnalitico): string {
    if (analitico.quantityGra != 0) {
      return analitico.name + " " + analitico.quantityGra + "grs";
    }
    else if (analitico.quantityPer != 0) {
      return analitico.name + " " + analitico.quantityPer + "%";
    }
    else {
      return analitico.name;
    }
  }

  imageRouteGenerator(key: string, path: string): string {
    var img = IMAGES_ROUTES.CONTENT.LINK + path + '/';
    var extension = IMAGES_ROUTES.CONTENT.EXTENSION;
    var link = img + key.toString().toLowerCase() + extension;
    return link;
  }
}
