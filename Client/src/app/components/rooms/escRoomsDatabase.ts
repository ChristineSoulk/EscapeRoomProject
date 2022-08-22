import { IRoom, IParticipants } from "./roomsModels";


let r1:IRoom = 
{
    title: "Rebellion",
    photoUtr: "https://www.escapeall.gr/Images/ServicesPhotos/41aec98d-5e02-46a8-92a0-58c88da31d07/8d0365b3-c72f-4d80-b8ae-800f11f971e6.jpg",
    participant: [
       {groupName:"Anikitoi",
        timesParticipated:10}
    ],
    price:12

}

 
let r2:IRoom = 
{
    title: "Woman in Black",
    photoUtr: "https://www.travel.gr/wp-content/uploads/webp/2021/09/woman.webp",
    participant: [
        {
            groupName: "C Sharks",
            timesParticipated: 1
        }
    ],
    price: 34.23
}

let r3:IRoom = 
{
    title: "Wake up",
    photoUtr: "https://www.travel.gr/wp-content/uploads/webp/2021/09/wake.webp",
    participant: [
        {
            groupName: "Treis kai o koukos",
            timesParticipated: 2
        }
    ],
    price: 1
}


let r4:IRoom = 
{
    title: "LockHill",
    photoUtr: "https://www.travel.gr/wp-content/uploads/webp/2021/09/lockhill-1536x864.webp",
    participant: [
        {
            groupName: "Thiris and the rest",
            timesParticipated: 5
        }
    ],
    price: 50.0
}


let r5:IRoom = 
{
    title: "El Exorcista",
    photoUtr: "https://www.travel.gr/wp-content/uploads/webp/2021/09/el.webp",
    participant: [
        {
            groupName: "Oi Apistoi",
            timesParticipated: 8
        }
    ],
    price: 25.1
}

let r6:IRoom = 
{
    title: "Bloody Mary",
    photoUtr: "https://www.escapeall.gr/Images/ServicesPhotos/618e5a11-438d-47e7-8467-30a55b6d8e3a/aad756bb-0911-4618-b722-7088df8b83b3.jpg",
    participant: [
        {
            groupName: "Malakes megaloi",
            timesParticipated: 12
        }
    ],
    price: 300.3
}
export let rooms: Array<IRoom> = [r1,r2,r3,r4,r5,r6];
