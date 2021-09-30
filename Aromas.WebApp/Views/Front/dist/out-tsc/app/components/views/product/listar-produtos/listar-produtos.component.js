import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ListarProdutosComponent = class ListarProdutosComponent {
    constructor(service) {
        this.service = service;
        this.products = [];
    }
    ngOnInit() {
        this.service.list().subscribe((products) => {
            this.products = products;
            console.log(products);
        });
    }
};
ListarProdutosComponent = __decorate([
    Component({
        selector: 'app-listar-produtos',
        templateUrl: './listar-produtos.component.html',
        styleUrls: ['./listar-produtos.component.css']
    })
], ListarProdutosComponent);
export { ListarProdutosComponent };
//# sourceMappingURL=listar-produtos.component.js.map