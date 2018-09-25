import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-memberbar',
  templateUrl: './memberbar.component.html',
  styleUrls: ['./memberbar.component.scss']
})
export class MemberbarComponent implements OnInit {
  user = null;
  constructor() { }

  ngOnInit() {
  }

}
