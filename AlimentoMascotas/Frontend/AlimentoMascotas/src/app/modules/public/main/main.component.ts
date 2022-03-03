import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  filters: any[] = [];

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
    // Si no hay datos de filtros en la sessionStorage, se elimina la llave de filtros
    if (sessionStorage.getItem('filters') != null && sessionStorage.getItem('filters') != "") {
      // Se llenan los filtros con la información de sessionStorage y con estos se rellena una variable json para pasarlos a queryParam
      var key = sessionStorage.getItem('filters');
      var arrJson: any = {};
      for (let filter of (key == null ? "" : key).split(',')) {
        this.filters.push(filter);
        var arrKey = filter.split(': ')[0];
        var arrValue = filter.split(': ')[1];
        arrJson[arrKey] = arrValue;
      }
      // Se llena los queryParams con los valores de los filtros
      this.router.navigate([], { 
        queryParams: arrJson
      })
    }
    else {
      sessionStorage.removeItem('filters');
      this.router.navigate([], { 
        queryParams: {}
      })
    }
  }
 
  deleteFilter(filter: string) : void {
    var key = sessionStorage.getItem('filters');
    var arrFiltersSessionSorage = (key == null ? "" : key).split(',');
    var i = arrFiltersSessionSorage.indexOf(filter);
    if (i != -1) {
      arrFiltersSessionSorage.splice(i, 1);
      sessionStorage.setItem('filters', arrFiltersSessionSorage.toString())
      window.location.reload();
    }
  }
}
