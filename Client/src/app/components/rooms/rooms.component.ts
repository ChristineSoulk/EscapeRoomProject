import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { RoomService } from './room.service';
 import { Room } from './roomsModels';
 
@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent implements OnInit {

  Rooms!:Array<Room>;

  constructor(private roomService:RoomService) { }

  ngOnInit(): void {
    this.roomService.getRooms().subscribe(
      {
        next: response => this.Rooms = response,
        error: e => console.log(e),
        complete: () => console.log("petuxe")
      }
    )
  }

}
