import { Customer } from "./customer";

export interface Invoice {
    id: string;
    customerId: string;
    amount: number;
    deadline: Date;
    customer?: Customer;
}