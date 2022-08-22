import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SlickCarouselModule } from 'ngx-slick-carousel';

import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { RoomsComponent } from './components/rooms/rooms.component';
import { DetailsComponent } from './components/rooms/details/details.component';
import { AboutComponent } from './components/about/about.component';
import { BookComponent } from './components/book/book.component';
import { ContactComponent } from './components/contact/contact.component';
import { SignComponent } from './components/sign/sign.component';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { HomephotosComponent } from './components/home/homephotos/homephotos/homephotos.component';
import { YoutubeplayerComponent } from './components/home/youtubeplayer/youtubeplayer/youtubeplayer.component';
import { MapComponent } from './components/home/map/map/map.component';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RoomsComponent,
    DetailsComponent,
    AboutComponent,
    BookComponent,
    ContactComponent,
    SignComponent,
    HomephotosComponent,
    YoutubeplayerComponent,
    MapComponent,
    HomephotosComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    YouTubePlayerModule,
    SlickCarouselModule,
    HttpClientModule,
    RouterModule.forRoot
      ([

        { path: "Home", component: HomeComponent },
        { path: "Rooms", component: RoomsComponent },
        { path: "Details", component: DetailsComponent },
        { path: "About", component: AboutComponent },
        { path: "Book", component: BookComponent },
        { path: "Contact", component: ContactComponent },
        { path: "Sign", component: SignComponent },

        { path: '', redirectTo: "/Home", pathMatch: 'full' },


      ])

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
