import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { UserComponent } from './users/user.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { UserDetailComponent } from './users/user-detail.component';
import { UserCreateComponent } from './users/user-create.component';


const routes: Routes = [
  {
    path: 'users',
    component: UserComponent
  },
  {
    path: 'users/:id',
    component: UserDetailComponent
  },
  {
    path: 'users-create',
    component: UserCreateComponent
  },
  {
    path: 'leaderboard',
    component: LeaderboardComponent
  },
  {path: '**', redirectTo: '/'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
