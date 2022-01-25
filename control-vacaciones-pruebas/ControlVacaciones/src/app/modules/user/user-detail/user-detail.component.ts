import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { USERS_DATA } from '@data/constants/users.const';
import { UserService } from '@data/services/api/user.service';
import { ICardUser } from '@shared/components/cards/card-user/icard-user.metadata';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  public users: ICardUser[] = USERS_DATA;
  public id: number;
  public currentUser: ICardUser;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ) { 
    this.id = +this.route.snapshot.params.id;   // Cuando un numero viene de una ruta, entra como string aunque diga que es de tipo number, por lo que se debe poner un + antes de la variable
    //this.currentUser = this.users.find(user => user.id === this.id);
   }

   ngOnInit(): void {
    this.userService.getUserById(this.id).subscribe(r => {
      if (!r.error) {
        this.currentUser = r.data;
      }
    })
  }
}
