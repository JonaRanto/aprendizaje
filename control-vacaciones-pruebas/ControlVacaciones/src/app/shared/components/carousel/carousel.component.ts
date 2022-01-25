import { Component, Input, OnInit } from '@angular/core';
import { ICarouselItem } from './icarousel-item.metadata';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {

  /**
   * Custom properties
   */
  @Input() height = 500;
  @Input() isFullScreen = false;
  @Input() items: ICarouselItem[] = [];

  /**
   * Final properties
   */
  public finalHeight: string | number = 0;
  public currentPosition = 0;

  constructor() { 
    this.finalHeight = this.isFullScreen ? '100vh' : `${this.height}px`;  // Si se usa el total de la pantalla, la altura va a ser 100vh y si no, la altura será la de la variable indicada
   }

  ngOnInit(): void {
    this.items.map((i, index) => {
      i.id = index;       // Cada item tendrá como identificador su index
      i.marginLeft = 0;   // Las imagenes tendran un margin-left de 0
    });
  }

  setCurrentPosition(position: number) {
    this.currentPosition = position;  // Se establecerá la posición actualmente activa como la posicion actual del item
    this.items.find(i => i.id === 0).marginLeft = -100 * position;  // Las imagenes del carousel se moveran a travez del margin, moviendose utilizando el 100% de su tamaño multiplicandolo por la posicion definida
  }

  setNext() {
    let finalPercentage = 0;  // Indica el porcentaje en el que estamos actualmente
    let nextPosition = this.currentPosition + 1;  // La siguiente posicion es la posicion actual mas 1
    if (nextPosition <= this.items.length - 1) {
      finalPercentage = -100 * nextPosition;  // Si la posición es menos o igual a la cantidad de items que se tienen, la siguiente posicion será la de la siguiente imagen
    } else {
      nextPosition = 0; // En caso de que la posicion sea mayor, que la siguiente posicion vuelva a ser la posicion 0
    }
    this.items.find(i => i.id === 0).marginLeft = finalPercentage;
    this.currentPosition = nextPosition;
  }

  setBack() {
    let finalPercentage = 0;  // Indica el porcentaje en el que estamos actualmente
    let backPosition = this.currentPosition - 1;  // La posicion anterior es la posicion actual mas 1
    if (backPosition >= 0) {
      finalPercentage = -100 * backPosition;  // Si la posición es mayor o igual a 0, la posicion anterior será la de la imagen anterior
    } else {
      backPosition = this.items.length - 1; // En caso de que la posicion sea menor a 0, que la siguiente posicion sea la de la ultima imagen
      finalPercentage = -100 * backPosition
    }
    this.items.find(i => i.id === 0).marginLeft = finalPercentage;
    this.currentPosition = backPosition;
  }

  public setCarouselStyle(): any {
    let style = {
      'min-height': this.finalHeight
    };
    return style;
  }

  public setCarouselContentItemStyle(section: any): any {
    let style = {
      'background-image': 'url(' + section.image + ')',
      'margin-left': section.marginLeft + '%'
    }
    return style;
  }
}
