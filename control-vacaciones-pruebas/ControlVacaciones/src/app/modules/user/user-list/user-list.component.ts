import { Component, OnInit } from '@angular/core';
import { CAROUSEL_DATA_ITEMS } from '@data/constants/carousel.const';
import { UserService } from '@data/services/api/user.service';
import { ICarouselItem } from '@shared/components/carousel/icarousel-item.metadata';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  public carouselData: ICarouselItem[] = CAROUSEL_DATA_ITEMS;
  public users: any;

  constructor(
    private userService: UserService
  ) { 
    this.userService.getAllUsers().subscribe(r => {
      this.users = r;
      if (!r.error) { 
        this.users = r.data;
      }
    });
  }

  ngOnInit(): void {

  }

}
