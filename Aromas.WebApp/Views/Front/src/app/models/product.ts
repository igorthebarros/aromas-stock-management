export interface Product {
    id?: number;
    name: string;
    //isInStock: boolean;
    stockQuantity: number;
    createdAt?: Date;
    updatedAt?: Date;
    categoryId: number;
}
