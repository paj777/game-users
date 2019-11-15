import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './users/user.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { windowProviders } from './core/providers/window-provider';
import { UserDetailComponent } from './users/user-detail.component';
import { UserCreateComponent } from './users/user-create.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    LeaderboardComponent,
    UserDetailComponent,
    UserCreateComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [ windowProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
