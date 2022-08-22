import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homephotos',
  templateUrl: './homephotos.component.html',
  styleUrls: ['./homephotos.component.css'],
  
})
export class HomephotosComponent implements OnInit {
  slides = [
    {img: "https://escapethereview.co.uk/wp-content/uploads/2019/03/game-2027.png"},
    {img: "https://img.grouponcdn.com/deal/22XfEvq2jx1vn7hL99SXn9yEhf9r/22-2000x1200/v1/c870x524.jpg"},
    {img: "https://www.everyescaperoom.co.uk/data/images/products/355/thumbnail/9e87c42b628d0ddaae453e2ec82cb144.jpg"},
    {img: "https://thelogicescapesme.com/wp-content/uploads/2017/06/breakin-sherlock.jpg"},
    {img: "https://escapethereview.co.uk/wp-content/uploads/2017/04/warbg-e1491755688889.png"},
    {img: "https://i0.wp.com/scareaddicts.com/wp-content/uploads/2019/05/img_5043.jpg?resize=400%2C240"},
    {img: "https://s3-media0.fl.yelpcdn.com/bphoto/_i2AOgUQOu615EQ1b9fyuw/348s.jpg"},
    {img: "https://media-cdn.tripadvisor.com/media/photo-s/17/71/a4/65/psychopath-s-den.jpg"},
    {img: "https://enigmaescape.gr/wp-content/uploads/2021/04/Rhodes-escape-rooms-2.jpg"},
    {img: "https://static.designmynight.com/uploads/2018/06/Aim-Escape-Room-Psychopaths-Den_041.png"}
  ];
  slideConfig = {"slidesToShow": 4, "slidesToScroll": 4};

  
  
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
  constructor () {}

  ngOnInit(): void {
  }

}
