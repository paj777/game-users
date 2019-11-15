import { Component, OnInit } from '@angular/core';
import { LeaderBoardService } from './leaderboard.service';
import { LeaderboardEntry } from '../model/leaderboard-entry';

@Component({
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.css']
})
export class LeaderboardComponent implements OnInit {
  title = 'Leaderboard';
  errorMessage: string;
  leaderboardEntries: LeaderboardEntry[] = [];

  constructor(private leaderboardService: LeaderBoardService) { }

  ngOnInit(): void {
    this.leaderboardService.getLeaderboard().subscribe({
      next: leaderboardEntries => {
        this.leaderboardEntries = leaderboardEntries;
        console.log(this.leaderboardEntries);
      },
      error: err => this.errorMessage = err
    });
  }

}
