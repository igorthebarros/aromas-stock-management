import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-cadastrar-produto',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})
export class CadastrarProdutoComponent implements OnInit {

  name!: string;

  constructor(private router: Router, private service: ProdutoService) { }

  ngOnInit(): void {
  }

  cadastrar(): void {
    let product : Product = {
      name: this.name,
    };
    this.service.create(product).subscribe(product => {
      console.log(product);
      this.router.navigate([""]);
    });
    
  }



}
