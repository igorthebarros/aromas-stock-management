import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  name!: string;
  surname!: string;
  email!: string;
  password!: string;
  active!: boolean;

  constructor(private service: UserService, private router: Router) { }

  ngOnInit(): void {}

  register(): void {
    let user: User = {
      name: this.name,
      surname: this.surname,
      email: this.email,
      password: this.password,
      active: this.active,
    };
    this.service.register(user).subscribe(user => {
      console.log(user);
      this.router.navigate(['user/list']);
    });
  }

  cancelar(): void {
    this.router.navigate(["user/list"]);
  }
}
