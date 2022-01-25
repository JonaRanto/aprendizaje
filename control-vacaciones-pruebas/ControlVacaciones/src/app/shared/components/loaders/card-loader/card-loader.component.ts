import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-loader',
  templateUrl: './card-loader.component.html',
  styleUrls: ['./card-loader.component.css']
})
export class CardLoaderComponent implements OnInit {

  @Input() imageSize = 75;
  @Input() barHeight = 15;
  @Input() bars = 1;

  public totalBars:{width: string}[] = [];
  public finalStyleImage = {};
  public finalheightBar = '0';

  constructor() { }

  ngOnInit(): void {
    for (let i = 0; i < this.bars; i++) {
      const width = Math.floor(Math.random() * (100-60)) + 60;
      this.totalBars.push({width: `${width}%`});
    };

    this.finalStyleImage = {
      with: `${this.imageSize}px`,
      height: `${this.imageSize}px`
    };

    this.finalheightBar = `${this.barHeight}px`;
  }

}
