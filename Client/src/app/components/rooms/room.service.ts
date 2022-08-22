import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Room } from './roomsModels';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private URL = "https://localhost:44368/api/RoomApi";

  getRooms(): Observable<Room[]> {
    return this.httpService.get<Room[]>(this.URL);
  }
  
  constructor(private httpService:HttpClient) { }
}
