import { __decorate } from "tslib";
import { Component } from '@angular/core';
let CadastrarProdutoComponent = class CadastrarProdutoComponent {
    constructor(router, service) {
        this.router = router;
        this.service = service;
    }
    ngOnInit() {
    }
    cadastrar() {
        let product = {
            name: this.name,
        };
        this.service.create(product).subscribe(product => {
            console.log(product);
            this.router.navigate([""]);
        });
    }
};
CadastrarProdutoComponent = __decorate([
    Component({
        selector: 'app-cadastrar-produto',
        templateUrl: './cadastrar-produto.component.html',
        styleUrls: ['./cadastrar-produto.component.css']
    })
], CadastrarProdutoComponent);
export { CadastrarProdutoComponent };
//# sourceMappingURL=cadastrar-produto.component.js.map