import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from './user.service';
import { User } from '../model/user';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  private user: User;
  private title = 'Update User';

  constructor(private route: ActivatedRoute,
              private router: Router,
              private userService: UserService) { }

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

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');

    this.userService.getUser(id).subscribe({
      next: user => {
        this._email = user.email;
        this._telephone = user.telephone;
        this._firstName = user.firstName;
        this._lastName = user.lastName;
        this._id = user.id;
      }
    });
  }

  onSave(): void{
    const user: User = new User();

    user.id = this._id;
    user.lastName = this._lastName;
    user.firstName = this._firstName;
    user.telephone = this._telephone;
    user.email = this._email;

    this.userService.updateUser(user).subscribe(() => {
      this.router.navigate(['/users']);
    });
  }

  onBack(): void {
    this.router.navigate(['/users']);
  }

}
