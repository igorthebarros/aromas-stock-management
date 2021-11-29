import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit{ 

  user!: User;
  id!: string;
  
  constructor(private service: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.snapshot.paramMap.get('id')
    this.service.searchId(this.id).subscribe(user => {
      this.user = user;
    })
  }

  update(): void{
    this.service.update(this.user).subscribe(() => {
      this.router.navigate(['user/list']);
    });
  }
}
