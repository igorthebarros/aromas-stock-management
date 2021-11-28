import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit{ 

  id!: number;
  name!: string;
  surname!: string;
  email!: string;
  password!: string;
  active!: boolean;

  constructor(private service: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  update(): void{
    let user: User = {
      id: this.id,
      name: this.name,
      surname: this.surname,
      email: this.email,
      password: this.password,
      active: this.active,
    };
    this.service.update(user).subscribe(user => {
      console.log(user);
      this.router.navigate(['user/list']);
    });
  }


}
