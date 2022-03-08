import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  filters: any[] = [];

  constructor() { }

  ngOnInit(): void {
    // Si no hay datos de filtros en la sessionStorage, se elimina la llave de filtros
    if (sessionStorage.getItem('filters') != null && sessionStorage.getItem('filters') != "") {
      // Se llenan los filtros con la información de sessionStorage y con estos se rellena una variable json para pasarlos a queryParam
      var key = sessionStorage.getItem('filters');
      for (let filter of (key == null ? "" : key).split(',')) {
        this.filters.push(filter);
      }
    }
    else {
      sessionStorage.removeItem('filters');
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
