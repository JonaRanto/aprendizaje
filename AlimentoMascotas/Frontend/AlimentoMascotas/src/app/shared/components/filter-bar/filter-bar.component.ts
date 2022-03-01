import { Component, OnInit } from '@angular/core';
import { IApiResponse, IFilterBarMenu } from '@data/interfaces';
import { EspecieService } from '@data/services/api/especie.service';

@Component({
  selector: 'app-filter-bar',
  templateUrl: './filter-bar.component.html',
  styleUrls: ['./filter-bar.component.scss']
})
export class FilterBarComponent implements OnInit {

  especies: any;
  etapas: any;
  marcas: any;

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

  constructor(
    private especieService: EspecieService,
  ) { }

  ngOnInit(): void {
    this.especieService.getEspecies()
    .subscribe((r: IApiResponse) => {
      this.especies = r.data;
    });
  }

  toogleSubMenu(marca: string): void {
    for (let menu of this.filter_bar.menus) {
      if (menu.name == marca) {
        menu.status = !menu.status;
      }
    }
  }
}
