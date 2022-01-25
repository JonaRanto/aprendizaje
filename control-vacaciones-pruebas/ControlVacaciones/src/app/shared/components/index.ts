import { LinkAComponent } from './link-a/link-a.component';
import { TitleH1Component } from './titles/title-h1/title-h1.component'
import { TitleH2Component } from './titles/title-h2/title-h2.component';
import { TitleH3Component } from './titles/title-h3/title-h3.component';
import { TitleH4Component } from './titles/title-h4/title-h4.component';
import { CardUserComponent } from './cards/card-user/card-user.component';
import { CarouselComponent } from './carousel/carousel.component';
import { CardLoaderComponent } from './loaders/card-loader/card-loader.component';

export const components: any[] = [
    TitleH1Component,
    TitleH2Component,
    TitleH3Component,
    TitleH4Component,
    LinkAComponent,
    CardUserComponent,
    CarouselComponent,
    CardLoaderComponent
];

// export all components
export * from './titles/title-h1/title-h1.component';
export * from './titles/title-h2/title-h2.component';
export * from './titles/title-h3/title-h3.component';
export * from './titles/title-h4/title-h4.component';
export * from './link-a/link-a.component';
export * from './cards/card-user/card-user.component';
export * from './carousel/carousel.component';
export * from './loaders/card-loader/card-loader.component';
