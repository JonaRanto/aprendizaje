import { Component, OnInit } from '@angular/core';
import { API_INTERNAL_ROUTES, ERROR_CONST, FILTER_BAR } from '@data/constants';
import { IApiEspecie, IApiResponse } from '@data/interfaces';
import { ApiService } from '@data/services';

@Component({
  selector: 'app-filter-bar',
  templateUrl: './filter-bar.component.html',
  styleUrls: ['./filter-bar.component.scss']
})
export class FilterBarComponent implements OnInit {

  filter_bar = FILTER_BAR;

  constructor(
    private apiService: ApiService,
  ) { }

  ngOnInit(): void {
    this.fillFilterBar();
  }

  addFilter(filter: string): void {
    // Si el filtro de sessionStorage no tiene nada o no existe entonces toma el valor del filtro entregado
    if (sessionStorage.getItem('filters') == null || sessionStorage.getItem('filters') == "") {
      sessionStorage.setItem('filters', filter);
      window.location.reload();
    }
    else {
      var key = sessionStorage.getItem('filters');
      var arrFiltersSessionSorage = (key == null ? "" : key).split(',');

      // Se genera una flag para saber si un filtro se repite
      var filterFlag: [boolean, string] = [false, ""];
      // Recorrer todo el arreglo de filtros
      for (let filtersSessionStorage of arrFiltersSessionSorage) {
        // Si el nombre del filtro es igual al nombre del filtro entregado, se activa el flag
        if (filtersSessionStorage.split(': ')[0].toLowerCase() == filter.split(': ')[0].toLowerCase()) {
          filterFlag[0] = true;
          filterFlag[1] = filtersSessionStorage;
        }
      }
      // Si no se activa el flag, se añade el nuevo filtro
      if (filterFlag[0] == false) {
        var i = arrFiltersSessionSorage.indexOf(filter);
        if (i == -1) {
          arrFiltersSessionSorage.push(filter.toLowerCase());
          sessionStorage.setItem('filters', arrFiltersSessionSorage.toString())
          window.location.reload();
        }
      }
      // Si se activa el flag se reemplaza el filtro
      else {
        var i = arrFiltersSessionSorage.indexOf(filterFlag[1]);
        arrFiltersSessionSorage[i] = filter.toLowerCase();
        sessionStorage.setItem('filters', arrFiltersSessionSorage.toString());
        window.location.reload();
      }
    }
  }

  fillFilterBar(): void {
    this.apiService.getList(API_INTERNAL_ROUTES.ESPECIE.LISTAR, ERROR_CONST.ESPECIE.DEFAULT_ERROR)
      .subscribe((r: IApiResponse) => {
        var especies: IApiEspecie[] = r.data;
        especies.forEach((e: IApiEspecie) => {
          this.filter_bar.menus.filter(e => e.name == "Especie")[0].subMenus.push(e);
        })
      })

    this.apiService.getList(API_INTERNAL_ROUTES.ETAPA.LISTAR, ERROR_CONST.ETAPA.DEFAULT_ERROR)
    .subscribe((r: IApiResponse) => {
      var especies: IApiEspecie[] = r.data;
      especies.forEach((e: IApiEspecie) => {
        this.filter_bar.menus.filter(e => e.name == "Etapa")[0].subMenus.push(e);
      })
    })

    this.apiService.getList(API_INTERNAL_ROUTES.MARCA.LISTAR, ERROR_CONST.MARCA.DEFAULT_ERROR)
    .subscribe((r: IApiResponse) => {
      var especies: IApiEspecie[] = r.data;
      especies.forEach((e: IApiEspecie) => {
        this.filter_bar.menus.filter(e => e.name == "Marca")[0].subMenus.push(e);
      })
    })
  }

  toogleSubMenu(marca: string): void {
    for (let menu of this.filter_bar.menus) {
      if (menu.name == marca) {
        menu.status = !menu.status;
      }
    }
  }
}
