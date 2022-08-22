import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HomeComponent implements OnInit {

  BorderRadius= 1000;
  colorRed ="color:red;"
  colorBlue="color:blue;"
  margin="padding:200px"

  
 
  constructor() { }

  ngOnInit(): void {
  }

}
