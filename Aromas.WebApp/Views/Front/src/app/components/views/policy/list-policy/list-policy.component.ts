import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Policy } from 'src/app/models/policy';
import { PolicyService } from 'src/app/services/policy.service';

@Component({
  selector: 'app-list-policy',
  templateUrl: './list-policy.component.html',
  styleUrls: ['./list-policy.component.css']
})
export class ListPolicyComponent implements OnInit {

  id!: number;

  policy!: MatTableDataSource<Policy>;
  displayedColumns: string[] = [ 'nome', 'situacao', 'acoes'];

  constructor(private service: PolicyService, private router: Router) { }

  ngOnInit(): void {
    this.service.list().subscribe((policy) => {
      this.policy = new MatTableDataSource<Policy>(policy);
    })
  }

  delete(id: number): void {
    this.service.delete(id).subscribe((policy) => {
      this.router.navigate(['policy/list']);
    });
  }
}
