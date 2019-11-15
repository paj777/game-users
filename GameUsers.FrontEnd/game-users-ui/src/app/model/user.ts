export class User {
    id: number;
    firstName: string;
    lastName: string;
    telephone: string;
    email: string;

    public asPostString(): string {
        return '/' + this.id + '/' + this.firstName + '/' + this.lastName + '/' + this.email + '/' + this.telephone;
    }
}
