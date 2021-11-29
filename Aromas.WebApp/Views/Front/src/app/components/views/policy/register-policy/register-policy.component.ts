import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Policy } from 'src/app/models/policy';
import { PolicyService } from 'src/app/services/policy.service';

@Component({
  selector: 'app-register-policy',
  templateUrl: './register-policy.component.html',
  styleUrls: ['./register-policy.component.css']
})
export class RegisterPolicyComponent implements OnInit {
  
  name!: string;
  active!: boolean;

  constructor(private service: PolicyService, private router: Router) { }

  ngOnInit(): void {
  }

  register(): void {
    let policy: Policy = {
      name: this.name,
      active: this.active,
    };
    this.service.register(policy).subscribe(policy => {
      console.log(policy);
      this.router.navigate(['policy/list']);
    });
  }
}
