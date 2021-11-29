import { Category } from "./category";

export interface Product {
    id?: string;
    name: string;
    isInStock: boolean;
    stockQuantity: number;
    createdAt?: Date;
    updatedAt?: Date;
    categoryId: number;
    category?: Category;
}
