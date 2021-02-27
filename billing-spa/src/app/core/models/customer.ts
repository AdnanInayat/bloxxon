import { Invoice } from "./invoice";

export interface Customer {
    id: string;
    firstname: string;
    lastname: string;
    email?: string;
    imgUrl?: string;
    profileImage?: string;
    invoices?: [Invoice]
}