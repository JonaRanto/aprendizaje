import { Component, OnInit } from '@angular/core';
import { IFilterBarMenu } from '@data/interfaces';
import { environment } from 'environments/environment';

@Component({
  selector: 'app-filter-bar',
  templateUrl: './filter-bar.component.html',
  styleUrls: ['./filter-bar.component.scss']
})
export class FilterBarComponent implements OnInit {

  filter_bar: IFilterBarMenu = {
    title: 'Filtros',
    menus: [
      {
        name: 'Especie',
        status: false,
        subMenus: [
          {
            name: 'Perro',
            link: '',
          },
          {
            name: 'Gato',
            link: '',
          },
        ]
      },
      {
        name: 'Etapa',
        status: false,
        subMenus: [
          {
            name: 'Cachorro',
            link: '',
          },
          {
            name: 'Adulto',
            link: '',
          },
          {
            name: 'Senior',
            link: '',
          },
        ]
      },
      {
        name: 'Marca',
        status: false,
        subMenus: [
          {
            name: 'Raza',
            link: '',
          },
          {
            name: 'Whiskcas',
            link: '',
          },
        ]
      },
    ]
  }

  constructor() { }

  ngOnInit(): void {
  }

  toogleSubMenu(marca: string): void {
    for (let menu of this.filter_bar.menus) {
      if (menu.name == marca) {
        menu.status = !menu.status;
      }
    }
  }
}
