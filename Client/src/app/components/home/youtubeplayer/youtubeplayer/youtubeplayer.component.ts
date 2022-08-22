import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-youtubeplayer',
  templateUrl: './youtubeplayer.component.html',
  styleUrls: ['./youtubeplayer.component.css']
})
export class YoutubeplayerComponent implements OnInit {

  slides = [
    {videoIds: "64NrDwoaYuU"},
    {videoIds: "1beRQ5WqrPo"},
    {videoIds: "wezggys53KM"},
    {videoIds: "-bVS5uHamck"},
    {videoIds: "0i85CJilgdQ"},
    {videoIds: "Tj1Chebkz68"},
    {videoIds: "LuNhlOziCzc"},
    {videoIds: "asaREiqt-7M"},
    {videoIds: "mWdqJfjOP8w"},
    {videoIds: "1TACbGt9dO4"}
  ];
  slideConfig = {"slidesToShow": 1, "slidesToScroll": 1};

  
  
  slickInit(_e: any) {
    console.log('slick initialized');
  }
    
  breakpoint(_e: any) {
    console.log('breakpoint');
  }
    
  afterChange(_e: any) {
    console.log('afterChange');
  }
    
  beforeChange(_e: any) {
    console.log('beforeChange');
  }
  constructor() { }

  ngOnInit(): void {
  }

}
