import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';
import { User } from '../model/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  title = 'User List';
  errorMessage: string;
  users: User[] = [];

  constructor(private userService: UserService, private router: Router) { }

  addUser(): void {
    this.router.navigate(['/users-create']);
  }

  ngOnInit(): void {
    this.userService.getUsers().subscribe({
      next: users => {
        this.users = users;
      },
      error: err => this.errorMessage = err
    });
  }

}
