import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';
import { User } from '../model/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {
  private title = 'Create User';
  constructor(private userService: UserService, private router: Router) { }

  _firstName: string;
  get firstName(): string {
    return this._firstName;
  }
  set firstName(value: string) {
    this._firstName = value;    
  }

  _lastName: string;
  get lastName(): string {
    return this._lastName;
  }
  set lastName(value: string) {
    this._lastName = value;    
  }

  _telephone: string;
  get telephone(): string {
    return this._telephone;
  }
  set telephone(value: string) {
    this._telephone = value;    
  }

  _email: string;
  get email(): string {
    return this._email;
  }
  set email(value: string) {
    this._email = value;    
  }

  _id: number;
  get id(): number {
    return this._id;
  }
  set id(value: number) {
    this._id = value;    
  }

  onSave(): void{    
    const user: User = new User();

    user.id = this._id;
    user.lastName = this._lastName;
    user.firstName = this._firstName;
    user.telephone = this._telephone;
    user.email = this._email;

    this.userService.addUser(user).subscribe(() => {
      this.router.navigate(['/users']);
    });
  }

  onBack(): void{
    this.router.navigate(['/users']);
  }

  ngOnInit() {
  }

}
