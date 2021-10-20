import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  id!: number;

  // users: User[] = [];
  user!: MatTableDataSource<User>;
  displayedColumns: string[] = [ 'nome', 'surname', 'email', 'situacao', 'acoes'];

  constructor(private service: UserService, private router: Router) { }

  ngOnInit(): void {
    this.service.list().subscribe((user) => {
      this.user = new MatTableDataSource<User>(user);
      // this.users = users;
      console.log(user);
    })
  }
  
  delete(id: number): void {
    this.service.delete(id).subscribe((user) => {
      this.user = new MatTableDataSource<User>(user);
      //this.router.navigate(['user/list']);
      this.ngOnInit();
    });
  }

  cadastrarUsuario(): void {
    this.router.navigate(["user/register"]);
  }
}
