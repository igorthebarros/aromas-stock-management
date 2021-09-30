import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let ProdutoService = class ProdutoService {
    constructor(http) {
        this.http = http;
        this.baseUrl = "http://localhost:44386/Product";
    }
    list() {
        return this.http.get(`${this.baseUrl}`);
    }
    create(product) {
        return this.http.post(`${this.baseUrl}/Create`, product);
    }
};
ProdutoService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], ProdutoService);
export { ProdutoService };
//# sourceMappingURL=produto.service.js.map